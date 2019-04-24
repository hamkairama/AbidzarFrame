using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class JadwalSiskamlingBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(16)]
        [Display(Name = "Nik")]
        public string Nik { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Nama")]
        [Required]
        public string Nama { get; set; }

        [DataMember()]
        [Display(Name = "Tanggal")]
        [Required]
        public DateTime Tanggal { get; set; }

    }
}
