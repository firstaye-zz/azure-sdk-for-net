﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class ExceptionPolicyLiveTests : RouterLiveTestBase
    {
        public ExceptionPolicyLiveTests(bool isAsync) : base(isAsync)
        {
        }

        #region Exception Policy Tests

        [Test]
        public async Task CreateExceptionPolicyTest_QueueLength_Cancel()
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();

            var exceptionPolicyId = GenerateUniqueId($"{IdPrefix}{nameof(CreateExceptionPolicyTest_QueueLength_Cancel)}");

            // exception rules
            var exceptionRuleId = GenerateUniqueId($"{IdPrefix}-ExceptionRule");
            var cancelActionId = GenerateUniqueId($"{IdPrefix}-CancellationExceptionAction");
            var rules = new Dictionary<string, ExceptionRule>()
            {
                [exceptionRuleId] = new ExceptionRule(new QueueLengthExceptionTrigger(1),
                    new Dictionary<string, ExceptionAction?>()
                    {
                        [cancelActionId] = new CancelExceptionAction()
                        {
                            DispositionCode = "CancelledDueToMaxQueueLengthReached"
                        }
                    }
                )
            };

            var createExceptionPolicyResponse = await routerClient.CreateExceptionPolicyAsync(new CreateExceptionPolicyOptions(exceptionPolicyId, rules));
            AddForCleanup(new Task(async () => await routerClient.DeleteExceptionPolicyAsync(exceptionPolicyId)));

            Assert.NotNull(createExceptionPolicyResponse.Value);

            var exceptionPolicy = createExceptionPolicyResponse.Value;

            Assert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            Assert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            Assert.DoesNotThrow(() =>
            {
                var exceptionRule = exceptionPolicy.ExceptionRules.First();

                Assert.AreEqual(exceptionRuleId, exceptionRule.Key);
                Assert.IsTrue(exceptionRule.Value.Trigger.GetType() == typeof(QueueLengthExceptionTrigger));
                var trigger = exceptionRule.Value.Trigger as QueueLengthExceptionTrigger;
                Assert.NotNull(trigger);
                Assert.AreEqual(1, trigger!.Threshold);

                var actions = exceptionRule.Value.Actions;
                Assert.AreEqual(1, actions.Count);
                var cancelAction = actions.FirstOrDefault().Value as CancelExceptionAction;
                Assert.NotNull(cancelAction);
                Assert.AreEqual(cancelActionId, actions.FirstOrDefault().Key);
                Assert.AreEqual($"CancelledDueToMaxQueueLengthReached", cancelAction!.DispositionCode);
            });

            // with name
            var exceptionPolicyName = $"{exceptionPolicyId}-ExceptionPolicyName";
            createExceptionPolicyResponse = await routerClient.UpdateExceptionPolicyAsync(
                new UpdateExceptionPolicyOptions(exceptionPolicyId)
                {
                    Name = exceptionPolicyName
                });

            Assert.NotNull(createExceptionPolicyResponse.Value);

            exceptionPolicy = createExceptionPolicyResponse.Value;

            Assert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            Assert.AreEqual(exceptionPolicyName, exceptionPolicy.Name);
        }

        [Test]
        public async Task CreateExceptionPolicyTest_WaitTime()
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();

            var createDistributionPolicyResponse = await CreateDistributionPolicy(nameof(CreateExceptionPolicyTest_WaitTime));
            var queueId = GenerateUniqueId(IdPrefix, nameof(CreateExceptionPolicyTest_WaitTime));
            var createQueueResponse = await routerClient.CreateQueueAsync(new CreateQueueOptions(queueId,
                    createDistributionPolicyResponse.Value.Id));

            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}{nameof(CreateExceptionPolicyTest_WaitTime)}");
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    PrioritizationRule = new StaticRouterRule(new LabelValue(1))
                });
            var exceptionPolicyId = GenerateUniqueId($"{IdPrefix}{nameof(CreateExceptionPolicyTest_WaitTime)}");

            var labelsToUpsert = new Dictionary<string, LabelValue>() { ["Label_1"] = new LabelValue("Value_1") };
            // exception rules
            var exceptionRuleId = GenerateUniqueId($"{IdPrefix}-ExceptionRule");
            var reclassifyActionId = GenerateUniqueId($"{IdPrefix}-ReclassifyExceptionAction");
            var manualReclassifyActionId = GenerateUniqueId($"{IdPrefix}-ManualReclassifyAction");
            var rules = new Dictionary<string, ExceptionRule>()
            {
                [exceptionRuleId] = new ExceptionRule(new QueueLengthExceptionTrigger(1),
                    new Dictionary<string, ExceptionAction?>()
                    {
                        [reclassifyActionId] = new ReclassifyExceptionAction(classificationPolicyId)
                        {
                            LabelsToUpsert = labelsToUpsert
                        },
                        [manualReclassifyActionId] = new ManualReclassifyExceptionAction
                        {
                            QueueId = createQueueResponse.Value.Id,
                            Priority = 1,
                            WorkerSelectors = { new RouterWorkerSelector("abc", LabelOperator.Equal, new LabelValue(1)) }
                        }
                    }
                )
            };

            var createExceptionPolicyResponse = await routerClient.CreateExceptionPolicyAsync(new CreateExceptionPolicyOptions(exceptionPolicyId, rules));

            AddForCleanup(new Task(async () => await routerClient.DeleteExceptionPolicyAsync(exceptionPolicyId)));
            Assert.NotNull(createExceptionPolicyResponse.Value);

            var exceptionPolicy = createExceptionPolicyResponse.Value;

            Assert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            Assert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            Assert.DoesNotThrow(() =>
            {
                var exceptionRule = exceptionPolicy.ExceptionRules.First();

                Assert.AreEqual(exceptionRuleId, exceptionRule.Key);
                Assert.IsTrue(exceptionRule.Value.Trigger.GetType() == typeof(QueueLengthExceptionTrigger));
                var trigger = exceptionRule.Value.Trigger as QueueLengthExceptionTrigger;
                Assert.NotNull(trigger);
                Assert.AreEqual(1, trigger!.Threshold);

                var actions = exceptionRule.Value.Actions;
                Assert.AreEqual(2, actions.Count);
                var reclassifyExceptionAction = actions.FirstOrDefault().Value as ReclassifyExceptionAction;
                Assert.NotNull(reclassifyExceptionAction);
                Assert.AreEqual(reclassifyActionId, actions.FirstOrDefault().Key);
                Assert.AreEqual(classificationPolicyId, reclassifyExceptionAction?.ClassificationPolicyId);
                Assert.AreEqual(labelsToUpsert.FirstOrDefault().Key, reclassifyExceptionAction?.LabelsToUpsert.FirstOrDefault().Key);
                Assert.AreEqual(labelsToUpsert.FirstOrDefault().Value.Value as string, reclassifyExceptionAction?.LabelsToUpsert.FirstOrDefault().Value.Value as string);
                var manualReclassifyExceptionAction = actions.LastOrDefault().Value as ManualReclassifyExceptionAction;
                Assert.NotNull(manualReclassifyExceptionAction);
                Assert.AreEqual(manualReclassifyActionId, actions.LastOrDefault().Key);
                Assert.AreEqual(queueId, manualReclassifyExceptionAction?.QueueId);
                Assert.AreEqual(1, manualReclassifyExceptionAction?.Priority);
            });

            // with name
            var exceptionPolicyName = $"{exceptionPolicyId}-ExceptionPolicyName";
            createExceptionPolicyResponse = await routerClient.UpdateExceptionPolicyAsync(
                new UpdateExceptionPolicyOptions(exceptionPolicyId)
                {
                    Name = exceptionPolicyName
                });

            Assert.NotNull(createExceptionPolicyResponse.Value);

            exceptionPolicy = createExceptionPolicyResponse.Value;

            Assert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            Assert.AreEqual(exceptionPolicyName, exceptionPolicy.Name);
        }

        #endregion Exception Policy Tests
    }
}
