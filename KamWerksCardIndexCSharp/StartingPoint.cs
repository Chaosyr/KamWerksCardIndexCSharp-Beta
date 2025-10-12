using DSharpPlus;
using KamWerksCardIndexCSharp.API_Discord;
using KamWerksCardIndexCSharp.API_Notion;
using KamWerksCardIndexCSharp.API_Revolt;
using KamWerksCardIndexCSharp.API_Revolt.Helpers;
using KamWerksCardIndexCSharp.Data;
using KamWerksCardIndexCSharp.Data.Inscryption_Card_Specific;
using KamWerksCardIndexCSharp.Data.Inscryption_Sigil_Specific;
using KamWerksCardIndexCSharp.Util;
using Notion.Client;
using RevoltSharp;
using System.Collections.Concurrent;
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
		public static Dictionary<string, List<string>> IDLists = new Dictionary<string, List<string>>();
		public static Dictionary<string, List<string>> NameLists = new Dictionary<string, List<string>>();
		public static Dictionary<string, ConcurrentDictionary<string, string>> NameToIdDict = new Dictionary<string, ConcurrentDictionary<string, string>>();
		public static Dictionary<string, List<string>> Sets = new Dictionary<string, List<string>>();
		
		// Discord Related Const's
		public static DiscordClientBuilder DiscordClientBuilderPublic;
		
		// Revolt Related Const's
		public static RevoltClient RevoltClientPublic;
		public static CommandHandler  RevoltCommandsPublic;

		// General Const's
		
		public static async Task Main()
		{
			APIKeyChecks.ValidateTokens();
			EstablishNotionClientClass.EstablishNotionClient().Wait();
			SetupDataInscryptionCards.SetupData().Wait();
			SetupDataInscryptionSigils.SetupData().Wait();
			FillSets.Fill().Wait();
			EstablishRevoltClientClass.EstablishRevoltClient().Wait();
			EstablishDiscordClientClass.EstablishDiscordClient().Wait();
			await Task.Delay(-1);
		}
	}
}