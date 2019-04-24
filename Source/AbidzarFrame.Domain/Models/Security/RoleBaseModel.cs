using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class RoleBaseModel : BaseModel
    {
        [DataMember()]
        [Key]
        [StringLength(20)]
        [Display(Name = "Id Role")]
        [Required]
        public string IdRole { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Nama Role")]
        [Required]
        public string NamaRole { get; set; }

        [DataMember()]
        [StringLength(500)]
        [Display(Name = "Deskripsi")]
        public string Deskripsi { get; set; }

        [DataMember()]
        public int? OrderRole { get; set; }
        
    }
}
