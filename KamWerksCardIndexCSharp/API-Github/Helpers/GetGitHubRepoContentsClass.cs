using KamWerksCardIndexCSharp.Helpers.Logging;
using Octokit;

namespace KamWerksCardIndexCSharp.API_Github.Helpers
{
	public class GetGitHubRepoContentsClass
	{
		/// <summary>
		/// This will get the surface level contents of GithubRepos defined by FillGithubReposClass.
		/// </summary>
		/// <returns>Fills out GitHubRepoContents.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task GetGithubRepoContents()
		{
			foreach (Repository repository in StartingPoint.GithubRepos)
			{
				try
				{
					IReadOnlyList<RepositoryContent> contents = await StartingPoint.GitHubClientPublic.Repository.Content.GetAllContents(repository.FullName.Split('/')[0], repository.FullName.Split('/')[1]);
					List<RepositoryContent> repoContents = contents.ToList();
					await Logger.Log("GetGithubRepoContents", "Info", $"Adding {repository.FullName} to GithubRepoContents.");
					StartingPoint.GithubRepoContents.Add(repository.FullName, repoContents);
				}
				catch
				{
					await Logger.Log("GetGithubRepoContents", "Error", $"Failed to add {repository.FullName} to GithubRepoContents, this should not occur but if it does try checking if it is a public repo and or contains content..");
				}
			}
		}
	}
}