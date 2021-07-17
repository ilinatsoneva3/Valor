using System;
using System.Linq;

namespace IT.Valor.Core.Helpers
{
    public static class StringHelper
    {
        public static string FirstLetterToUpper(this string input)
            => input switch
            {
                null => null,
                "" => null,
                _ => input.First().ToString().ToUpper() + input.Substring(1).ToLower()
            };
    }
}
