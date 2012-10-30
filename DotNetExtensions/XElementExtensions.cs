using System.Xml.Linq;

namespace DotNetExtensions
{
    public static class XElementExtensions
    {
        public static string TryGetString(this XElement element,string defaultTo = null)
        {
            if (element == null)
            {
                return defaultTo;
            }
            return element.Value;
        }

        public static int TryGetInt(this XElement element,int defaultTo = -1)
        {
            if (element == null)
            {
                return defaultTo;
            }
            return element.Value.ToInt(defaultTo);
        }
    }
}