using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class RwBaseModel : BaseModel
    {
        [DataMember()]
        [Display(Name = "IdKelurahan")]
        [Required]
        public int IdKelurahan { get; set; }
        
        [DataMember()]
        [StringLength(20)]
        [Display(Name = "Kode Rw")]
        [Required]
        public string KodeRw { get; set; }

        [DataMember()]
        [StringLength(5)]
        [Display(Name = "No Rw")]
        [Required]
        public string NoRw { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Nama Rw")]
        [Required]
        public string NamaRw { get; set; }

        [DataMember()]
        [StringLength(16)]
        [Display(Name = "Nik")]
        [Required]
        public string Nik { get; set; }

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

        [DataMember()]
        [StringLength(500)]
        [Display(Name = "Header")]
        public string Header { get; set; }

        [DataMember()]
        [StringLength(4000)]
        [Display(Name = "Footer")]
        public string Footer { get; set; }

    }
}
