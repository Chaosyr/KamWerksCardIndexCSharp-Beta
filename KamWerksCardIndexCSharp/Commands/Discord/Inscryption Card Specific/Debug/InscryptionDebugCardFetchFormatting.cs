using DSharpPlus.Entities;
using KamWerksCardIndexCSharp.API_Notion.Helpers;
using KamWerksCardIndexCSharp.Helpers.Logging;

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
			DiscordMessageBuilder messageBuilder = new DiscordMessageBuilder();
			string output = "```";
			List<string> linesOfText = new List<string>();
			var imageurl = "";
			if (set.ToLower() == "cti")
			{
				string cardId = StartingPoint.NameToIdDict[StartingPoint.Sets["Custom TCG Inscryption"][0]].GetValueOrDefault(name);
				linesOfText = await RetryWithBackoffClass.RetryWithBackoff(() => PageTextFetchClass.PageTextFetch(name, "CTI"));
				imageurl = "";
			} else if (set.ToLower() == "dmc")
			{
				string cardId = StartingPoint.NameToIdDict[StartingPoint.Sets["Desaft's Mod (Custom TCG Inscryption)"][0]].GetValueOrDefault(name);
				linesOfText = await RetryWithBackoffClass.RetryWithBackoff(() => PageTextFetchClass.PageTextFetch(name, "DMC"));
				imageurl = "";
			} else if (set.ToLower() == "iotfd")
			{
				string cardId = StartingPoint.NameToIdDict[StartingPoint.Sets["Inscryption Overhaul; The Final Duel"][0]].GetValueOrDefault(name);
				linesOfText = await RetryWithBackoffClass.RetryWithBackoff(() => PageTextFetchClass.PageTextFetch(name, "IOTFD"));
				imageurl = "";
			}

			int curr = 0;
			foreach (string line in linesOfText)
			{
				string newLine = line.Replace("\n", "");

				if (newLine.Contains(':')) {
					if (curr > 0)
						output += "\n" + newLine + "\n";
					else
						output += newLine + "\n";
				} else
				{
					output += newLine;
				}

				Logging.Log("InscryptionDebugCardFetchFormatting", "Info", $"Line found; {newLine}");
				curr++;
			}
			output = output.Replace("Artist - ", "\nArtist - ");
			output += "```";
			
			Logging.Log("InscryptionDebugCardFetchFormatting", "Info", imageurl);
			var file = await StartingPoint.httpClientPublic.GetStreamAsync(imageurl);
			messageBuilder.AddFile($"portrait_{Iterator}.png", file);
		return (output, messageBuilder);
		}
	}
}