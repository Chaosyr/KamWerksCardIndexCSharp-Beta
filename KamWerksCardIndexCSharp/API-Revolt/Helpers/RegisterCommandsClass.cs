using System.Reflection;

namespace KamWerksCardIndexCSharp.API_Revolt.Helpers
{
	public class RegisterCommandsClass
	{
		/// <summary>
		/// Adds commands to the RevoltCommands system via the TypeOf system..
		/// </summary>
		/// <param name="passingInType">The class as a typeof(ClassName).</param>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task RegisterCommands(Type passingInType)
		{
			await StartingPoint.RevoltCommandsPublic.Service.AddModuleAsync(passingInType, null);
		}
	}
}