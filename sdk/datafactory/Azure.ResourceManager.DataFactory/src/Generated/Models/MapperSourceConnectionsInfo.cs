// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> A object which contains list of tables and connection details for a source connection. </summary>
    public partial class MapperSourceConnectionsInfo
    {
        /// <summary> Initializes a new instance of MapperSourceConnectionsInfo. </summary>
        public MapperSourceConnectionsInfo()
        {
            SourceEntities = new ChangeTrackingList<MapperTable>();
        }

        /// <summary> Initializes a new instance of MapperSourceConnectionsInfo. </summary>
        /// <param name="sourceEntities"> List of source tables for a source connection. </param>
        /// <param name="connection"> Source connection details. </param>
        internal MapperSourceConnectionsInfo(IList<MapperTable> sourceEntities, MapperConnection connection)
        {
            SourceEntities = sourceEntities;
            Connection = connection;
        }

        /// <summary> List of source tables for a source connection. </summary>
        public IList<MapperTable> SourceEntities { get; }
        /// <summary> Source connection details. </summary>
        public MapperConnection Connection { get; set; }
    }
}
