using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class PemiluBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Judul")]
        [Required]
        public string Judul { get; set; }

        [DataMember()]
        [StringLength(500)]
        [Display(Name = "FileName")]
        public string FileName { get; set; }

    }
}
