using KamWerksCardIndexCSharp.Helpers.Logging;
using Octokit;

namespace KamWerksCardIndexCSharp.API_Github.Helpers
{
	public class GetGithubRepoSubfoldersClass
	{
		/// <summary>
		/// Gets the SubFolders within a Github Repo
		/// </summary>
		/// <param name="repository">The repository in which to get Content from.</param>
		/// <param name="folderPath">The path way into the Repo to retrieve contents from.</param>
		/// <returns>A list of RepositoryContent within the repository at the folderPath.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		[Obsolete]
		public static async Task<List<RepositoryContent>> GetGithubRepoSubfolders(Repository repository, string folderPath)
		{
			try
			{
				IReadOnlyList<RepositoryContent> contents = await StartingPoint.GitHubClientPublic.Repository.Content.GetAllContents(repository.FullName.Split('/')[0], repository.FullName.Split('/')[1], folderPath);
				List<RepositoryContent> result = contents.ToList();
				return result;
			}
			catch
			{
				await Logger.Log("EstablishGithubClient", "Error", $"Failed to read {repository} at {folderPath}, ensure the folder path is valid.");
				return new List<RepositoryContent>();
			}
		}
	}
}