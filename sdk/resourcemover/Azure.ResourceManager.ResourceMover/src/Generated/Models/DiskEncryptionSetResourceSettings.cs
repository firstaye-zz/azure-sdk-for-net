// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Defines the disk encryption set resource settings. </summary>
    public partial class DiskEncryptionSetResourceSettings : MoverResourceSettings
    {
        /// <summary> Initializes a new instance of DiskEncryptionSetResourceSettings. </summary>
        public DiskEncryptionSetResourceSettings()
        {
            ResourceType = "Microsoft.Compute/diskEncryptionSets";
        }

        /// <summary> Initializes a new instance of DiskEncryptionSetResourceSettings. </summary>
        /// <param name="resourceType"> The resource type. For example, the value can be Microsoft.Compute/virtualMachines. </param>
        /// <param name="targetResourceName"> Gets or sets the target Resource name. </param>
        /// <param name="targetResourceGroupName"> Gets or sets the target resource group name. </param>
        internal DiskEncryptionSetResourceSettings(string resourceType, string targetResourceName, string targetResourceGroupName) : base(resourceType, targetResourceName, targetResourceGroupName)
        {
            ResourceType = resourceType ?? "Microsoft.Compute/diskEncryptionSets";
        }
    }
}
