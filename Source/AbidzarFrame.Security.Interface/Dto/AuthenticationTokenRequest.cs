using AbidzarFrame.Domain.Models;
using AbidzarFrame.Utils;
using System;
using System.Runtime.Serialization;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class AuthenticationTokenRequest : AutentikasiTokenBaseModel
    {
    }
}
