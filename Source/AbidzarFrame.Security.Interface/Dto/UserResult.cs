using AbidzarFrame.Domain.Models;
using System;
using System.Runtime.Serialization;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class UserResult : UserBaseModel
    {
        [DataMember()]
        public string Nama { get; set; }


        [DataMember()]
        public string NamaFile { get; set; }
    }
}
