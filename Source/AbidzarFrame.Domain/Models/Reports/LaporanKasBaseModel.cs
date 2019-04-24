using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class LaporanKasBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(500)]
        [Display(Name = "Deskripsi")]
        [Required]
        public string Deskripsi { get; set; }

        [DataMember()]
        [Display(Name = "Tanggal")]
        [Required]
        public DateTime Tanggal { get; set; }

        [DataMember()]
        [Display(Name = "Total")]
        [Required]
        public decimal Total { get; set; }

        [DataMember()]
        [StringLength(2)]
        [Display(Name = "Tipe")]
        [Required]
        public string Tipe { get; set; }
    }
}
