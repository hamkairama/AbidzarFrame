using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class StrukturBaseModel : BaseModel
    {
        [DataMember()]
        [Required]
        public string IdKtp { get; set; }

        [DataMember()]
        [Required]
        public int IdJabatan { get; set; }

        [DataMember()]
        [Display(Name = "AwalPeriode")]
        [Required]
        public DateTime AwalPeriode { get; set; }

        [DataMember()]
        [Display(Name = "Akhir Periode")]
        [Required]
        public DateTime AkhirPeriode { get; set; }
        
    }
}
