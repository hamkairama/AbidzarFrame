using AbidzarFrame.Utils;
using System;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using AbidzarFrame.Domain.Models;

namespace AbidzarFrame.Questioner.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class PollingPemiluRequest : PollingPemiluBaseModel, ISecureRequest
    {
        [DataMember()]
        public string AuthenticationToken { get; set; }

        [DataMember()]
        public int IdPemilu { get; set; }

    }
}
