namespace DotNetExtensions
{
    public static class BoolExtensions
    {
        public static bool HasValueAndTrue(this bool? @bool)
        {
            return @bool.HasValue && @bool.Value;
        }
    }
}
