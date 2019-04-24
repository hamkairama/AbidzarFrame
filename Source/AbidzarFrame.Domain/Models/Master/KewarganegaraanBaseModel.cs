using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class KewarganegaraanBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(3)]
        [Display(Name = "Jenis Kewarganegaraan")]
        [Required]
        public string JenisKewarganegaraan { get; set; }

    }
}
