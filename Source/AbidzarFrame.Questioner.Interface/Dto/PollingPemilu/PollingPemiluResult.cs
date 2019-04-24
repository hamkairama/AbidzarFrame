using AbidzarFrame.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Questioner.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class PollingPemiluResult : PollingPemiluBaseModel
    {

        [DataMember()]
        public int Total { get; set; }

        [DataMember()]
        public string Header { get; set; }
    }
}
