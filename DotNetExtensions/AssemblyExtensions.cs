using System.IO;
using System.Reflection;

namespace DotNetExtensions
{
    public static class AssemblyExtensions
    {
        public static string ReadManifestResource(this Assembly assembly, string location)
        {
            using (var stream = assembly.GetManifestResourceStream(location))
            {
                var readString = string.Empty;
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        readString = reader.ReadToEnd();
                    }
                }
                return readString;
            }
        }

        public static bool ManifestResourceExists(this Assembly assembly, string location)
        {
            using (var stream = assembly.GetManifestResourceStream(location))
            {
                return stream != null;
            }
        }

        public static string ReadManifestResource(this string location, Assembly assembly)
        {
            return ReadManifestResource(assembly, location);
        }
    }
}