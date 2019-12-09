using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class TestimoniBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(20)]
        [Display(Name = "Nik")]
        [Required]
        public string Nik { get; set; }

        [DataMember()]
        [StringLength(500)]
        [Display(Name = "Deskripsi")]
        [Required]
        public string Deskripsi { get; set; }
    }
}
