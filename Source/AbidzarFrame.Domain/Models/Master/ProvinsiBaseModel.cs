using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class ProvinsiBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(20)]
        [Display(Name = "Kode Provinsi")]
        [Required]
        public string KodeProvinsi { get; set; }

        [DataMember()]
        [StringLength(200)]
        [Display(Name = "Nama Provinsi")]
        [Required]
        public string NamaProvinsi { get; set; }
        
    }
}
