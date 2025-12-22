using KamWerksCardIndexCSharp.Helpers.Logging;
using Octokit;

namespace KamWerksCardIndexCSharp.API_Github
{
	public class EstablishGithubClientClass
	{
		/// <summary>
		/// Establishes the Github Client.
		/// </summary>
		/// <returns>An Established Github Client</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task EstablishGithubClient()
		{
			await Logger.Log("EstablishGithubClient", "Info", "Setting up the GitHub Client.");
			GitHubClient client = new GitHubClient(new ProductHeaderValue("KamWerksCardIndex"));
			client.Credentials = new Credentials(StartingPoint.GitHubApiKeyPublic);
			StartingPoint.GitHubClientPublic = client;
		}
	}
}