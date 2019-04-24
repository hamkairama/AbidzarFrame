using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class JenisPekerjaanBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Jenis Pekerjaan")]
        [Required]
        public string JenisPekerjaan { get; set; }
        
    }
}
