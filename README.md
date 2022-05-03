# Gmodstore Bot

A discord and web application made for content creators of gmodstore.

- Sync Roles
- Web interface
- Kick banned Gmodstore members
- add more stuff here

# Description 
I made this because I was curious and wanted to learn more about the slashcommands added in discord.NET. This setup really only works for a single guild per instance (as of 5/2022). 

The web interface providers a simple UI to add roles based on the user's purchase scripts. Its also recommended to point gmodstore webhooks (purchase, revoke, unrevoked) to your app url. Example: ``myapp.com/api/webhooks/<purchase,revoked,unrevoked>``. This will allow the bot to update the user's roles (if exists) in real time.

Best to run on a single container with reverse nginx proxy

# Self Host Instructions

1. Create ``Bot/token.json`` in Bot project dir with

```json
{
  "token": "your bot token here"
}

```
2. Switch to Web project dir and create `SteamApiKey` configuration item

  ex: ```dotnet user-secrets set "SteamApiKey" "steamapikey"``` or any other configuration methods.
  
add more stuff here wip
