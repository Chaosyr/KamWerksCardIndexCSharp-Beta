using SixLabors.ImageSharp.ColorSpaces;

namespace KamWerksCardIndexCSharp.Helpers.Palletes.Helpers
{
	public class DefineShadesClass
	{
		/// <summary>
		/// Defines a palette to the Palettes dictionary.
		/// </summary>
		/// <param name="paletteName">The name of the palette to be added into the list.</param>
		/// <param name="Light">The palettes light tone.</param>
		/// <param name="Mid">The palettes mid tone.</param>
		/// <param name="Dark">The palettes dark tone.</param>
		/// <returns>A palette added into StartingPoint.Palettes.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static async Task DefineShades(string paletteName, Rgb Light, Rgb Mid, Rgb Dark)
		{
			Shade shades = new Shade(Light, Mid, Dark);
			StartingPoint.Palettes.Add(paletteName, shades);
		}
	}
}