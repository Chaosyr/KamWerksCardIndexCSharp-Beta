namespace KamWerksCardIndexCSharp.Helpers.Color_Handling.GetColorFromTypeFunctions
{
	public class GetColorFromIntClass
	{
		/// <summary>
		/// Fetches the ANSI Code associated with the int passed in, and the type given.
		/// </summary>
		/// The Table of Colors and their associated values;
		/// <list type="table">
		///     <listheader>
		///         <term>Color</term>
		///         <description>Int To Enter</description>
		///     </listheader>
		///     <item>
		///         <term>Black</term>
		///         <description>0</description>
		///     </item>
		///     <item>
		///         <term>Red</term>
		///         <description>1</description>
		///     </item>
		///     <item>
		///         <term>Green</term>
		///         <description>2</description>
		///     </item>
		///     <item>
		///         <term>Yellow</term>
		///         <description>3</description>
		///     </item>
		///     <item>
		///         <term>Blue</term>
		///         <description>4</description>
		///     </item>
		///     <item>
		///         <term>Magenta</term>
		///         <description>5</description>
		///     </item>
		///     <item>
		///         <term>Cyan</term>
		///         <description>6</description>
		///     </item>
		///     <item>
		///         <term>White</term>
		///         <description>7</description>
		///     </item>
		/// </list>
		/// The Table of Types and their associated values;
		/// <list type="table">
		///     <listheader>
		///         <term>Type</term>
		///         <description>What It Does</description>
		///         <term2>What To Enter</term2>
		///     </listheader>
		///     <item>
		///         <term>Regular</term>
		///         <description>This is essentially just the mundane colors.</description>
		///         <term2>Regular</term2>
		///     </item>
		///     <item>
		///         <term>Bold</term>
		///         <description>This will make the text and color bold and more prominent.</description>
		///         <term2>Bold</term2>
		///     </item>
		///     <item>
		///         <term>Darkened</term>
		///         <description>The opposite of Bold, it will make the text and color dark and less prominent.</description>
		///         <term2>Darkened</term2>
		///     </item>
		///     <item>
		///         <term>Italic</term>
		///         <description>This will make the text along with the color Italic.</description>
		///         <term2>Italic</term2>
		///     </item>
		///     <item>
		///         <term>Underlined</term>
		///         <description>This will make the text along with the color Underlined.</description>
		///         <term2>Underlined</term2>
		///     </item>
		///     <item>
		///         <term>Flashy</term>
		///         <description>This will make the text along with the color Blink on and off.</description>
		///         <term2>Flashy</term2>
		///     </item>
		///     <item>
		///         <term>Highlighter</term>
		///         <description>This will make the text the shade given and the background behind it the inverse of the shade specified.</description>
		///         <term2>Highlighter</term2>
		///     </item>
		///     <item>
		///         <term>Invisible</term>
		///         <description>This will make the text invisible along with the color.</description>
		///         <term2>Invisible</term2>
		///     </item>
		///     <item>
		///         <term>Strikethrough</term>
		///         <description>This will make the text look like it has a line going through it.</description>
		///         <term2>Strikethrough</term2>
		///     </item>
		///     <item>
		///         <term>Background</term>
		///         <description>This will make the background behind the text the color associated.</description>
		///         <term2>Background</term2>
		///     </item>
		/// </list>
		/// Each of the above also has a High Intensity variant which is essentially just a brighter version of the given shade, it can be called by entering `HighIntensity` before the mode your entering for example `HighIntensityRegular`.
		/// <param name="x">The integer representation for the color.</param>
		/// <param name="type">The mode the color should appear in, default is Regular.</param>
		/// <returns>The color of the List associated with the type at x.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static string GetColorFromInt(int x, string type = "Regular")
		{
			string[] typedList = type switch
			{
				"Regular" => ANSICodeLists.ColorList,
				"Bold" => ANSICodeLists.BoldColorList,
				"Darkened" => ANSICodeLists.DarkenedColorList,
				"Italic" => ANSICodeLists.ItalicColorList,
				"Underlined" => ANSICodeLists.UnderlineColorList,
				"Flashy" => ANSICodeLists.FlashyColorList,
				"Highlighter" => ANSICodeLists.HighlighterColorText,
				"Invisible" => ANSICodeLists.InvisibleColorText,
				"Strikethrough" => ANSICodeLists.StrikethroughColorText,
				"Background" => ANSICodeLists.BackgroundColorList,
				"HighIntensityRegular" => ANSICodeLists.HighIntensityColorList,
				"HighIntensityBold" => ANSICodeLists.HighIntensityBoldColorList,
				"HighIntensityDarkened" => ANSICodeLists.HighIntensityDarkenedColorList,
				"HighIntensityItalic" => ANSICodeLists.HighIntensityItalicColorList,
				"HighIntensityUnderlined" => ANSICodeLists.HighIntensityUnderlineColorList,
				"HighIntensityFlashy" => ANSICodeLists.HighIntensityFlashyColorList,
				"HighIntensityHighlighter" => ANSICodeLists.HighIntensityHighlighterColorText,
				"HighIntensityInvisible" => ANSICodeLists.HighIntensityInvisibleColorText,
				"HighIntensityStrikethrough" => ANSICodeLists.HighIntensityStrikethroughColorText,
				"HighIntensityBackground" => ANSICodeLists.BackgroundColorList,
				_ => ANSICodeLists.ColorList,
			};

			return typedList[x];
		}
	}
}