using Bot.Data;
using Bot.Data.Models;
using Bot.Data.Models.ContextModels;
using Bot.Data.Processors;
using Bot.Data.Services;
using Bot.Http;
using Discord;
using Discord.WebSocket;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Web.Extensions;

namespace Web.Controllers
{
    public class SyncController : Controller
    {
        private readonly ILogger<SyncController> _logger;
        private readonly SyncRequestProcessor _processor;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly BotUserService _userService;

        public SyncController(ILogger<SyncController> logger, SyncRequestProcessor processor, SignInManager<AppUser> signInManager,
            BotUserService userService)
        {
            _logger = logger;
            _processor = processor;
            _signInManager = signInManager;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return Ok("[]");
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
                    return BadRequest("Invalid id. Please try syncing again with the bot.");

                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                    throw new Exception("Invalid login attempt. LoginInfo is null.");

                var steamId = info.Principal.GetSteamId();
                if (steamId == null)
                    throw new Exception("Could not get steamid from login.");

                await _userService.CreateOrUpdateUserAsync(id, steamId);

                return Ok("You have been verified!");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error logging in and syncing with steam!", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
