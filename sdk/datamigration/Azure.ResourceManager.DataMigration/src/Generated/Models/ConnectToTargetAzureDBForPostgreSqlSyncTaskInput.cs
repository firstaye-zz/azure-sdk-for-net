// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.DataMigration.Models
{
    /// <summary> Input for the task that validates connection to Azure Database for PostgreSQL and target server requirements. </summary>
    public partial class ConnectToTargetAzureDBForPostgreSqlSyncTaskInput
    {
        /// <summary> Initializes a new instance of ConnectToTargetAzureDBForPostgreSqlSyncTaskInput. </summary>
        /// <param name="sourceConnectionInfo"> Connection information for source PostgreSQL server. </param>
        /// <param name="targetConnectionInfo"> Connection information for target Azure Database for PostgreSQL server. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceConnectionInfo"/> or <paramref name="targetConnectionInfo"/> is null. </exception>
        public ConnectToTargetAzureDBForPostgreSqlSyncTaskInput(PostgreSqlConnectionInfo sourceConnectionInfo, PostgreSqlConnectionInfo targetConnectionInfo)
        {
            Argument.AssertNotNull(sourceConnectionInfo, nameof(sourceConnectionInfo));
            Argument.AssertNotNull(targetConnectionInfo, nameof(targetConnectionInfo));

            SourceConnectionInfo = sourceConnectionInfo;
            TargetConnectionInfo = targetConnectionInfo;
        }

        /// <summary> Connection information for source PostgreSQL server. </summary>
        public PostgreSqlConnectionInfo SourceConnectionInfo { get; set; }
        /// <summary> Connection information for target Azure Database for PostgreSQL server. </summary>
        public PostgreSqlConnectionInfo TargetConnectionInfo { get; set; }
    }
}
