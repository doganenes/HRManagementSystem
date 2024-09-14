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

        public HomeController(IProvidedServiceService providedServiceService)
        {
            _providedServiceService = providedServiceService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _providedServiceService.GetAllAsync();
            return this.ResponseView(response);
            return View();
        }

    }
}