using KamWerksCardIndexCSharp.Helpers.Logging;

namespace KamWerksCardIndexCSharp.Util
{
	public class APIKeyChecks
	{
		/// <summary>
		/// This function determines whether our tokens are valid and fetches them.
		/// </summary>
		/// <returns>A true or false based upon whether the tokens are validated, it also returns the validated Token to StartingPoint.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static bool ValidateTokens()
		{
			string notionApiKey = Environment.GetEnvironmentVariable("NOTION_API_KEY");
			if (string.IsNullOrWhiteSpace(notionApiKey))
			{
				Logging.Log("APIKeyChecks", "Error", "Hey, You missed the Notion API Key Environment Var.");
			}
			StartingPoint.NotionApiKeyPublic = notionApiKey;
			
			string discordApiKey = Environment.GetEnvironmentVariable("TUTOR TOKEN BETA");
			if (string.IsNullOrWhiteSpace(discordApiKey))
			{
				Logging.Log("APIKeyChecks", "Error", "Hey, You missed the Discord API Key Environment Var.");
			}
			StartingPoint.DiscordApiKeyPublic = discordApiKey;
			
			string revoltApiKey = Environment.GetEnvironmentVariable("REVOLT_TOKEN_BETA");
			if (string.IsNullOrWhiteSpace(revoltApiKey))
			{
				Logging.Log("APIKeyChecks", "Error", "Hey, You missed the Revolt API Key Environment Var.");
			}
			StartingPoint.RevoltApiKeyPublic = revoltApiKey;

			if (string.IsNullOrWhiteSpace(revoltApiKey) || string.IsNullOrWhiteSpace(notionApiKey) || string.IsNullOrWhiteSpace(discordApiKey))
			{
				return false;
			}
			return true;
		}
	}
}