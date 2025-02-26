// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary> Definition of additional projections to secondary search indexes. </summary>
    public partial class SearchIndexerIndexProjections
    {
        /// <summary> Initializes a new instance of SearchIndexerIndexProjections. </summary>
        /// <param name="selectors"> A list of projections to be performed to secondary search indexes. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="selectors"/> is null. </exception>
        public SearchIndexerIndexProjections(IEnumerable<SearchIndexerIndexProjectionSelector> selectors)
        {
            Argument.AssertNotNull(selectors, nameof(selectors));

            Selectors = selectors.ToList();
        }

        /// <summary> Initializes a new instance of SearchIndexerIndexProjections. </summary>
        /// <param name="selectors"> A list of projections to be performed to secondary search indexes. </param>
        /// <param name="parameters"> A dictionary of index projection-specific configuration properties. Each name is the name of a specific property. Each value must be of a primitive type. </param>
        internal SearchIndexerIndexProjections(IList<SearchIndexerIndexProjectionSelector> selectors, SearchIndexerIndexProjectionsParameters parameters)
        {
            Selectors = selectors;
            Parameters = parameters;
        }

        /// <summary> A list of projections to be performed to secondary search indexes. </summary>
        public IList<SearchIndexerIndexProjectionSelector> Selectors { get; }
        /// <summary> A dictionary of index projection-specific configuration properties. Each name is the name of a specific property. Each value must be of a primitive type. </summary>
        public SearchIndexerIndexProjectionsParameters Parameters { get; set; }
    }
}
