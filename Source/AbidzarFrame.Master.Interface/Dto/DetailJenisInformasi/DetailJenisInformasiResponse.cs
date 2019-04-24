using System;
using System.Runtime.Serialization;
using AbidzarFrame.Core.Model.Business;
using System.Collections.Generic;
using AbidzarFrame.Domain.Common;

namespace AbidzarFrame.Master.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class DetailJenisInformasiResponse
    {
        [DataMember()]
        public DetailJenisInformasiResult DetailJenisInformasiResult { get; set; }

        [DataMember()]
        public List<DetailJenisInformasiResult> DetailJenisInformasiResultList { get; set; }

        [DataMember()]
        public ResultStatus ResultStatus { get; set; }

        [DataMember()]
        public Int32 Count { get; set; }

        [DataMember()]
        public BusinessErrors Errors { get; set; }
    }
}
