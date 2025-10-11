namespace KamWerksCardIndexCSharp.Helpers.Casings_And_Regexers
{
	public static class Capitalization
	{
		/// <summary>
		/// Converts input into Capitalized Case.
		/// </summary>
		/// <param name="input">The word to Capitalize in the form of for examplar 'Plays'..</param>
		/// <returns>A printed output of the full tree starting at the node.</returns>
		/// This function stems from the stack overflow user javadch.
		public static string ToCapitalizedCase(this string input)
		{
			string[] words = input.Split(' ');
			for (int i = 0; i < words.Length; i++)
			{
				words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();
			}
			return string.Join(" ", words);
		}
	}
}