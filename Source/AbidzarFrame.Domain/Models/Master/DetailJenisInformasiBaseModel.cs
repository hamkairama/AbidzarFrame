using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class DetailJenisInformasiBaseModel : BaseModel
    {
        [DataMember()]
        [Required]
        public int IdJenisInformasi { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Judul")]
        [Required]
        public string Judul { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Nama File")]
        public string NamaFile { get; set; }

        [DataMember()]
        [Display(Name = "Deskripsi")]
        [Required]
        public string Deskripsi { get; set; }

    }
}
