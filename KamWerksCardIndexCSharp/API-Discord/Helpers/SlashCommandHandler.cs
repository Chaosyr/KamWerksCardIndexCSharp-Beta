using DSharpPlus.Commands;
using DSharpPlus.Commands.Processors.TextCommands;
using DSharpPlus.Commands.Processors.TextCommands.Parsing;

namespace KamWerksCardIndexCSharp.API_Discord.Helpers
{
	public class SlashCommandHandler
	{
		/// <summary>
		/// Creates the Slash Command system for DSharpPlus.
		/// </summary>
		/// <param name="passingInTypes">A list of typeof(ClasName) to pass in for registering commands.</param>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task SetupSlashCommands(List<Type> passingInTypes)
		{
			StartingPoint.DiscordClientBuilderPublic.UseCommands((IServiceProvider serviceProvider, CommandsExtension extension) =>
			{
				if (passingInTypes.Count > 0)
				{
					foreach (var type in passingInTypes)
					{
						extension.AddCommands(type);
					}
				}
				TextCommandProcessor textCommandProcessor = new(new()
				{
					PrefixResolver = new DefaultPrefixResolver(true, "|").ResolvePrefixAsync,
				});

				extension.AddProcessor(textCommandProcessor);
			}, new CommandsConfiguration()
			{
				RegisterDefaultCommandProcessors = true,
			});
		}
	}
}