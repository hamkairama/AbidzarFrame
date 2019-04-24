using System;
using AbidzarFrame.Utils;
using System.Runtime.Serialization;
using AbidzarFrame.Domain.Models;
using AbidzarFrame.Core.Model.Business;
using System.Collections.Generic;
using AbidzarFrame.Domain.Common;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class RoleMenuResponse
    {
        [DataMember()]
        public RoleMenuResult RoleMenuResult { get; set; }

        [DataMember()]
        public IEnumerable<RoleMenuResult> RoleMenuResultList { get; set; }

        [DataMember()]
        public ResultStatus ResultStatus { get; set; }

        [DataMember()]
        public Int32 Count { get; set; }

        [DataMember()]
        public BusinessErrors Errors { get; set; }
    }
}
