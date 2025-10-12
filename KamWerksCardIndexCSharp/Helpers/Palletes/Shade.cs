using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace KamWerksCardIndexCSharp.Helpers.Palletes
{
	/// <summary>
	/// Essentially a object for the palettes.
	/// </summary>
	/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
	public class Shade
	{
		public static Rgba32 light { get; set; }
		public static Rgba32 mid { get; set; }
		public static Rgba32 dark { get; set; }

		/// <summary>
		/// Essentially sets the object for the palette
		/// </summary>
		/// <param name="Light">The palettes light tone.</param>
		/// <param name="Mid">The palettes mid tone.</param>
		/// <param name="Dark">The palettes dark tone.</param>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public Shade(Rgba32 Light, Rgba32 Mid, Rgba32 Dark)
		{
			light = Light;
			mid = Mid;
			dark = Dark;
		}
	}
}