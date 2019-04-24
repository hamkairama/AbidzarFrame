using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class AppointmentDiaryBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }

        [DataMember()]
        [Display(Name = "DateTimeScheduled")]
        [Required]
        public DateTime DateTimeScheduled { get; set; }

        [DataMember()]
        [Display(Name = "AppointmentLength")]
        [Required]
        public Int32 AppointmentLength { get; set; }

        [DataMember()]
        [Display(Name = "SomeImportantKey")]
        public Int32 SomeImportantKey { get; set; }


        [DataMember()]
        [Display(Name = "StatusENUM")]
        public Int32 StatusENUM { get; set; }
    }
}
