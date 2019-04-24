using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class JenisKegiatanBaseModel:BaseModel
    {
        [DataMember()]
        [StringLength(20)]
        [Display(Name = "Jenis Kegiatan")]
        [Required]
        public string JenisKegiatan { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Deskripsi")]
        [Required]
        public string Deskripsi { get; set; }

    }
}
