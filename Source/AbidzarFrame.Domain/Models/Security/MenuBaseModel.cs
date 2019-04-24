using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class MenuBaseModel : BaseModel
    {
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
        [Display(Name = "Icon")]
        public string NamaIcon { get; set; }

        [DataMember()]
        [StringLength(50)]
        [Display(Name = "Areas")]
        public string MenuArea { get; set; }

        [DataMember()]
        [StringLength(50)]
        [Display(Name = "Controller")]
        public string MenuController { get; set; }

        [DataMember()]
        [StringLength(50)]
        [Display(Name = "Action")]
        public string MenuAction { get; set; }

        [DataMember()]
        [StringLength(200)]
        [Display(Name = "Menu Link")]
        public string MenuLink { get; set; }
        
    }
}
