using Microsoft.AspNetCore.Identity;

namespace Bot.Data.Models.ContextModels;

public class AppUser: IdentityUser
{
    public string? SteamId { get; set; }
}

