using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class JenisInformasiBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(20)]
        [Display(Name = "Jenis Informasi")]
        [Required]
        public string JenisInformasi { get; set; }

    }
}
