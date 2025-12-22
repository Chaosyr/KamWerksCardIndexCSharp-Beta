using KamWerksCardIndexCSharp.Helpers.GithubNodes;
using KamWerksCardIndexCSharp.Helpers.GithubNodes.Helpers;
using KamWerksCardIndexCSharp.Helpers.Logging;
using Octokit;

namespace KamWerksCardIndexCSharp.API_Github.Helpers
{
	public class GetNodeInHeirarchy
	{
		public static async Task<(bool exists, GithubNode node)> GetWhere(string where, List<RepositoryContent> contents, string path, string toEqual, int depth)
		{
			string[] pathParts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
			string rebuiltPath = string.Join("/", pathParts.Take(depth));
			Repository repo = StartingPoint.GithubRepos.FirstOrDefault(repository => repository.FullName.Equals(where));
			List<GithubNode> nodes = new List<GithubNode>();
			bool exists = false;
			GithubNode node = new GithubNode();
			try
			{
				nodes = await GetNodesClass.GetNodes(repo, contents, new GithubNode(), rebuiltPath, 0);
			}
			catch
			{
				await Logger.Log("GetWhere", "Error", $"No nodes to check with.");
			}
			
			foreach (GithubNode content in nodes)
			{
				if (content.Current.Name.Equals(toEqual) && rebuiltPath.Equals(path))
				{
					exists = true;
					node = content;
					await Logger.Log("GetWhere", "Info", $"Successfully found {toEqual} in repository {where} at {path}, url is {content.Current.Url}.");
					return (exists, node);
				}
				else if (!content.Current.Name.Equals(toEqual))
				{
					continue;
				} else if (!rebuiltPath.Equals(path))
				{
					IReadOnlyList<RepositoryContent> newContents = await StartingPoint.GitHubClientPublic.Repository.Content.GetAllContents(repo.FullName.Split('/')[0], repo.FullName.Split('/')[1], rebuiltPath);
					contents = newContents.ToList();
					return await GetWhere(where, contents, path, toEqual, depth + 1);
				}
				else if (depth == 0)
				{
					await Logger.Log("GetWhere", "Error", $"Cannot find {toEqual}");
				}
			}
			return (exists, node);
		}
	}
}