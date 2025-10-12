using RevoltSharp;
using RevoltSharp.Commands;

namespace KamWerksCardIndexCSharp.API_Revolt.Helpers
{
	public class CommandHandler
	{
		/// <summary>
		/// Sets up the Command Handler utilized for Revolt.
		/// </summary>
		/// This code is provided by BuilderB.
		public CommandHandler(RevoltClient client)
		{
			Client = client;
			client.OnMessageRecieved += Client_OnMessageRecieved;
		}

		public RevoltClient Client;
		public CommandService Service = new CommandService();

		/// <summary>
		/// Scans the message we see to check if it is valid or not.
		/// </summary>
		/// <param name="msg">The message to be passed into the check.</param>
		/// <returns>A executed service with the context, argPos passed into the handler, and the services..</returns>
		/// This code is provided by BuilderB.
		private void Client_OnMessageRecieved(Message msg)
		{
			UserMessage Message = msg as UserMessage;
			if (Message == null || Message.Author.IsBot)
				return;
			int argPos = 0;
			if (!Message.HasStringPrefix("[[", ref argPos) || !Message.HasStringPrefix("{{", ref argPos) || !Message.HasStringPrefix("<<", ref argPos) || !(Message.HasCharPrefix('|', ref argPos) || Message.HasMentionPrefix(Client.CurrentUser, ref argPos)))
				return;
			CommandContext context = new CommandContext(Client, Message);
			Service.ExecuteAsync(context, argPos, null);
		}
	}
}