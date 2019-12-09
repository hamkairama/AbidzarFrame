using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class BiodataBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(20)]
        [Display(Name = "Nik")]
        [Required]
        public string Nik { get; set; }
        [DataMember()]
        [StringLength(200)]
        [Display(Name = "Gelar")]
        [Required]
        public string Gelar { get; set; }
        [DataMember()]
        [StringLength(4)]
        [Display(Name = "Tahun")]
        [Required]
        public string Tahun { get; set; }
        [DataMember()]
        [StringLength(4000)]
        [Display(Name = "Deskripsi")]
        [Required]
        public string Deskripsi { get; set; }
     
    }
}
