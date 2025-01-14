// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A2A specific switch protection input.
    /// </summary>
    [Newtonsoft.Json.JsonObject("A2A")]
    public partial class A2ASwitchProtectionInput : SwitchProtectionProviderSpecificInput
    {
        /// <summary>
        /// Initializes a new instance of the A2ASwitchProtectionInput class.
        /// </summary>
        public A2ASwitchProtectionInput()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the A2ASwitchProtectionInput class.
        /// </summary>
        /// <param name="recoveryContainerId">The recovery container
        /// Id.</param>
        /// <param name="vmDisks">The list of vm disk details.</param>
        /// <param name="vmManagedDisks">The list of vm managed disk
        /// details.</param>
        /// <param name="recoveryResourceGroupId">The recovery resource group
        /// Id. Valid for V2 scenarios.</param>
        /// <param name="recoveryCloudServiceId">The recovery cloud service Id.
        /// Valid for V1 scenarios.</param>
        /// <param name="recoveryAvailabilitySetId">The recovery availability
        /// set.</param>
        /// <param name="policyId">The Policy Id.</param>
        /// <param name="recoveryBootDiagStorageAccountId">The boot diagnostic
        /// storage account.</param>
        /// <param name="recoveryAvailabilityZone">The recovery availability
        /// zone.</param>
        /// <param name="recoveryProximityPlacementGroupId">The recovery
        /// proximity placement group Id.</param>
        /// <param name="recoveryVirtualMachineScaleSetId">The virtual machine
        /// scale set id.</param>
        /// <param name="diskEncryptionInfo">The recovery disk encryption
        /// information.</param>
        public A2ASwitchProtectionInput(string recoveryContainerId = default(string), IList<A2AVmDiskInputDetails> vmDisks = default(IList<A2AVmDiskInputDetails>), IList<A2AVmManagedDiskInputDetails> vmManagedDisks = default(IList<A2AVmManagedDiskInputDetails>), string recoveryResourceGroupId = default(string), string recoveryCloudServiceId = default(string), string recoveryAvailabilitySetId = default(string), string policyId = default(string), string recoveryBootDiagStorageAccountId = default(string), string recoveryAvailabilityZone = default(string), string recoveryProximityPlacementGroupId = default(string), string recoveryVirtualMachineScaleSetId = default(string), DiskEncryptionInfo diskEncryptionInfo = default(DiskEncryptionInfo))
        {
            RecoveryContainerId = recoveryContainerId;
            VmDisks = vmDisks;
            VmManagedDisks = vmManagedDisks;
            RecoveryResourceGroupId = recoveryResourceGroupId;
            RecoveryCloudServiceId = recoveryCloudServiceId;
            RecoveryAvailabilitySetId = recoveryAvailabilitySetId;
            PolicyId = policyId;
            RecoveryBootDiagStorageAccountId = recoveryBootDiagStorageAccountId;
            RecoveryAvailabilityZone = recoveryAvailabilityZone;
            RecoveryProximityPlacementGroupId = recoveryProximityPlacementGroupId;
            RecoveryVirtualMachineScaleSetId = recoveryVirtualMachineScaleSetId;
            DiskEncryptionInfo = diskEncryptionInfo;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the recovery container Id.
        /// </summary>
        [JsonProperty(PropertyName = "recoveryContainerId")]
        public string RecoveryContainerId { get; set; }

        /// <summary>
        /// Gets or sets the list of vm disk details.
        /// </summary>
        [JsonProperty(PropertyName = "vmDisks")]
        public IList<A2AVmDiskInputDetails> VmDisks { get; set; }

        /// <summary>
        /// Gets or sets the list of vm managed disk details.
        /// </summary>
        [JsonProperty(PropertyName = "vmManagedDisks")]
        public IList<A2AVmManagedDiskInputDetails> VmManagedDisks { get; set; }

        /// <summary>
        /// Gets or sets the recovery resource group Id. Valid for V2
        /// scenarios.
        /// </summary>
        [JsonProperty(PropertyName = "recoveryResourceGroupId")]
        public string RecoveryResourceGroupId { get; set; }

        /// <summary>
        /// Gets or sets the recovery cloud service Id. Valid for V1 scenarios.
        /// </summary>
        [JsonProperty(PropertyName = "recoveryCloudServiceId")]
        public string RecoveryCloudServiceId { get; set; }

        /// <summary>
        /// Gets or sets the recovery availability set.
        /// </summary>
        [JsonProperty(PropertyName = "recoveryAvailabilitySetId")]
        public string RecoveryAvailabilitySetId { get; set; }

        /// <summary>
        /// Gets or sets the Policy Id.
        /// </summary>
        [JsonProperty(PropertyName = "policyId")]
        public string PolicyId { get; set; }

        /// <summary>
        /// Gets or sets the boot diagnostic storage account.
        /// </summary>
        [JsonProperty(PropertyName = "recoveryBootDiagStorageAccountId")]
        public string RecoveryBootDiagStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the recovery availability zone.
        /// </summary>
        [JsonProperty(PropertyName = "recoveryAvailabilityZone")]
        public string RecoveryAvailabilityZone { get; set; }

        /// <summary>
        /// Gets or sets the recovery proximity placement group Id.
        /// </summary>
        [JsonProperty(PropertyName = "recoveryProximityPlacementGroupId")]
        public string RecoveryProximityPlacementGroupId { get; set; }

        /// <summary>
        /// Gets or sets the virtual machine scale set id.
        /// </summary>
        [JsonProperty(PropertyName = "recoveryVirtualMachineScaleSetId")]
        public string RecoveryVirtualMachineScaleSetId { get; set; }

        /// <summary>
        /// Gets or sets the recovery disk encryption information.
        /// </summary>
        [JsonProperty(PropertyName = "diskEncryptionInfo")]
        public DiskEncryptionInfo DiskEncryptionInfo { get; set; }

    }
}
