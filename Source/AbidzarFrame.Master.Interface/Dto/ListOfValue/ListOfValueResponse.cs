using System;
using System.Runtime.Serialization;
using AbidzarFrame.Core.Model.Business;
using System.Collections.Generic;
using AbidzarFrame.Domain.Common;

namespace AbidzarFrame.Master.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class ListOfValueResponse
    {
        [DataMember()]
        public ListOfValueResult ListOfValueResult { get; set; }

        [DataMember()]
        public List<ListOfValueResult> ListOfValueResultList { get; set; }

        [DataMember()]
        public ResultStatus ResultStatus { get; set; }

        [DataMember()]
        public Int32 Count { get; set; }

        [DataMember()]
        public BusinessErrors Errors { get; set; }
    }
}
