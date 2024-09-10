using HRManagementSystem.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {

    }
}
