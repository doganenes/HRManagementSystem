using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Entity
{
    public class AppUser : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public List<AppUserRole> UserRoles { get; set; }
    }
}
