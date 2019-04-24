using AbidzarFrame.Core.Model.Business;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AbidzarFrame.Domain.Common;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class AuthenticationTokenResponse
    {
        [DataMember()]
        public AuthenticationTokenResult AuthenticationTokenResult { get; set; }

        [DataMember()]
        public List<AuthenticationTokenResult> AuthenticationTokenResultList { get; set; }

        [DataMember()]
        public ResultStatus ResultStatus { get; set; }

        [DataMember()]
        public Int32 Count { get; set; }

        [DataMember()]
        public BusinessErrors Errors { get; set; }
    }
}
