using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class DokumentasiDetailJenisKegiatanBaseModel : BaseModel
    {
        [DataMember()]
        [Required]
        public int IdDetailJenisKegiatan { get; set; }

        [DataMember()]
        [StringLength(16)]
        [Display(Name = "Nama File")]
        [Required]
        public string NamaFile { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Nama Kegiatan")]
        public string NamaKegiatan { get; set; }
    }
}
