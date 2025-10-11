using KamWerksCardIndexCSharp.Helpers.Color_Handling;
using KamWerksCardIndexCSharp.Helpers.Color_Handling.GetColorFromTypeFunctions;

namespace KamWerksCardIndexCSharp.Helpers.Logging
{
	public class Logging
	{
		/// <summary>
		/// Simply handles logging for the bot.
		/// </summary>
		/// The table of log levels and what they are for.
		/// <list type="table">
		///     <listheader>
		///         <term>Level</term>
		///         <description>What it is used for.</description>
		///     </listheader>
		///     <item>
		///         <term>Error</term>
		///         <description>For printing errors to the console.</description>
		///     </item>
		///     <item>
		///         <term>Warning</term>
		///         <description>For printing issues that don't necessarily cause issues.</description>
		///     </item>
		///     <item>
		///         <term>Info</term>
		///         <description>For printing general info about the subject for example Verbose Logging.</description>
		///     </item>
		/// </list>
		/// <param name="from">A string representing where the issue is coming from so its easier to find the source of a issue.</param>
		/// <param name="level">The level to log with, see the above table for acceptable values.</param>
		/// <param name="content">The content of the bit you want to log.</param>
		/// <returns>The logged output</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static void Log(string from, string level, string content)
		{
			if (level == "Error")
			{
				Console.WriteLine(
					$"[{GetColorFromStringClass.GetColorFromString("Red", "HighIntensityHighlighter")}{DateTime.Now}, {from}{ANSICodeLists.ResetColor}]: {GetColorFromStringClass.GetColorFromString("Red")}{content}{ANSICodeLists.ResetColor}"
				);
			}
			if (level == "Warning")
			{
				Console.WriteLine(
					$"[{GetColorFromStringClass.GetColorFromString("Yellow", "HighIntensityHighlighter")}{DateTime.Now}, {from}{ANSICodeLists.ResetColor}]: {GetColorFromStringClass.GetColorFromString("Yellow")}{content}{ANSICodeLists.ResetColor}"
				);
			}
			if (level == "Info")
			{
				Console.WriteLine(
					$"[{GetColorFromStringClass.GetColorFromString("Magenta", "HighIntensityHighlighter")}{DateTime.Now}, {from}{ANSICodeLists.ResetColor}]: {GetColorFromStringClass.GetColorFromString("Magenta")}{content}{ANSICodeLists.ResetColor}"
				);
			}
		}
	}
}