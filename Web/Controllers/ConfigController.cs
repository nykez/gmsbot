using Bot.Data.Models.ContextModels;
using Bot.Data.Repos;
using Bot.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ConfigController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppConfigService _appConfigService;
        private readonly RolesRepo _rolesRepo;

        public ConfigController(UserManager<AppUser> userManager, AppConfigService appConfigService, RolesRepo rolesRepo)
        {
            _userManager = userManager;
            _appConfigService = appConfigService;
            _rolesRepo = rolesRepo;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ConfigViewModel
            {
                Roles = await _rolesRepo.GetAllRoles(),
                Config = _appConfigService.GetConfig()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            return View(new ScriptRole());
        }
    }
}
