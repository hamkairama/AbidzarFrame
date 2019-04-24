using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class PendidikanBaseModel:BaseModel
    {
        [DataMember()]
        [StringLength(20)]
        [Display(Name = "Pendidikan")]
        [Required]
        public string Pendidikan { get; set; }

    }
}
