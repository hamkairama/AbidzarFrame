using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Domain.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class RoleResponse
    {
        [DataMember()]
        public RoleResult RoleResult { get; set; }

        [DataMember()]
        public IEnumerable<RoleResult> RoleResultList { get; set; }

        [DataMember()]
        public ResultStatus ResultStatus { get; set; }

        [DataMember()]
        public Int32 Count { get; set; }

        [DataMember()]
        public BusinessErrors Errors { get; set; }
    }
}
