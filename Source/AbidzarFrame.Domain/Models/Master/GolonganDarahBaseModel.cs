using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class GolonganDarahBaseModel:BaseModel
    {
        [DataMember()]
        [StringLength(2)]
        [Display(Name = "Golongan Darah")]
        [Required]
        public string GolonganDarah { get; set; }
    }
}
