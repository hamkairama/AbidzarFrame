using AbidzarFrame.Utils;
using System;
using System.Runtime.Serialization;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class ActiveDirectoryRequest : ISecureRequest
    {
        [DataMember()]
        public string AuthenticationToken { get; set; }

        [DataMember()]
        public string UserId { get; set; }

        [DataMember()]
        public string Password { get; set; }

        [DataMember()]
        public string FilterBy { get; set; }

        [DataMember()]
        public string FilterValue { get; set; }

        
    }
}
