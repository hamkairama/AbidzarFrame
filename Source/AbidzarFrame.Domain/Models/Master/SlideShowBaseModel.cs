using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class SlideShowBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Judul")]
        [Required]
        public string Judul { get; set; }

        [DataMember()]
        [StringLength(400)]
        [Display(Name = "Deskripsi")]
        public string Deskripsi { get; set; }

        [DataMember()]
        [StringLength(500)]
        [Display(Name = "FileName")]
        public string FileName { get; set; }

        [DataMember()]
        [Display(Name = "Tipe")]
        public Int32 Tipe { get; set; }

        [DataMember()]
        [Display(Name = "Posisi")]
        public Int32 Posisi { get; set; }

        [DataMember()]
        [StringLength(400)]
        [Display(Name = "PathUrl")]
        public string PathUrl { get; set; }

    }
}
