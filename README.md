# Gmodstore Bot

A discord and web application made for content creators of gmodstore.

- Sync Roles
- Web interface
- Kick banned Gmodstore members
- add more stuff here

# Commands
``/sync <user>`` Sends the discord user a message to link their gmodstore account / addons. This will also set any roles configured in the dashboard.

# Description 
I made this because I was curious and wanted to learn more about the slashcommands added in discord.NET. This setup really only works for a single guild per instance (as of 5/2022). 

The web interface providers a simple UI to add roles based on the user's purchase scripts. It is recommended to route gmodstore webhooks (purchase, revoke, unrevoked) to your app url. Example: ``myapp.com/api/webhooks/<purchase,revoked,unrevoked>``. This will allow the bot to update the user's roles (if exists) in real time based on the action taken.

Best to run on a single container with reverse nginx proxy

# Self Host Instructions

1. Do hosting stuff
2. Go to yourwebsite.com/config
3. Enter configuration values
4. Restart bot
