using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class UserBaseModel : BaseModel
    {
        [DataMember()]
        [Key]
        [StringLength(16)]
        [Display(Name = "NIK")]
        [Required]
        public string Nik { get; set; }

        [DataMember()]
        [StringLength(4000)]
        [Display(Name = "Sandi")]
        public string Sandi { get; set; }

        [DataMember()]
        [StringLength(200)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataMember()]
        [Display(Name = "Status")]
        public Boolean Status { get; set; }

        [DataMember()]
        [Display(Name = "KodeVerifikasi")]
        public Guid KodeVerifikasi { get; set; }        
        
        [DataMember()]
        [Display(Name = "IsMobile")]
        public Boolean IsMobile { get; set; }

        [DataMember()]
        [Display(Name = "IdRole")]
        public string IdRole { get; set; }


    }
}
