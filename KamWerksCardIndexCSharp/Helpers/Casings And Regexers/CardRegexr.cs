using System.Text.RegularExpressions;

namespace KamWerksCardIndexCSharp.Helpers.Casings_And_Regexers
{
	public class CardRegexr
	{
		/// <summary>
		/// Checks if the regex of a passed message matches the regex of the card.
		/// </summary>
		/// <param name="message">The message to parse from.</param>
		/// <returns>A List of matched formatting, a List of fetched contents, A list of overloads, and a List of full matches.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task<(List<string> format, List<string> fetch, List<string> overloads, List<string> matches)> CheckMatch(string message)
		{
			MatchCollection matches = Regex.Matches(message, @"\[(.+?)\[(.+?)\](.*?)\]");
			List<string> formattingContents = new List<string>();
			List<string> fetchContents = new List<string>();
			List<string> overloadContents = new List<string>();
			List<string> matchedContents = new List<string>();

			foreach (Match match in matches)
			{
				formattingContents.Add(match.Groups[1].Value.Trim()); // The Formatting
				fetchContents.Add(match.Groups[2].Value.Trim()); // The Set and Name
				overloadContents.Add(match.Groups[3].Value.Trim()); // Overloads
				matchedContents.Add(match.Value.Trim()); // Full Match
			}
			return (formattingContents, fetchContents, overloadContents, matchedContents);
		}
	}
}