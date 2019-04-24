using System;
using System.Runtime.Serialization;
using AbidzarFrame.Core.Model.Business;
using System.Collections.Generic;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class ActiveDirectoryResponse
    {
        [DataMember()]
        public ActiveDirectoryResult ActiveDirectoryResult { get; set; }

        [DataMember()]
        public IEnumerable<ActiveDirectoryResult> ActiveDirectoryResultList { get; set; }

        [DataMember()]
        public BusinessErrors Errors { get; set; } 
    }
}
