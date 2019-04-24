using AbidzarFrame.Domain.Models;
using System.Collections.Generic;

namespace AbidzarFrame.Web.Models
{
    public partial class MenuViewModel : MenuBaseModel
    {
        public MenuViewModel()
        {
            ChildMenu = new List<MenuViewModel>();
        }

        public string ActiveClass { get; set; }
        public List<MenuViewModel> ChildMenu { get; set; }
    }
}