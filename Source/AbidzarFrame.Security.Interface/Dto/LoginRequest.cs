using System;
using System.Runtime.Serialization;
using AbidzarFrame.Utils;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class LoginRequest : ISecureRequest
    {
        [DataMember()]
        public string UserId { get; set; }

        [DataMember()]
        public string Password { get; set; }

        [DataMember()]
        public string AuthenticationToken { get; set; }
    }
}
