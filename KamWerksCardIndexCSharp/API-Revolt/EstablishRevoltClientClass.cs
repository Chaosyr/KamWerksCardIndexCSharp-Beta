using KamWerksCardIndexCSharp.API_Revolt.Helpers;
using KamWerksCardIndexCSharp.Helpers.Logging;
using RevoltSharp;
using RevoltSharp.Commands;
using System.Reflection;

namespace KamWerksCardIndexCSharp.API_Revolt
{
	public class EstablishRevoltClientClass
	{
		/// <summary>
		/// Simply sets up the Revolt Client.
		/// </summary>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task EstablishRevoltClient()
		{
			await Logger.Log("EstablishRevoltClient", "Info", "Setting up the Revolt Client and Starting up the Bot.");
			RevoltClient client = new RevoltClient(ClientMode.WebSocket);
			await client.LoginAsync(StartingPoint.RevoltApiKeyPublic, AccountType.Bot);
			await client.StartAsync();
			StartingPoint.RevoltClientPublic = client;
			CommandHandler Commands = new CommandHandler(StartingPoint.RevoltClientPublic);
		}
	}
}