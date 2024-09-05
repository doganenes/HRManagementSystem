using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Entity
{
    public class AppRole : BaseEntity
    {
        public string Definition { get; set; }
        public List<AppUserRole> UserRoles { get; set; }
    }
}
