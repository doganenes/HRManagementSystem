using HRManagementSystem.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Dtos
{
    public class AppRoleCreateDto : IDto
    {
        public string Definition { get; set; }
    }
}
