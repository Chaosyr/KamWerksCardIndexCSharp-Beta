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
			List<string> CTI = new List<string>() {"Key_" + SetupDataInscryptionCards.CustomTCGInscryptionCardsDatabaseId, "Key_" + SetupDataInscryptionSigils.CustomTCGInscryptionSigilsDatabaseId};
			AssociateNameToKeys.Associate("Custom TCG Inscrypion", CTI);
			List<string> DMC = new List<string>() {"Key_" + SetupDataInscryptionCards.DesaftsModCustomTCGInscryptionCardsDatabaseId, "Key_" + SetupDataInscryptionSigils.DesaftsModCustomTCGInscryptionSigilsDatabaseId};
			AssociateNameToKeys.Associate("Desaft's Mod (Custom TCG Inscryption)", DMC);
			List<string> IOTFD = new List<string>() {"Key_" + SetupDataInscryptionCards.InscryptionOverhaulTheFinalDuelCardsDatabaseId, "Key_" + SetupDataInscryptionSigils.InscryptionOverhaulTheFinalDuelSigilsDatabaseId};
			AssociateNameToKeys.Associate("Inscryption Overhaul; The Final Duel", IOTFD);
		}
	}
}