using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using KamWerksCardIndexCSharp.Commands.Discord.Inscryption_Card_Specific.Debug;
using KamWerksCardIndexCSharp.Helpers.Casings_And_Regexers;

namespace KamWerksCardIndexCSharp.Commands.Discord.Inscryption_Card_Specific
{
	public class InscryptionCardFetch
	{
		/// <summary>
		/// The card fetch command
		/// </summary>
		/// <param name="client">The discord client</param>
		/// <param name="eventArgs">The discord message created event args.</param>
		/// <returns>Output of the discord fetch command.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task MessageSeen(DiscordClient client, MessageCreatedEventArgs eventArgs)
		{
			string message = eventArgs.Message.Content;
			(List<string> formats, List<string> fetchs, List<string> overloads, List<string> matches) = CardRegexr.CheckMatch(message).Result;
			
			for (int Iterator = 0; Iterator < matches.Count; Iterator++)
			{
				(string output, DiscordMessageBuilder messageBuilder) = ("", new DiscordMessageBuilder());
				string format = formats[Iterator];
				string set = fetchs[Iterator].Split(';')[0];
				string name = fetchs[Iterator].Split(';')[1];
				string overload = overloads[Iterator];

				if (format == "Debug")
				{
					(output, messageBuilder) = InscryptionDebugCardFetchFormatting.DebugFetch(Iterator, set, name, overload).Result;
					messageBuilder.Content = output;
					await eventArgs.Message.RespondAsync(messageBuilder);
				}
			}
		}
	}
}