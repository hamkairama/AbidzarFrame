using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class UserApiBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(200)]
        [Display(Name = "Nama Api")]
        [Required]
        public string NamaApi { get; set; }

        [DataMember()]
        [StringLength(20)]
        [Display(Name = "ID User")]
        [Required]
        public string IdUser { get; set; }

        [DataMember()]
        [StringLength(200)]
        [Display(Name = "Sandi")]
        public string Sandi { get; set; }

        [DataMember()]
        [Display(Name = "Status")]
        public Boolean Status { get; set; }

    }
}
