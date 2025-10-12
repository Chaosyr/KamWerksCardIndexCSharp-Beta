using KamWerksCardIndexCSharp.Helpers.Logging;
using System.Reflection;

namespace KamWerksCardIndexCSharp.API_Discord.Helpers
{
	public class MessageCommandHandler
	{
		/// <summary>
		/// A system in which will add in MessageCommands
		/// </summary>
		/// <param name="type">The class in which will be utilized to add a message based command.</param>
		/// <returns>A message based command added to the DiscordBuilder.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task MessageCommands(Type type)
		{
			StartingPoint.DiscordClientBuilderPublic.ConfigureEventHandlers(commands =>
				commands.HandleMessageCreated(async (client, eventArgs) =>
				{
					if (eventArgs.Author.IsBot || eventArgs.Author.Id == client.CurrentUser.Id)
						return;
					
					var method = type.GetMethod(
						"MessageSeen",
						BindingFlags.Public | BindingFlags.Static
					);

					if (method == null)
					{
						Logging.Log("MessageCommandHandler", "Error", $"No suitable static method 'MessageSeen' found within {type.FullName}");
						return;
					}

					var task = method.Invoke(null, new object[] { client, eventArgs }) as Task;
					
					if (task != null)
						await task;
				})
			);
		}
	}
}