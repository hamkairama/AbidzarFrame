using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class HistoricalUserLoginBaseModel : BaseModel
    {
        [DataMember()]
        [Key]
        [StringLength(15)]
        [Display(Name = "NIK")]
        [Required]
        public string Nik { get; set; }

        [DataMember()]
        [Display(Name = "Login")]
        public DateTime Login { get; set; }

        [DataMember()]
        [Display(Name = "Logout")]
        public DateTime Logout { get; set; }    
        
        [DataMember()]
        [Display(Name = "IsMobile")]
        public Boolean IsMobile { get; set; }
        

    }
}
