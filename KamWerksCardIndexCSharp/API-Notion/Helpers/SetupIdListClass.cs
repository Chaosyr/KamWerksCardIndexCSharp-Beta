using KamWerksCardIndexCSharp.Helpers.Logging;
using Notion.Client;

namespace KamWerksCardIndexCSharp.API_Notion.Helpers
{
	public class SetupIdListClass
	{
		/// <summary>
		/// This will create and set up the Id Lists for the passed in databaseId.
		/// </summary>
		/// <param name="client">The Notion Client.</param>
		/// <param name="databaseId">The notion database ID in which will be checked through.</param>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task SetupIdLists(NotionClient client, string databaseId)
		{
			List<string> pageIds = new List<string>();
			string? nextCursor = null;

			do
			{
				var queryParams = new DatabasesQueryParameters
				{
					StartCursor = nextCursor,
					PageSize = 100
				};
				var response = await RetryWithBackoffClass.RetryWithBackoff(() => client.Databases.QueryAsync(databaseId, queryParams));
				await Logger.Log("SetupIdLists", "Info", $"Received {response.Results.Count} results for database {databaseId}");
				pageIds.AddRange(response.Results.Select(page => page.Id));
				nextCursor = response.HasMore ? response.NextCursor : null;
			} while (!string.IsNullOrEmpty(nextCursor));
			
			StartingPoint.IdLists.Add($"Key_{databaseId}", pageIds);
		}
	}
}