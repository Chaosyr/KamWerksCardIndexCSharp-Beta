using KamWerksCardIndexCSharp.API_Github.Helpers;
using KamWerksCardIndexCSharp.Helpers.Logging;
using Octokit;

namespace KamWerksCardIndexCSharp.API_Github
{
	public class SetupKamWerksURLBasesClass
	{
		/// <summary>
		/// This sets up the KamWerksAssets
		/// </summary>
		/// <returns>KamWerksAssets added to GithubAssets.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task SetupKamWerksURLBases()
		{
			Repository repository = StartingPoint.GithubRepos.FirstOrDefault(repo => repo.FullName.Equals("Chaosyr/KamWerksPortraitsAndOtherAssets", StringComparison.OrdinalIgnoreCase));
			Dictionary<string, Dictionary<string, Dictionary<string, List<RepositoryContent>>>> SetToFormat = new Dictionary<string, Dictionary<string, Dictionary<string, List<RepositoryContent>>>>();
			
			List<RepositoryContent> contents = await GetGithubRepoSubfoldersClass.GetGithubRepoSubfolders(repository, "Formats");
			foreach (RepositoryContent content in contents)
			{
				Dictionary<string, Dictionary<string, List<RepositoryContent>>> FormatToSubInfos = new Dictionary<string, Dictionary<string, List<RepositoryContent>>>();
				Logging.Log("SetupKamWerksURLBases", "Info", $"Found contents inside Formats; {content.Name}");
				List<RepositoryContent> FormatSubContents = await GetGithubRepoSubfoldersClass.GetGithubRepoSubfolders(repository, $"Formats/{content.Name}");
				foreach (RepositoryContent subContent in FormatSubContents)
				{
					Dictionary<string, List<RepositoryContent>> SubInfoContents = new Dictionary<string, List<RepositoryContent>>();
					Logging.Log("SetupKamWerksURLBases", "Info", $"Found contents inside Formats/{content.Name}; {subContent.Name}");
					List<RepositoryContent> FormatSubSubContents = await GetGithubRepoSubfoldersClass.GetGithubRepoSubfolders(repository, $"Formats/{content.Name}/{subContent.Name}");
					foreach (RepositoryContent subSubContent in FormatSubSubContents)
					{
						Logging.Log("SetupKamWerksURLBases", "Info", $"Found contents inside Formats/{content.Name}/{subContent.Name}; {subSubContent.Name}");
						List<RepositoryContent> FormatSubSubSubContents = await GetGithubRepoSubfoldersClass.GetGithubRepoSubfolders(repository, $"Formats/{content.Name}/{subContent.Name}/{subSubContent.Name}");
						foreach (RepositoryContent subSubSubContent in FormatSubSubSubContents)
						{
							Logging.Log("SetupKamWerksURLBases", "Info", $"Found contents inside Formats/{content.Name}/{subContent.Name}/{subSubContent.Name}; {subSubSubContent.Name}");
						}
						SubInfoContents.Add(subSubContent.Name, FormatSubSubSubContents);
					}
					FormatToSubInfos.Add(subContent.Name, SubInfoContents);
				}
				SetToFormat.Add(content.Name, FormatToSubInfos);
			}
			
			StartingPoint.GitHubAssets.Add("KamWerksAssets", SetToFormat);
		}
	}
}