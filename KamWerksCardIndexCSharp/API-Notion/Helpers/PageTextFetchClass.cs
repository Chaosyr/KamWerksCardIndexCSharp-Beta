using KamWerksCardIndexCSharp.Helpers.Logging;
using Notion.Client;

namespace KamWerksCardIndexCSharp.API_Notion.Helpers
{
	public class PageTextFetchClass
	{
        /// <summary>
        /// Gets the text on a card from a page based on the set and name passed in.
        /// </summary>
        /// <param name="set">The set that the card is apart of.</param>
        /// <param name="name">The name of the card.</param>
        /// <returns>The text in segments via a List of Strings.</returns>
        /// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
        public static async Task<List<string>> PageTextFetch(string name, string set)
        {
            string id = "";
            Logging.Log("PageFetchClass", "info", $"Fetching information for {name}...");
            if (set == "CTI" || set == "Custom TCG Inscryption")
            {
	            id = StartingPoint.NameToIdDict[StartingPoint.Sets["Custom TCG Inscryption"][0]].GetValueOrDefault(name);
            }
            else if (set == "DMC" || set == "Desaft's Mod (Custom TCG Inscryption)")
            {
	            id = StartingPoint.NameToIdDict[StartingPoint.Sets["Desaft's Mod (Custom TCG Inscryption)"][0]].GetValueOrDefault(name);
            }
            else if (set == "IOTFD" || set == "Inscryption Overhaul; The Final Duel")
            {
                id = StartingPoint.NameToIdDict[StartingPoint.Sets["Inscryption Overhaul; The Final Duel"][0]].GetValueOrDefault(name);
            }
            else
            {
                Logging.Log("PageFetchClass", "Error", "Set is undefined returning.");
                return new List<string>();
            }
            
            if (string.IsNullOrEmpty(id))
            {
                Logging.Log("PageFetchClass", "Error", $"Failed to find page ID for {name}.");
                return new List<string>();
            }
            
            Page page = await StartingPoint.NotionClientPublic.Pages.RetrieveAsync(id);
            var linesOfText = new List<string>();
            var blocks = await StartingPoint.NotionClientPublic.Blocks.RetrieveChildrenAsync(new BlockRetrieveChildrenRequest{BlockId = id});
            
            foreach (var block in blocks.Results)
            {
                var newblocks = await StartingPoint.NotionClientPublic.Blocks.RetrieveChildrenAsync(new BlockRetrieveChildrenRequest{BlockId = block.Id});
                foreach (var myblock in newblocks.Results)
                {
                    var newblocks2 = await StartingPoint.NotionClientPublic.Blocks.RetrieveChildrenAsync(new BlockRetrieveChildrenRequest{BlockId = myblock.Id});
                    foreach (var myblock2 in newblocks2.Results)
                    {
                        if (myblock2.GetType().Name == "ParagraphBlock")
                        {
                            var paragraph = myblock2 as ParagraphBlock;
                            var fullText = paragraph.Paragraph.RichText;
                            foreach (var line in fullText)
                            {
                                linesOfText.Add(line.PlainText);
                            }
                        }
                    }
                }
            }

            // Return the text blocks and image URLs
            return linesOfText;
        }
	}
}