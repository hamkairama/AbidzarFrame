using System;
using AbidzarFrame.Utils;
using System.Runtime.Serialization;
using AbidzarFrame.Domain.Models;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class EmailRequest : EmailBaseModel, ISecureRequest
    {
        [DataMember()]
        public string AuthenticationToken { get; set; }        
    }
}
