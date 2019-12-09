using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class ListOfValueBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(3)]
        [Display(Name = "Kode")]
        [Required]
        public string Kode { get; set; }

        [DataMember()]
        [StringLength(1000)]
        [Display(Name = "Deskripsi")]
        [Required]
        public string Deskripsi { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Value")]
        [Required]
        public string Value { get; set; }

        [DataMember()]
        [StringLength(50)]
        [Display(Name = "Group")]
        [Required]
        public string Group { get; set; }



    }
}
