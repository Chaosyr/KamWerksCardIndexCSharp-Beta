using KamWerksCardIndexCSharp.Data.Inscryption_Card_Specific;
using KamWerksCardIndexCSharp.Data.Inscryption_Sigil_Specific;

namespace KamWerksCardIndexCSharp.Data
{
	public class FillSets
	{
		/// <summary>
		/// This simply fills the sets dictionary with the sets utilized in the bot.
		/// </summary>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task Fill()
		{
			List<string> customTcgInscryption = new List<string>() {"Key_" + SetupDataInscryptionCards.CustomTCGInscryptionCardsDatabaseId, "Key_" + SetupDataInscryptionSigils.CustomTCGInscryptionSigilsDatabaseId};
			await AssociateNameToKeys.Associate("Custom TCG Inscryption", customTcgInscryption);
			List<string> desaftsModCustomTcgInscryption = new List<string>() {"Key_" + SetupDataInscryptionCards.DesaftsModCustomTCGInscryptionCardsDatabaseId, "Key_" + SetupDataInscryptionSigils.DesaftsModCustomTCGInscryptionSigilsDatabaseId};
			await AssociateNameToKeys.Associate("Desaft's Mod (Custom TCG Inscryption)", desaftsModCustomTcgInscryption);
			List<string> inscryptionOverhaulTheFinalDuel = new List<string>() {"Key_" + SetupDataInscryptionCards.InscryptionOverhaulTheFinalDuelCardsDatabaseId, "Key_" + SetupDataInscryptionSigils.InscryptionOverhaulTheFinalDuelSigilsDatabaseId};
			await AssociateNameToKeys.Associate("Inscryption Overhaul; The Final Duel", inscryptionOverhaulTheFinalDuel);
		}
	}
}