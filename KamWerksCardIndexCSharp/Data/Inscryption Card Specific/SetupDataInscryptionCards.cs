using KamWerksCardIndexCSharp.API_Notion.Helpers;

namespace KamWerksCardIndexCSharp.Data.Inscryption_Card_Specific
{
	public class SetupDataInscryptionCards
	{
		/// <summary>
		/// This is the Custom TCG Inscryption's Card Database Id
		/// </summary>
		public static string CustomTCGInscryptionCardsDatabaseId = "e19c88aa75b44bfe89321bcde8dc7d9f";
		/// <summary>
		/// This is the Desaft's Mod (Custom TCG Inscryption)'s Card Database Id
		/// </summary>
		public static string DesaftsModCustomTCGInscryptionCardsDatabaseId = "1229bd3134c34f69a369c5ef830bd7a0";
		/// <summary>
		/// This is the Inscryption Overhaul; The Final Duel Edition's Card Database Id
		/// </summary>
		public static string InscryptionOverhaulTheFinalDuelCardsDatabaseId = "8918fd0a983540308f80f131655db3d3";
		
		/// <summary>
		/// This will setup our Inscryption Card Data
		/// </summary>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task SetupData()
		{
			await SetupIdListClass.SetupIdLists(StartingPoint.NotionClientPublic, CustomTCGInscryptionCardsDatabaseId);
			await SetupNameConcurrentDictionaryClass.SetupNameConcurrentDictionary(StartingPoint.NotionClientPublic, "Card", CustomTCGInscryptionCardsDatabaseId);
			await SetupIdListClass.SetupIdLists(StartingPoint.NotionClientPublic, DesaftsModCustomTCGInscryptionCardsDatabaseId);
			await SetupNameConcurrentDictionaryClass.SetupNameConcurrentDictionary(StartingPoint.NotionClientPublic, "Card", DesaftsModCustomTCGInscryptionCardsDatabaseId);
			await SetupIdListClass.SetupIdLists(StartingPoint.NotionClientPublic, InscryptionOverhaulTheFinalDuelCardsDatabaseId);
			await SetupNameConcurrentDictionaryClass.SetupNameConcurrentDictionary(StartingPoint.NotionClientPublic, "Card", InscryptionOverhaulTheFinalDuelCardsDatabaseId);
		}
	}
}