using DSharpPlus;
using KamWerksCardIndexCSharp.API_Discord;
using KamWerksCardIndexCSharp.API_Github;
using KamWerksCardIndexCSharp.API_Github.Helpers;
using KamWerksCardIndexCSharp.API_Notion;
using KamWerksCardIndexCSharp.API_Revolt;
using KamWerksCardIndexCSharp.API_Revolt.Helpers;
using KamWerksCardIndexCSharp.Data;
using KamWerksCardIndexCSharp.Data.Inscryption_Card_Specific;
using KamWerksCardIndexCSharp.Data.Inscryption_Sigil_Specific;
using KamWerksCardIndexCSharp.Helpers.Palletes;
using KamWerksCardIndexCSharp.Util;
using Notion.Client;
using Octokit;
using RevoltSharp;
using System.Collections.Concurrent;

namespace KamWerksCardIndexCSharp
{
	public class StartingPoint
	{
		// API Tokens
		public static string NotionApiKeyPublic = "";
		public static string DiscordApiKeyPublic = "";
		public static string RevoltApiKeyPublic = "";
		public static string GitHubApiKeyPublic = "";

		// Notion Related Const's
		public static NotionClient NotionClientPublic;
		public static Dictionary<string, List<string>> IdLists = new Dictionary<string, List<string>>();
		public static Dictionary<string, List<string>> NameLists = new Dictionary<string, List<string>>();
		public static Dictionary<string, ConcurrentDictionary<string, string>> NameToIdDict = new Dictionary<string, ConcurrentDictionary<string, string>>();
		public static Dictionary<string, List<string>> Sets = new Dictionary<string, List<string>>();
		
		// Discord Related Const's
		public static DiscordClientBuilder DiscordClientBuilderPublic;
		
		// Revolt Related Const's
		public static RevoltClient RevoltClientPublic;
		public static CommandHandler  RevoltCommandsPublic;
		
		// Github Related Const's
		public static GitHubClient GitHubClientPublic;
		public static List<Repository> GithubRepos = new List<Repository>();
		public static Dictionary<string, List<RepositoryContent>> GithubRepoContents = new Dictionary<string, List<RepositoryContent>>();
		public static Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, List<RepositoryContent>>>>> GitHubAssets = new  Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, List<RepositoryContent>>>>>();

		// General Const's
		public static HttpClient httpClientPublic = new HttpClient();
		public static Dictionary<string, Shade> Palettes = new Dictionary<string, Shade>();
		
		public static async Task Main()
		{
			// Pre Client Connections
			APIKeyChecks.ValidateTokens();
			
			// GitHub Client Connections
			EstablishGithubClientClass.EstablishGithubClient().Wait();
			FillGithubReposClass.FillGithubRepos().Wait();
			GetGitHubRepoContentsClass.GetGithubRepoContents().Wait();
			SetupKamWerksURLBasesClass.SetupKamWerksURLBases().Wait();
			
			// Notion Client Connections
			EstablishNotionClientClass.EstablishNotionClient().Wait();
			SetupDataInscryptionCards.SetupData().Wait();
			SetupDataInscryptionSigils.SetupData().Wait();
			FillSets.Fill().Wait();
			
			// Start up the Bots
			EstablishDiscordClientClass.EstablishDiscordClient().Wait();
			EstablishRevoltClientClass.EstablishRevoltClient().Wait();
			
			// Run Indefinitely
			await Task.Delay(-1);
		}
	}
}