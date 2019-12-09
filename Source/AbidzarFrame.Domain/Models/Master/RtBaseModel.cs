using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class RtBaseModel : BaseModel
    {
        [DataMember()]
        [Display(Name = "IdRw")]
        [Required]
        public int IdRw { get; set; }

        [DataMember()]
        [StringLength(5)]
        [Display(Name = "No Rt")]
        [Required]
        public string NoRt { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Nama Rt")]
        [Required]
        public string NamaRt { get; set; }

        [DataMember()]
        [StringLength(16)]
        [Display(Name = "Nik")]
        [Required]
        public string Nik { get; set; }

        [DataMember()]
        [StringLength(20)]
        [Display(Name = "Kode Login")]
        [Required]
        public string KodeLogin { get; set; }

        [DataMember()]
        [StringLength(4000)]
        [Display(Name = "Photo")]
        [Required]
        public string Photo { get; set; }

        [DataMember()]
        [StringLength(4000)]
        [Display(Name = "Deskripsi")]
        [Required]
        public string Deskripsi { get; set; }

        [DataMember()]
        [StringLength(4000)]
        [Display(Name = "Quotes")]
        public string Quotes { get; set; }

        [DataMember()]
        [StringLength(4000)]
        [Display(Name = "Visi")]
        [Required]
        public string Visi { get; set; }

        [DataMember()]
        [StringLength(4000)]
        [Display(Name = "Misi")]
        [Required]
        public string Misi { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Facebook")]
        public string Facebook { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Twitter")]
        public string Twitter { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Instagram")]
        public string Instagram { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Whatsapp")]
        public string Whatsapp { get; set; }


    }
}
