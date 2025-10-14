using KamWerksCardIndexCSharp.Helpers.Logging;
using Notion.Client;
using System.Net;

namespace KamWerksCardIndexCSharp.API_Notion.Helpers
{
	public class RetryWithBackoffClass
	{
		/// <summary>
		/// This function will retry a notion rate limited fetch until its passed through.
		/// </summary>
		/// <param name="action">Takes something akin to; () => client.Databases.QueryAsync(databaseId, queryParams) which will than be repeated until we are able to pass through.</param>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task<T> RetryWithBackoff<T>(Func<Task<T>> action)
		{
			int delay = 1000;

			while (true)
			{
				try
				{
					return await action();
				}
				catch (NotionApiRateLimitException ex) when (ex.StatusCode == HttpStatusCode.TooManyRequests)
				{
					int waitTime = ex.RetryAfter?.Milliseconds + 50 ?? delay;
					Logging.Log("RetryWithBackoff", "Error", $"Rate limited! Retrying in {waitTime}ms...");
					await Task.Delay(waitTime);
				}
				catch (NotionApiException ex)
				{
					Logging.Log("RetryWithBackoff", "Error", $"Notion API Exception: {ex.Message} | StatusCode: {ex.StatusCode}");
					await Task.Delay(delay);
				}
				catch (Exception ex)
				{
					Logging.Log("RetryWithBackoff", "Error", $"Unexpected exception in RetryWithBackoff: {ex.GetType().Name} — {ex.Message}");
					throw;
				}
			}
		}
	}
}