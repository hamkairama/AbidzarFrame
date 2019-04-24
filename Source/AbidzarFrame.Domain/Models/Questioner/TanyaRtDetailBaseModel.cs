using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class TanyaRtDetailBaseModel : BaseModel
    {

        [DataMember()]
        public int IdTanyaRt { get; set; }

        [DataMember()]
        [StringLength(8000)]
        [Display(Name = "Deskripsi")]
        [Required]
        public string Deskripsi { get; set; }

    }
}
