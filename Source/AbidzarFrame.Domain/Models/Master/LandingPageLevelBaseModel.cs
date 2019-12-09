using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class LandingPageLevelBaseModel : BaseModel
    {        
        [DataMember()]
        [StringLength(3)]
        [Display(Name = "Level")]
        [Required]
        public string Level { get; set; }

        [DataMember()]
        [StringLength(20)]
        [Display(Name = "Kode")]
        [Required]
        public string Kode { get; set; }



    }
}
