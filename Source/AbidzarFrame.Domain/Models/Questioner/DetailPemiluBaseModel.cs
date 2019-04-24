using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class DetailPemiluBaseModel : BaseModel
    {
        [DataMember()]
        [Display(Name = "IdPemilu")]
        [Required]
        public int IdPemilu { get; set; }

        [DataMember()]
        [Display(Name = "NoUrut")]
        public int NoUrut { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Kandidat")]
        [Required]
        public string Kandidat { get; set; }

        [DataMember()]
        [StringLength(500)]
        [Display(Name = "FileName")]
        public string FileName { get; set; }

    }
}
