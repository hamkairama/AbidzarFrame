using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class RoleMenuBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(20)]
        [Display(Name = "Id Role")]
        [Required]
        public string IdRole { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Nama Role")]
        public string NamaRole { get; set; }

        [DataMember()]
        [Display(Name = "Id Menu")]
        [Required]
        public Int32 IdMenu { get; set; }

        [DataMember()]
        [StringLength(40)]
        [Display(Name = "Nama Menu")]
        public string NamaMenu { get; set; }

        [DataMember()]
        [Display(Name = "Parent ID")]
        public int? ParentId { get; set; }

        [DataMember()]
        [StringLength(50)]
        [Display(Name = "Nama Parent")]
        public string NamaParent { get; set; }

        [DataMember()]
        [StringLength(50)]
        [Display(Name = "Areas")]
        public string MenuArea { get; set; }

        [DataMember()]
        [StringLength(50)]
        [Display(Name = "Icon")]
        public string NamaIcon { get; set; }

        [DataMember()]
        [StringLength(50)]
        [Display(Name = "Controller")]
        public string MenuController { get; set; }

        [DataMember()]
        [Display(Name = "Have Access")]
        public bool HaveAccess { get; set; }

        [DataMember()]
        [Display(Name = "Child")]
        public int Child { get; set; }

    }
}
