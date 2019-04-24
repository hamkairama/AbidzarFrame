using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class PhotoKtpBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(200)]
        [Display(Name = "Nama File")]
        [Required]
        public string NamaFile { get; set; }
    }
}
