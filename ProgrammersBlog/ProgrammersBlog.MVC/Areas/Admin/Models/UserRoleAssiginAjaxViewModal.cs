using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.MVC.Areas.Admin.Models
{
    public class UserRoleAssiginAjaxViewModal
    {
        public UserRoleAssignDto userRoleAssiginDto  { get; set; }
        public string UserRoleAssignPartial { get; set; }
        public UserDto UserDto { get; set; }
    }
}
