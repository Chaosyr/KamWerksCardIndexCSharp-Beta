namespace KamWerksCardIndexCSharp.Data
{
	public class AssociateNameToKeys
	{
		/// <summary>
		/// This function will take a set name and associate it with a list of keys and place it into the Sets List.
		/// </summary>
		/// <param name="name">The set name.</param>
		/// <param name="keys">A list of Keys in which will be associated with the set.</param>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task Associate(string name, List<string> keys)
		{
			StartingPoint.Sets.Add(name, keys);
		}
	}
}