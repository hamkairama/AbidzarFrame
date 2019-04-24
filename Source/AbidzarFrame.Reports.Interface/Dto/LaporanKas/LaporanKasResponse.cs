using System;
using System.Runtime.Serialization;
using AbidzarFrame.Core.Model.Business;
using System.Collections.Generic;
using AbidzarFrame.Domain.Common;

namespace AbidzarFrame.Reports.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class LaporanKasResponse
    {
        [DataMember()]
        public LaporanKasResult LaporanKasResult { get; set; }

        [DataMember()]
        public IEnumerable<LaporanKasResult> LaporanKasResultList { get; set; }

        [DataMember()]
        public ResultStatus ResultStatus { get; set; }

        [DataMember()]
        public Int32 Count { get; set; }

        [DataMember()]
        public BusinessErrors Errors { get; set; }
    }
}
