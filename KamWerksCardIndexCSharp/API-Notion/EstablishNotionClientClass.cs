using KamWerksCardIndexCSharp.Helpers.Logging;
using Notion.Client;

namespace KamWerksCardIndexCSharp.API_Notion
{
	public class EstablishNotionClientClass
	{
		/// <summary>
		/// Simply sets up the Notion Client.
		/// </summary>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task EstablishNotionClient()
		{
			Logging.Log("EstablishNotionClient", "Info", "Setting up the Notion Client.");
			NotionClient client = NotionClientFactory.Create(new ClientOptions { AuthToken = StartingPoint.NotionApiKeyPublic });
			StartingPoint.NotionClientPublic = client;
		}
	}
}