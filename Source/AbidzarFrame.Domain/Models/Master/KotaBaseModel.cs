using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class KotaBaseModel : BaseModel
    {

        [DataMember()]
        [Required]
        public int IdProvinsi { get; set; }

        [DataMember()]
        [StringLength(20)]
        [Display(Name = "KodeKota")]
        [Required]
        public string KodeKota { get; set; }

        [DataMember()]
        [StringLength(200)]
        [Display(Name = "NamaKota")]
        [Required]
        public string NamaKota { get; set; }

        [DataMember()]
        [StringLength(200)]
        [Display(Name = "NamaProvinsi")]
        public string NamaProvinsi { get; set; }
    }
}
