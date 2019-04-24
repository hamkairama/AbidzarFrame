using System;
using System.Runtime.Serialization;
using AbidzarFrame.Core.Model.Business;
using System.Collections.Generic;
using AbidzarFrame.Domain.Common;
using AbidzarFrame.Domain.Models;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class EmailResponse
    {
        [DataMember()]
        public ResultStatus ResultStatus { get; set; }

        [DataMember()]
        public EmailResult EmailResult { get; set; }
        
        [DataMember()]
        public BusinessErrors Errors { get; set; }
    }
}
