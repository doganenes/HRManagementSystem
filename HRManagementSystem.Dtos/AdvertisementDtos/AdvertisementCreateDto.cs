using HRManagementSystem.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Dtos
{
    public class AdvertisementCreateDto : IDto
    {
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}
