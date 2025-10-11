using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamWerksCardIndexCSharp.Helpers.Color_Handling
{
    internal class ANSICodeLists
    {
        /// <summary>
        /// Applies the color.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] ColorList = ["\u001b[0;30m", "\u001b[0;31m", "\u001b[0;32m", "\u001b[0;33m", "\u001b[0;34m", "\u001b[0;35m", "\u001b[0;36m", "\u001b[0;37m"];
        
        /// <summary>
        /// Applies the color with a Bolded or Brightened Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] BoldColorList = ["\u001b[1;30m", "\u001b[1;31m", "\u001b[1;32m", "\u001b[1;33m", "\u001b[1;34m", "\u001b[1;35m", "\u001b[1;36m", "\u001b[1;37m"];
        
        /// <summary>
        /// Applies the color with a Dulled or Darkened Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] DarkenedColorList = ["\u001b[2;30m", "\u001b[2;31m", "\u001b[2;32m", "\u001b[2;33m", "\u001b[2;34m", "\u001b[2;35m", "\u001b[2;36m", "\u001b[2;37m"];
        
        /// <summary>
        /// Applies the color with a Italic Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] ItalicColorList = ["\u001b[3;30m", "\u001b[3;31m", "\u001b[3;32m", "\u001b[3;33m", "\u001b[3;34m", "\u001b[3;35m", "\u001b[3;36m", "\u001b[3;37m"];
        
        /// <summary>
        /// Applies the color with a Underlined Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] UnderlineColorList = ["\u001b[4;30m", "\u001b[4;31m", "\u001b[4;32m", "\u001b[4;33m", "\u001b[4;34m", "\u001b[4;35m", "\u001b[4;36m", "\u001b[4;37m"];
        
        /// <summary>
        /// Applies the color with a Flashing Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] FlashyColorList = ["\u001b[5;30m", "\u001b[5;31m", "\u001b[5;32m", "\u001b[5;33m", "\u001b[5;34m", "\u001b[5;35m", "\u001b[5;36m", "\u001b[5;37m"];
        
        /// <summary>
        /// Applies the color with a Highlighted Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] HighlighterColorText = ["\u001b[7;30m", "\u001b[7;31m", "\u001b[7;32m", "\u001b[7;33m", "\u001b[7;34m", "\u001b[7;35m", "\u001b[7;36m", "\u001b[7;37m"];
        
        /// <summary>
        /// Applies the color with a Invisible Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] InvisibleColorText = ["\u001b[8;30m", "\u001b[8;31m", "\u001b[8;32m", "\u001b[8;33m", "\u001b[8;34m", "\u001b[8;35m", "\u001b[8;36m", "\u001b[8;37m"];
        
        /// <summary>
        /// Applies the color with a Strikethrough Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] StrikethroughColorText = ["\u001b[9;30m", "\u001b[9;31m", "\u001b[9;32m", "\u001b[9;33m", "\u001b[9;34m", "\u001b[9;35m", "\u001b[9;36m", "\u001b[9;37m"];
        
        /// <summary>
        /// Applies the color with to the background of the text.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] BackgroundColorList = ["\u001b[40m", "\u001b[41m", "\u001b[42m", "\u001b[43m", "\u001b[44m", "\u001b[45m", "\u001b[46m", "\u001b[47m"];
        
        /// <summary>
        /// Applies a High Intensity variant of the color to the background of the text.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] HighInstensityBsckgroundColorList = ["\u001b[0;100m", "\u001b[0;101m", "\u001b[0;102m", "\u001b[0;103m", "\u001b[0;104m", "\u001b[0;105m", "\u001b[0;106m", "\u001b[0;107m"];
        
        /// <summary>
        /// Applies a High Intensity variant of the color.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] HighIntensityColorList = ["\u001b[0;90m", "\u001b[0;91m", "\u001b[0;92m", "\u001b[0;93m", "\u001b[0;94m", "\u001b[0;95m", "\u001b[0;96m", "\u001b[0;97m"];
        
        /// <summary>
        /// Applies a High Intensity variant of the color with a Bolded or Brightened Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] HighIntensityBoldColorList = ["\u001b[1;90m", "\u001b[1;91m", "\u001b[1;92m", "\u001b[1;93m", "\u001b[1;94m", "\u001b[1;95m", "\u001b[1;96m", "\u001b[1;97m"];
        
        /// <summary>
        /// Applies a High Intensity variant of the color with a Dulled or Darkened Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] HighIntensityDarkenedColorList = ["\u001b[2;90m", "\u001b[2;91m", "\u001b[2;92m", "\u001b[2;93m", "\u001b[2;94m", "\u001b[2;95m", "\u001b[2;96m", "\u001b[2;97m"];
        
        /// <summary>
        /// Applies a High Intensity variant of the color with a Italic Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] HighIntensityItalicColorList = ["\u001b[9;90m", "\u001b[9;91m", "\u001b[9;92m", "\u001b[9;93m", "\u001b[9;94m", "\u001b[9;95m", "\u001b[9;96m", "\u001b[9;97m"];
        
        /// <summary>
        /// Applies a High Intensity variant of the color with a Underlined Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] HighIntensityUnderlineColorList = ["\u001b[4;90m", "\u001b[4;91m", "\u001b[4;92m", "\u001b[4;93m", "\u001b[4;94m", "\u001b[4;95m", "\u001b[4;96m", "\u001b[4;97m"];
        
        /// <summary>
        /// Applies a High Intensity variant of the color with a Flashing Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] HighIntensityFlashyColorList = ["\u001b[5;90m", "\u001b[5;91m", "\u001b[5;92m", "\u001b[5;93m", "\u001b[5;94m", "\u001b[5;95m", "\u001b[5;96m", "\u001b[5;97m"];
        
        /// <summary>
        /// Applies a High Intensity variant of the color with a Highlighted Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] HighIntensityHighlighterColorText = ["\u001b[7;90m", "\u001b[7;91m", "\u001b[7;92m", "\u001b[7;93m", "\u001b[7;94m", "\u001b[7;95m", "\u001b[7;96m", "\u001b[7;97m"];
        
        /// <summary>
        /// Applies a High Intensity variant of the color with a Invisible Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] HighIntensityInvisibleColorText = ["\u001b[8;90m", "\u001b[8;91m", "\u001b[8;92m", "\u001b[8;93m", "\u001b[8;94m", "\u001b[8;95m", "\u001b[8;96m", "\u001b[8;97m"];
        
        /// <summary>
        /// Applies a High Intensity variant of the color with a Strikethrough Effect applied.
        /// The colors follow this order; Black, Red, Green, Yellow, Blue, Magenta, Cyan, White
        /// </summary>
        public static readonly string[] HighIntensityStrikethroughColorText = ["\u001b[9;90m", "\u001b[9;91m", "\u001b[9;92m", "\u001b[9;93m", "\u001b[9;94m", "\u001b[9;95m", "\u001b[9;96m", "\u001b[9;97m"];
        
        /// <summary>
        /// Resets Color Back to Default
        /// </summary>
        public static readonly string ResetColor = "\u001b[0m";
    }
}
