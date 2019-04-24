using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class AutentikasiTokenBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(4000)]
        [Display(Name = "Token")]
        [Required]
        public string Token { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Aplikasi")]
        [Required]
        public string Aplikasi { get; set; }
    }
}
