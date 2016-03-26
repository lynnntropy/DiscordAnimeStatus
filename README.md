# DiscordAnimeStatus

####  Usage:

- Change your Discord login details in `config.yaml`.
- Set Taiga to send HTTP requests to DiscordAnimeStatus (`Settings > Sharing`)
    - Tick 'Send HTTP request'.
    - Set the URL to `http://localhost:9600/update_status`. The URL and/or port may be different if you changed it in your `config.yaml`.
- Run `DiscordAnimeStatus.exe` and keep it running.

#### Notes:

- You won't see your new status in Discord if you're logged in on the same account. **This is normal.** Everyone else will see the updated status, even though you don't.
- You don't *need* to have Discord running at the same time (on any device), though if you're here, you probably do have it running. `DiscordAnimeStatus` is based on [Discord.Net](https://github.com/RogueException/Discord.Net), making it a fully self-contained Discord client in its own right.

See the **releases** tab for binary downloads. 