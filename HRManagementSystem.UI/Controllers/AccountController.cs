using HRManagementSystem.Business.Interfaces;
using HRManagementSystem.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRManagementSystem.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;

        public AccountController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            var model = new UserCreateModel()
            {
                Genders = new SelectList(response.Data,"Id","Definition")
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            return View(model);
        }
    }
}
