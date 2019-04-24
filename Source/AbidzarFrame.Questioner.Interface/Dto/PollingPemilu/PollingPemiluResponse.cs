using System;
using System.Runtime.Serialization;
using AbidzarFrame.Core.Model.Business;
using System.Collections.Generic;
using AbidzarFrame.Domain.Common;

namespace AbidzarFrame.Questioner.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class PollingPemiluResponse
    {
        [DataMember()]
        public PollingPemiluResult PollingPemiluResult { get; set; }

        [DataMember()]
        public IEnumerable<PollingPemiluResult> PollingPemiluResultList { get; set; }

        [DataMember()]
        public ResultStatus ResultStatus { get; set; }

        [DataMember()]
        public Int32 Count { get; set; }

        [DataMember()]
        public BusinessErrors Errors { get; set; }
    }
}
