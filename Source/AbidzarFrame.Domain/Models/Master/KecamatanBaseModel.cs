using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class KecamatanBaseModel : BaseModel
    {
        [DataMember()]
        [Required]
        public int IdKota { get; set; }

        [DataMember()]
        [StringLength(20)]
        [Display(Name = "Kode Kecamatan")]
        [Required]
        public string KodeKecamatan { get; set; }

        [DataMember()]
        [StringLength(200)]
        [Display(Name = "Nama Kecamatan")]
        [Required]
        public string NamaKecamatan { get; set; }
        
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
