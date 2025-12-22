using KamWerksCardIndexCSharp.Helpers.Logging;
using Notion.Client;
using System.Collections.Concurrent;

namespace KamWerksCardIndexCSharp.API_Notion.Helpers
{
	public class SetupNameConcurrentDictionaryClass
	{
		/// <summary>
		/// This will create and set up the Name Lists for the passed in databaseId as well as a Dictionary of Name -> Id.
		/// </summary>
		/// <param name="client">The Notion Client.</param>
		/// <param name="itemType">The type of item, so that we can get the proper item name and avoid a null case, in present valid items are Sigil and Card.</param>
		/// <param name="databaseId">The notion database ID in which will be checked through.</param>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task SetupNameConcurrentDictionary(NotionClient client, string itemType, string databaseId)
		{
			ConcurrentDictionary<string, string> pageNameDict = new ConcurrentDictionary<string, string>();
			List<string> pageIds = StartingPoint.IdLists[$"Key_{databaseId}"];
			StartingPoint.NameLists.Add($"Key_{databaseId}", new List<string>());

			var tasks = pageIds.Select(async id =>
			{
				var page = await RetryWithBackoffClass.RetryWithBackoff(() => client.Pages.RetrieveAsync(id));

				if ((itemType == "Card" || itemType == "Sigil") && page.Properties.TryGetValue("Internal Name", out PropertyValue nameValue) && nameValue is TitlePropertyValue titleProperty)
				{
					string nameText = titleProperty.Title.FirstOrDefault()?.PlainText ?? "Unnamed";
					if (StartingPoint.NameLists[$"Key_{databaseId}"] != null)
					{
						StartingPoint.NameLists[$"Key_{databaseId}"].Add(nameText);
					}
					pageNameDict[nameText] = id;
					await Logger.Log("SetupNameConcurrentDictionaryClass", "Info", $"Retrieved {itemType} Name: {nameText} (ID: {id})");
				}
				else
				{
					await Logger.Log("SetupNameConccurentDictionary", "Warning", $"Failed to retrieve {itemType} Name for ID: {id}");
				}
			}).ToList();
			
			await Task.WhenAll(tasks);
			StartingPoint.NameToIdDict.Add($"Key_{databaseId}", pageNameDict);
		}
	}
}