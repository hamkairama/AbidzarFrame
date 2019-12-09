using AbidzarFrame.Security.Interface.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbidzarFrame.Web.Models
{
    public class AccountViewModel
    {
    }
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Id User")]
        public string IdUser { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Sandi")]
        public string Sandi { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[Display(Name = "KodeRt")]
        //public string KodeRt { get; set; }
    }

    public class LoginViewModelAreaRw
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "KodeRt")]
        public string KodeRt { get; set; }
    }

    public class RegisterViewModel 
    {
        [Required]
        [Display(Name = "Id User")]
        public string IdUser { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Sandi")]
        public string Sandi { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Re-Sandi")]
        [Compare("Sandi")]
        public string ReSandi { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Sandi")]
        public string Sandi { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "NewSandi")]
        public string NewSandi { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Re-NewSandi")]
        [Compare("NewSandi")]
        public string ReNewSandi { get; set; }
    }

    public class GlobalVariableUser
    {
        public string IdUser { get; set; }
        public string NamaUser { get; set; }
        public MenuResponse MenuResponse { get; set; }
    }
}