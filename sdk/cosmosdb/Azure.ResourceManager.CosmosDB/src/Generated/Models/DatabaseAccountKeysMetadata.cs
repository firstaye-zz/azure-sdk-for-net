// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.CosmosDB.Models
{
    /// <summary> The metadata related to each access key for the given Cosmos DB database account. </summary>
    public partial class DatabaseAccountKeysMetadata
    {
        /// <summary> Initializes a new instance of DatabaseAccountKeysMetadata. </summary>
        internal DatabaseAccountKeysMetadata()
        {
        }

        /// <summary> Initializes a new instance of DatabaseAccountKeysMetadata. </summary>
        /// <param name="primaryMasterKey"> The metadata related to the Primary Read-Write Key for the given Cosmos DB database account. </param>
        /// <param name="secondaryMasterKey"> The metadata related to the Secondary Read-Write Key for the given Cosmos DB database account. </param>
        /// <param name="primaryReadonlyMasterKey"> The metadata related to the Primary Read-Only Key for the given Cosmos DB database account. </param>
        /// <param name="secondaryReadonlyMasterKey"> The metadata related to the Secondary Read-Only Key for the given Cosmos DB database account. </param>
        internal DatabaseAccountKeysMetadata(AccountKeyMetadata primaryMasterKey, AccountKeyMetadata secondaryMasterKey, AccountKeyMetadata primaryReadonlyMasterKey, AccountKeyMetadata secondaryReadonlyMasterKey)
        {
            PrimaryMasterKey = primaryMasterKey;
            SecondaryMasterKey = secondaryMasterKey;
            PrimaryReadonlyMasterKey = primaryReadonlyMasterKey;
            SecondaryReadonlyMasterKey = secondaryReadonlyMasterKey;
        }

        /// <summary> The metadata related to the Primary Read-Write Key for the given Cosmos DB database account. </summary>
        internal AccountKeyMetadata PrimaryMasterKey { get; }
        /// <summary> Generation time in UTC of the key in ISO-8601 format. If the value is missing from the object, it means that the last key regeneration was triggered before 2022-06-18. </summary>
        public DateTimeOffset? PrimaryMasterKeyGeneratedOn
        {
            get => PrimaryMasterKey?.GeneratedOn;
        }

        /// <summary> The metadata related to the Secondary Read-Write Key for the given Cosmos DB database account. </summary>
        internal AccountKeyMetadata SecondaryMasterKey { get; }
        /// <summary> Generation time in UTC of the key in ISO-8601 format. If the value is missing from the object, it means that the last key regeneration was triggered before 2022-06-18. </summary>
        public DateTimeOffset? SecondaryMasterKeyGeneratedOn
        {
            get => SecondaryMasterKey?.GeneratedOn;
        }

        /// <summary> The metadata related to the Primary Read-Only Key for the given Cosmos DB database account. </summary>
        internal AccountKeyMetadata PrimaryReadonlyMasterKey { get; }
        /// <summary> Generation time in UTC of the key in ISO-8601 format. If the value is missing from the object, it means that the last key regeneration was triggered before 2022-06-18. </summary>
        public DateTimeOffset? PrimaryReadonlyMasterKeyGeneratedOn
        {
            get => PrimaryReadonlyMasterKey?.GeneratedOn;
        }

        /// <summary> The metadata related to the Secondary Read-Only Key for the given Cosmos DB database account. </summary>
        internal AccountKeyMetadata SecondaryReadonlyMasterKey { get; }
        /// <summary> Generation time in UTC of the key in ISO-8601 format. If the value is missing from the object, it means that the last key regeneration was triggered before 2022-06-18. </summary>
        public DateTimeOffset? SecondaryReadonlyMasterKeyGeneratedOn
        {
            get => SecondaryReadonlyMasterKey?.GeneratedOn;
        }
    }
}
