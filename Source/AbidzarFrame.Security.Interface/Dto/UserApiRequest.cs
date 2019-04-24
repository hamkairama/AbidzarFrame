using System;
using System.Runtime.Serialization;
using AbidzarFrame.Utils;
using AbidzarFrame.Domain.Models;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class UserApiRequest : UserApiBaseModel, ISecureRequest
    {       
        [DataMember()]
        public string AuthenticationToken { get; set; }
    }
}
