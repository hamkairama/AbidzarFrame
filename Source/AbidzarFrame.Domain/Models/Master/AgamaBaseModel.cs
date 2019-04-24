using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class AgamaBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(15)]
        [Display(Name = "Agama")]
        [Required]
        public string NamaAgama { get; set; }
     
    }
}
