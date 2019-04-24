using AbidzarFrame.Domain.Models;
using System.Collections.Generic;

namespace AbidzarFrame.Web.Areas.Security.Models
{
    public class RoleMenuViewModel : RoleMenuBaseModel
    {
        public IEnumerable<RoleMenuBaseModel> RoleMenuBaseModelList { get; set; }

        public List<string> ArrayMenuId { get; set; }
    }
}

