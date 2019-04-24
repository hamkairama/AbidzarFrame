using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class ParameterBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(15)]
        [Display(Name = "Kode")]
        [Required]
        public string Kode { get; set; }

        [DataMember()]
        [StringLength(200)]
        [Display(Name = "Deskripsi")]
        [Required]
        public string Deskripsi { get; set; }

        [DataMember()]
        [Display(Name = "Value")]
        [Required]
        public string Value { get; set; }

    }
}
