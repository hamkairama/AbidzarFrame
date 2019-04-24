using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class StatusPerkawinanBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(15)]
        [Display(Name = "Status Perkawinan")]
        [Required]
        public string StatusPerkawinan { get; set; }
    }
}
