using DSharpPlus;
using KamWerksCardIndexCSharp.API_Discord;
using KamWerksCardIndexCSharp.API_Notion;
using KamWerksCardIndexCSharp.API_Revolt;
using KamWerksCardIndexCSharp.API_Revolt.Helpers;
using KamWerksCardIndexCSharp.Util;
using Notion.Client;
using RevoltSharp;
using System.Reflection;

namespace KamWerksCardIndexCSharp
{
	public class StartingPoint
	{
		// API Tokens
		public static string NotionApiKeyPublic = "";
		public static string DiscordApiKeyPublic = "";
		public static string RevoltApiKeyPublic = "";

		// Notion Related Const's
		public static NotionClient NotionClientPublic;
		
		// Discord Related Const's
		public static DiscordClientBuilder DiscordClientBuilderPublic;
		
		// Revolt Related Const's
		public static RevoltClient RevoltClientPublic;
		public static CommandHandler  RevoltCommandsPublic;

		// General Const's
		public static Assembly AssemblyPublic = Assembly.GetEntryAssembly();
		
		public static async Task Main()
		{
			APIKeyChecks.ValidateTokens();
			EstablishNotionClientClass.EstablishNotionClient().Wait();
			EstablishRevoltClientClass.EstablishRevoltClient().Wait();
			EstablishDiscordClientClass.EstablishDiscordClient().Wait();
			await Task.Delay(-1);
		}
	}
}