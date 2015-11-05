namespace Dumbi.Core.Extensions
{
    using System.Linq;

    /// <summary>
    /// Extensions for string class
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Predefined list of unwanted characters
        /// </summary>
        public const string UnwantedCharacters = @",.-";

        /// <summary>
        /// Removed the given characters and returns the result
        /// </summary>
        /// <param name="source"></param>
        /// <param name="unwantedCharacters"></param>
        /// <returns></returns>
        public static string TrimUnwanted(this string source, string unwantedCharacters = UnwantedCharacters)
        {
            string trimmed = source;

            if (!string.IsNullOrWhiteSpace(source))
            {
                trimmed = source.Trim()
                                .Trim(unwantedCharacters.ToArray())
                                .Trim(); // Any further spaces after removal of chars
            }

            return trimmed;
        }

        /// <summary>
        /// Determines whether the given string is null or whitespace'd
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }
    }
}
