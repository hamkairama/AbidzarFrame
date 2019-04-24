using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class JabatanBaseModel:BaseModel
    {
        [DataMember()]
        [StringLength(20)]
        [Display(Name = "Nama Jabatan")]
        [Required]
        public string NamaJabatan { get; set; }
    }
}
