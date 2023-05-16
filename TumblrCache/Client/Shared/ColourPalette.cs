namespace TumblrCache.Client.Shared
{
    public static class ColourPalettes
    {
        public static readonly Dictionary<Variant, string[]> PaletteWithVariants = new()
        {
            {Variant.Navigation, new[]{ "#3cffd0 ", "#3BF86F" } },
            {Variant.Action, new[]{ "#FFC951", "#FF6200" } },
            {Variant.Danger, new[]{ "#FF2790", "#EA1C1C" } }
        };
    }
}
