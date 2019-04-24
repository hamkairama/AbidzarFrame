using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class JenisKelaminBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(1)]
        [Display(Name = "Jenis Kelamin")]
        [Required]
        public string JenisKelamin { get; set; }

        [DataMember()]
        [StringLength(20)]
        [Display(Name = "Deskripsi")]
        [Required]
        public string Deskripsi { get; set; }
       
    }
}
