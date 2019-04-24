using System;
using System.Runtime.Serialization;
using AbidzarFrame.Core.Model.Business;
using System.Collections.Generic;
using AbidzarFrame.Domain.Common;

namespace AbidzarFrame.Questioner.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class TanyaRtResponse
    {
        [DataMember()]
        public TanyaRtResult TanyaRtResult { get; set; }

        [DataMember()]
        public IEnumerable<TanyaRtResult> TanyaRtResultList { get; set; }

        [DataMember()]
        public ResultStatus ResultStatus { get; set; }

        [DataMember()]
        public Int32 Count { get; set; }

        [DataMember()]
        public BusinessErrors Errors { get; set; }
    }
}
