using System;
using System.Runtime.Serialization;
using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Domain.Common;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class LoginResponse
    {
        [DataMember()]
        public LoginResult LoginResult { get; set; }

        [DataMember()]
        public ResultStatus ResultStatus { get; set; }

        [DataMember()]
        public Int32 Count { get; set; }

        [DataMember()]
        public BusinessErrors Errors { get; set; }
    }
}
