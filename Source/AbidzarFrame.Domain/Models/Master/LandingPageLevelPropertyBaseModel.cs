using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class LandingPageLevelPropertyBaseModel : BaseModel
    {
        [DataMember()]
        [Display(Name = "IdLandingPageLevel")]
        [Required]
        public int IdLandingPageLevel { get; set; }
        
        [DataMember()]
        [StringLength(1000)]
        [Display(Name = "NHeader")]
        [Required]
        public string Header { get; set; }
        


    }
}
