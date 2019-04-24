using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class PollingPemiluBaseModel : BaseModel
    {
        [DataMember()]
        [Display(Name = "IdDetailPemilu")]
        [Required]
        public int IdDetailPemilu { get; set; }

        [DataMember()]
        [StringLength(16)]
        [Display(Name = "Nik")]
        public string Nik { get; set; }

    }
}
