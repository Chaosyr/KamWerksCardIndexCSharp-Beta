using DSharpPlus;
using KamWerksCardIndexCSharp.Helpers.Logging;

namespace KamWerksCardIndexCSharp.API_Discord
{
	public class EstablishDiscordClientClass
	{
		/// <summary>
		/// Simply sets up the Discord Client.
		/// </summary>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task EstablishDiscordClient()
		{
			Logging.Log("EstablishDiscordClient", "Info", "Setting up the Discord Client.");
			DiscordClientBuilder builder = DiscordClientBuilder.CreateDefault(StartingPoint.DiscordApiKeyPublic,
				DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents);
			StartingPoint.DiscordClientBuilderPublic =  builder;
			await StartingPoint.DiscordClientBuilderPublic.ConnectAsync();
		}
	}
}