using Bot.Data.Models.ContextModels;
using Bot.Data.Processors;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Web.Extensions;

namespace Web.Controllers
{
    public class SyncController : Controller
    {
        private readonly ILogger<SyncController> _logger;
        private readonly SyncRequestProcessor _processor;
        private readonly SignInManager<AppUser> _signInManager;

        public SyncController(ILogger<SyncController> logger, SyncRequestProcessor processor, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _processor = processor;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return Ok("Index");
        }

        [HttpGet("sync/{id}")]
        public async Task<IActionResult> Sync(Guid id)
        {
            var isValid = await _processor.IsValidRequest(id);
            if (!isValid)
                return NotFound();

            var redirectUrl = Url.Action("Complete", "Sync", new { id });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Steam", redirectUrl);
            properties.Parameters.Add("guildId", id.ToString());

            return Challenge(properties, "Steam");
        }

        [HttpGet("sync/complete")]
        public async Task<IActionResult> Complete([FromQuery] Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest("Invalid id. Please try syncing again.");

                var info = await _signInManager.GetExternalLoginInfoAsync();
                var steamId = info.Principal.GetSteamId();

                if (steamId == null)
                {
                    _logger.LogError("Could not get steamid from login.");
                    return BadRequest("Error logging in with steam. Cannot fetch id. Try again later.");
                }

                return Ok("You have been verified!");
            }
            catch (Exception)
            {
                _logger.LogError("Error logging in and syncing with steam!");
                return BadRequest("[]");
            }
        }
    }
}
