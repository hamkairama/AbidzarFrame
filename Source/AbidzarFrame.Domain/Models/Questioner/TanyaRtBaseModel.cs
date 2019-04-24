using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class TanyaRtBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(200)]
        [Display(Name = "Judul")]
        [Required]
        public string Judul { get; set; }

    }
}
