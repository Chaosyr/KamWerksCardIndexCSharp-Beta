using KamWerksCardIndexCSharp.Helpers.Logging;

namespace KamWerksCardIndexCSharp.Util
{
	public class ApiKeyChecks
	{
		/// <summary>
		/// This function determines whether our tokens are valid and fetches them.
		/// </summary>
		/// <returns>A true or false based upon whether the tokens are validated, it also returns the validated Token to StartingPoint.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static bool ValidateTokens()
		{
			string? notionApiKey = Environment.GetEnvironmentVariable("NOTION_API_KEY");
			if (string.IsNullOrWhiteSpace(notionApiKey))
			{
				Logger.Log("ApiKeyChecks", "Error", "Hey, You missed the Notion API Key Environment Var.").Wait();
			}
			StartingPoint.NotionApiKeyPublic = notionApiKey;
			
			string? discordApiKey = Environment.GetEnvironmentVariable("DISCORD_TOKEN_BETA");
			if (string.IsNullOrWhiteSpace(discordApiKey))
			{
				Logger.Log("ApiKeyChecks", "Error", "Hey, You missed the Discord API Key Environment Var.").Wait();
			}
			StartingPoint.DiscordApiKeyPublic = discordApiKey;
			
			string? revoltApiKey = Environment.GetEnvironmentVariable("REVOLT_TOKEN_BETA");
			if (string.IsNullOrWhiteSpace(revoltApiKey))
			{
				Logger.Log("ApiKeyChecks", "Error", "Hey, You missed the Revolt API Key Environment Var.").Wait();
			}
			StartingPoint.RevoltApiKeyPublic = revoltApiKey;
			
			string? githubApiKey = Environment.GetEnvironmentVariable("GITHUB_API_KEY");
			if (string.IsNullOrWhiteSpace(githubApiKey))
			{
				Logger.Log("ApiKeyChecks", "Error", "Hey, You missed the Github API Key Environment Var.").Wait();
			}
			StartingPoint.GitHubApiKeyPublic = githubApiKey;

			if (string.IsNullOrWhiteSpace(revoltApiKey) || string.IsNullOrWhiteSpace(notionApiKey) || string.IsNullOrWhiteSpace(discordApiKey) || string.IsNullOrWhiteSpace(githubApiKey))
			{
				return false;
			}
			return true;
		}
	}
}