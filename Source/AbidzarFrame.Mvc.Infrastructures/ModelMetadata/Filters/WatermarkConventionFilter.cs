﻿using System;
using System.Collections.Generic;

namespace AbidzarFrame.Mvc.Infrastructures.ModelMetadata.Filters
{
    public class WatermarkConventionFilter : IModelMetadataFilter
    {
        public void TransformMetadata(System.Web.Mvc.ModelMetadata metadata,
            IEnumerable<Attribute> attributes)
        {
            if (!string.IsNullOrEmpty(metadata.DisplayName) &&
                string.IsNullOrEmpty(metadata.Watermark))
            {
                metadata.Watermark = metadata.DisplayName + "...";
            }
        }
    }
}
