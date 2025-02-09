// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.OperationalInsights.Models
{
    /// <summary> The name of a metric. </summary>
    public partial class OperationalInsightsMetricName
    {
        /// <summary> Initializes a new instance of OperationalInsightsMetricName. </summary>
        internal OperationalInsightsMetricName()
        {
        }

        /// <summary> Initializes a new instance of OperationalInsightsMetricName. </summary>
        /// <param name="value"> The system name of the metric. </param>
        /// <param name="localizedValue"> The localized name of the metric. </param>
        internal OperationalInsightsMetricName(string value, string localizedValue)
        {
            Value = value;
            LocalizedValue = localizedValue;
        }

        /// <summary> The system name of the metric. </summary>
        public string Value { get; }
        /// <summary> The localized name of the metric. </summary>
        public string LocalizedValue { get; }
    }
}
