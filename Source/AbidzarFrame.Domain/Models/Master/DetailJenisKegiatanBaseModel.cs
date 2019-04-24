using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class DetailJenisKegiatanBaseModel : BaseModel
    {
        [DataMember()]
        [Required]        
        public int IdJenisKegiatan { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Nama Kegiatan")]
        [Required]
        public string NamaKegiatan { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Lokasi")]
        [Required]
        public string Lokasi { get; set; }

        [DataMember()]
        [StringLength(500)]
        [Display(Name = "Deskripsi")]
        [Required]
        public string Deskripsi { get; set; }

        [DataMember()]
        [Display(Name = "Tanggal Kegiatan")]
        [Required]
        public DateTime TanggalKegiatan { get; set; }

        [DataMember()]
        [StringLength(500)]
        [Display(Name = "Jenis Kegiatan")]
        public string JenisKegiatan { get; set; }

        [DataMember()]
        [Display(Name = "Warna Latar")]
        public string WarnaLatar { get; set; }

    }
}
