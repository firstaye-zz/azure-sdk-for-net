// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    /// <summary> The CSPM monitoring for AWS offering. </summary>
    public partial class CspmMonitorAwsOffering : SecurityCenterCloudOffering
    {
        /// <summary> Initializes a new instance of CspmMonitorAwsOffering. </summary>
        public CspmMonitorAwsOffering()
        {
            OfferingType = OfferingType.CspmMonitorAws;
        }

        /// <summary> Initializes a new instance of CspmMonitorAwsOffering. </summary>
        /// <param name="offeringType"> The type of the security offering. </param>
        /// <param name="description"> The offering description. </param>
        /// <param name="nativeCloudConnection"> The native cloud connection configuration. </param>
        internal CspmMonitorAwsOffering(OfferingType offeringType, string description, CspmMonitorAwsOfferingNativeCloudConnection nativeCloudConnection) : base(offeringType, description)
        {
            NativeCloudConnection = nativeCloudConnection;
            OfferingType = offeringType;
        }

        /// <summary> The native cloud connection configuration. </summary>
        internal CspmMonitorAwsOfferingNativeCloudConnection NativeCloudConnection { get; set; }
        /// <summary> The cloud role ARN in AWS for this feature. </summary>
        public string CloudRoleArn
        {
            get => NativeCloudConnection is null ? default : NativeCloudConnection.CloudRoleArn;
            set
            {
                if (NativeCloudConnection is null)
                    NativeCloudConnection = new CspmMonitorAwsOfferingNativeCloudConnection();
                NativeCloudConnection.CloudRoleArn = value;
            }
        }
    }
}
