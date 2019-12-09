﻿using AbidzarFrame.Utils;
using System;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using AbidzarFrame.Domain.Models;

namespace AbidzarFrame.Master.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class RtRequest : RtBaseModel, ISecureRequest
    {
        [DataMember()]
        public string AuthenticationToken { get; set; }

    }
}
