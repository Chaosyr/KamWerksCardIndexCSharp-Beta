using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using KamWerksCardIndexCSharp.API_Notion.Helpers;
using System.Text.RegularExpressions;

namespace KamWerksCardIndexCSharp.Commands.Discord.Inscryption_Card_Specific.Debug
{
	
	public class InscryptionDebugCardFetchFormatting
	{
		/// <summary>
		/// This is the Debug Fetch system for Inscryption Cards
		/// </summary>
		/// <param name="Iterator">The Iterator so that we can ensure the message does not have issues with Images.</param>
		/// <param name="set">The set that the card is apart of.</param>
		/// <param name="name">The name of the card.</param>
		/// <param name="overload">The overloads associated with the fetch.</param>
		/// <returns>The Output message and the messageBuilder to where its called.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task<(string Output, DiscordMessageBuilder formattedOutput)> DebugFetch(int Iterator, string set, string name, string overload)
		{
			DiscordMessageBuilder messageBuilder = new();
			var output = "```";
			if (set.ToLower() == "cti")
			{
				string cardId = StartingPoint.NameToIdDict[StartingPoint.Sets["Custom TCG Inscryption"][0]].GetValueOrDefault(name);
				var linesoftext = await PageFetchClass.PageFetch(name, "CTI");
			}
			int l = 0;
			foreach (var i in linesoftext.textBlocks)
			{
				var j = i.ToString().Replace("\n", "");
				logger.Info(j);
				l += 1;
				var k = l % 2;
				if (k == 0)
				{
					output += j + "\n";
				}
				else
				{
					output += j;
				}
			}
			output += "```";
			logger.Info(linesoftext.textBlocks[1].TrimStart().Replace(" ", "%20").Replace("\n", ""));
			logger.Info(linesoftext.textBlocks[3].TrimStart().Replace(" ", "%20").Replace("\n", ""));
			var imageurl = $"https://raw.githubusercontent.com/SaxbyMod/NotionAssets/refs/heads/main/Formats/{linesoftext.textBlocks[1].TrimStart().Replace(" ", "%20").Replace("\n", "")}/Portraits/{linesoftext.textBlocks[3].TrimStart().Replace(" ", "%20").Replace("\n", "")}.png";
			HttpClient httpClient = new HttpClient();
			var file = await httpClient.GetStreamAsync(imageurl);
			messageBuilder.AddFile($"portrait_{Iterator}.png", file);
			logger.Info(imageurl);
		return (messageBuilder, output);
		}
	}
}