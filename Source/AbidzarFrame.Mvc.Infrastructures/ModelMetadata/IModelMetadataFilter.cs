using System;
using System.Collections.Generic;

namespace AbidzarFrame.Mvc.Infrastructures.ModelMetadata
{
    public interface IModelMetadataFilter
    {
        void TransformMetadata(System.Web.Mvc.ModelMetadata metadata,
            IEnumerable<Attribute> attributes);
    }
}
