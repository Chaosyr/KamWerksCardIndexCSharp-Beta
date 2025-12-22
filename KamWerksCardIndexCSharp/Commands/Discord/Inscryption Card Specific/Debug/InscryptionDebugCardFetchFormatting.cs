using DSharpPlus.Entities;
using KamWerksCardIndexCSharp.API_Github.Helpers;
using KamWerksCardIndexCSharp.API_Notion.Helpers;
using KamWerksCardIndexCSharp.Helpers.GithubNodes;
using KamWerksCardIndexCSharp.Helpers.Logging;
using Octokit;

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
				List<RepositoryContent> CTIRepositoryContent = StartingPoint.GithubRepoContents[StartingPoint.GithubRepos.FirstOrDefault(repository => repository.FullName.Equals("Chaosyr/NotionAssets")).FullName];
				GithubNode node = GetNodeInHeirarchy.GetWhere("Chaosyr/NotionAssets", CTIRepositoryContent, "/Formats/Custom TCG Inscryption/Portraits", $"{(linesOfText[3].TrimStart().Replace("\n", "").Replace(" ", "").TrimEnd())}.png", 0).Result.node;
				imageurl = node.Current.DownloadUrl;
			}
			else if (set.ToLower() == "dmc")
			{
				string cardId = StartingPoint.NameToIdDict[StartingPoint.Sets["Desaft's Mod (Custom TCG Inscryption)"][0]].GetValueOrDefault(name);
				linesOfText = await RetryWithBackoffClass.RetryWithBackoff(() => PageTextFetchClass.PageTextFetch(name, "DMC"));
				List<RepositoryContent> CTIRepositoryContent = StartingPoint.GithubRepoContents[StartingPoint.GithubRepos.FirstOrDefault(repository => repository.FullName.Equals("Chaosyr/NotionAssets")).FullName];
				GithubNode node = GetNodeInHeirarchy.GetWhere("Chaosyr/NotionAssets", CTIRepositoryContent, "/Formats/Desafts Mod (CTI)/Portraits", $"{(linesOfText[3].TrimStart().Replace("\n", "").Replace(" ", "").TrimEnd())}.png", 0).Result.node;
				imageurl = node.Current.DownloadUrl;
			}
			else if (set.ToLower() == "iotfd")
			{
				string cardId = StartingPoint.NameToIdDict[StartingPoint.Sets["Inscryption Overhaul; The Final Duel"][0]].GetValueOrDefault(name);
				linesOfText = await RetryWithBackoffClass.RetryWithBackoff(() => PageTextFetchClass.PageTextFetch(name, "IOTFD"));
				List<RepositoryContent> CTIRepositoryContent = StartingPoint.GithubRepoContents[StartingPoint.GithubRepos.FirstOrDefault(repository => repository.FullName.Equals("Chaosyr/NotionAssets")).FullName];
				GithubNode node = GetNodeInHeirarchy.GetWhere("Chaosyr/NotionAssets", CTIRepositoryContent, "/Formats/Inscryption Overhaul - The Final Duel/Portraits", $"{(linesOfText[3].TrimStart().Replace("\n", "").TrimEnd())}.png", 0).Result.node;
				imageurl = node.Current.DownloadUrl;
			}

			int curr = 0;
			foreach (string line in linesOfText)
			{
				string newLine = line.Replace("\n", "");

				if (newLine.Contains(':'))
				{
					if (curr > 0)
						output += "\n" + newLine + "\n";
					else
						output += newLine + "\n";
				}
				else
				{
					output += newLine;
				}

				await Logger.Log("InscryptionDebugCardFetchFormatting", "Info", $"Line found; {newLine}");
				curr++;
			}
			output = output.Replace("Artist - ", "\nArtist - ");
			output += "```";

			await Logger.Log("InscryptionDebugCardFetchFormatting", "Info", imageurl);
			if (string.IsNullOrWhiteSpace(imageurl) || !Uri.IsWellFormedUriString(imageurl, UriKind.Absolute))
			{
				await Logger.Log("InscryptionDebugCardFetchFormatting", "Error", $"Invalid image URL: {imageurl}");
				return (output+=$"\nImage URL invalid, cannot fetch portrait. {imageurl}", messageBuilder);
			}
			var file = await StartingPoint.httpClientPublic.GetStreamAsync(imageurl);
			messageBuilder.AddFile($"portrait_{Iterator}.png", file);
			return (output, messageBuilder);
		}
	}
}