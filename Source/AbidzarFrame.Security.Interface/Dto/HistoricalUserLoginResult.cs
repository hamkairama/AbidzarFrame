using AbidzarFrame.Domain.Models;
using System;
using System.Runtime.Serialization;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class HistoricalUserLoginResult : HistoricalUserLoginBaseModel
    {
        [DataMember()]
        public int Total { get; set; }

        [DataMember()]
        public string Header { get; set; }
    }
}
