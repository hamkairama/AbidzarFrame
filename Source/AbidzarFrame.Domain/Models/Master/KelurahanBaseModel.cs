using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class KelurahanBaseModel : BaseModel
    {
        [DataMember()]
        [Required]
        public int IdKecamatan { get; set; }

        [DataMember()]
        [StringLength(20)]
        [Display(Name = "Kode Kelurahan")]
        [Required]
        public string KodeKelurahan { get; set; }

        [DataMember()]
        [StringLength(200)]
        [Display(Name = "Nama Kelurahan")]
        [Required]
        public string NamaKelurahan { get; set; }

        [DataMember()]
        [StringLength(200)]
        [Display(Name = "Nama Kecamatan")]
        public string NamaKecamatan { get; set; }

        [DataMember()]
        public int IdKota { get; set; }

        [DataMember()]
        [StringLength(200)]
        [Display(Name = "NamaKota")]
        public string NamaKota { get; set; }

        [DataMember()]
        public int IdProvinsi { get; set; }

        [DataMember()]
        [StringLength(200)]
        [Display(Name = "NamaProvinsi")]
        public string NamaProvinsi { get; set; }

    }
}
