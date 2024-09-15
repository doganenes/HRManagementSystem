using HRManagementSystem.Business.Interfaces;
using HRManagementSystem.UI.Extensions;
using HRManagementSystem.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HRManagementSystem.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService _providedServiceService;
        private readonly IAdvertisementService _advertisementService;

        public HomeController(IProvidedServiceService providedServiceService, IAdvertisementService advertisementService)
        {
            _providedServiceService = providedServiceService;
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _providedServiceService.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> HumanResources()
        {
            var response = await _advertisementService.GetActiveAsync();
            return this.ResponseView(response);
        }

    }
}