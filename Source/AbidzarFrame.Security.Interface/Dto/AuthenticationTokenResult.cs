﻿using AbidzarFrame.Domain.Models;
using System;
using System.Runtime.Serialization;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class AuthenticationTokenResult : AutentikasiTokenBaseModel
    {
    }
}
