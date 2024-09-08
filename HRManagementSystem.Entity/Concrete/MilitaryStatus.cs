using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Entity.Concrete
{
    public class MilitaryStatus : BaseEntity
    {
        public string Definition { get; set; }
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
