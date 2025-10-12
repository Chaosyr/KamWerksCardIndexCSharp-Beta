using KamWerksCardIndexCSharp.API_Notion.Helpers;

namespace KamWerksCardIndexCSharp.Data.Inscryption_Sigil_Specific
{
	public class SetupDataInscryptionSigils
	{
		/// <summary>
		/// This is the Custom TCG Inscryption's Sigil Database Id
		/// </summary>
		public static string CustomTCGInscryptionSigilsDatabaseId = "933d6166cb3f4ee89db51e4cf464f5bd";
		/// <summary>
		/// This is the Desaft's Mod (Custom TCG Inscryption)'s Sigil Database Id
		/// </summary>
		public static string DesaftsModCustomTCGInscryptionSigilsDatabaseId = "ae46b70d77e649d78a94d2fc62a886e0";
		/// <summary>
		/// This is the Inscryption Overhaul; The Final Duel Edition's Sigil Database Id
		/// </summary>
		public static string InscryptionOverhaulTheFinalDuelSigilsDatabaseId = "aa7158c620e14c1bade56faa7c09cd63";

		/// <summary>
		/// This will setup our Inscryption Sigil Data
		/// </summary>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task SetupData()
		{
			await SetupIdListClass.SetupIdLists(StartingPoint.NotionClientPublic, CustomTCGInscryptionSigilsDatabaseId);
			await SetupNameConcurrentDictionaryClass.SetupNameConcurrentDictionary(StartingPoint.NotionClientPublic, "Sigil", CustomTCGInscryptionSigilsDatabaseId);
			await SetupIdListClass.SetupIdLists(StartingPoint.NotionClientPublic, DesaftsModCustomTCGInscryptionSigilsDatabaseId);
			await SetupNameConcurrentDictionaryClass.SetupNameConcurrentDictionary(StartingPoint.NotionClientPublic, "Sigil", DesaftsModCustomTCGInscryptionSigilsDatabaseId);
			await SetupIdListClass.SetupIdLists(StartingPoint.NotionClientPublic, InscryptionOverhaulTheFinalDuelSigilsDatabaseId);
			await SetupNameConcurrentDictionaryClass.SetupNameConcurrentDictionary(StartingPoint.NotionClientPublic, "Sigil", InscryptionOverhaulTheFinalDuelSigilsDatabaseId);
		}
	}
}