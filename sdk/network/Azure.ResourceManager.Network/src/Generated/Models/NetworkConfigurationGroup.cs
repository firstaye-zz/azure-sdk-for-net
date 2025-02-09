// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> The network configuration group resource. </summary>
    public partial class NetworkConfigurationGroup
    {
        /// <summary> Initializes a new instance of NetworkConfigurationGroup. </summary>
        internal NetworkConfigurationGroup()
        {
        }

        /// <summary> Initializes a new instance of NetworkConfigurationGroup. </summary>
        /// <param name="id"> Network group ID. </param>
        /// <param name="description"> A description of the network group. </param>
        /// <param name="provisioningState"> The provisioning state of the scope assignment resource. </param>
        /// <param name="resourceGuid"> Unique identifier for this resource. </param>
        internal NetworkConfigurationGroup(string id, string description, NetworkProvisioningState? provisioningState, Guid? resourceGuid)
        {
            Id = id;
            Description = description;
            ProvisioningState = provisioningState;
            ResourceGuid = resourceGuid;
        }

        /// <summary> Network group ID. </summary>
        public string Id { get; }
        /// <summary> A description of the network group. </summary>
        public string Description { get; }
        /// <summary> The provisioning state of the scope assignment resource. </summary>
        public NetworkProvisioningState? ProvisioningState { get; }
        /// <summary> Unique identifier for this resource. </summary>
        public Guid? ResourceGuid { get; }
    }
}
