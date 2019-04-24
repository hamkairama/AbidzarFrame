using System;
using System.Runtime.Serialization;
using AbidzarFrame.Core.Model.Business;
using System.Collections.Generic;
using AbidzarFrame.Domain.Common;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class UserResponse
    {
        [DataMember()]
        public UserResult UserResult { get; set; }

        [DataMember()]
        public List<UserResult> UserResultList { get; set; }

        [DataMember()]
        public ResultStatus ResultStatus { get; set; }

        [DataMember()]
        public Int32 Count { get; set; }

        [DataMember()]
        public BusinessErrors Errors { get; set; }
    }
}
