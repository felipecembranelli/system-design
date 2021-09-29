using System.Linq;
using System.Text;

namespace UrlShortener.Helpers
{
    public class ShortUrlHelperBase62
    {

        private const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static readonly int Base = Alphabet.Length;

        public static string Encode(int num)
        {
            var sb = new StringBuilder();
            while (num > 0)
            {
                char newChar = Alphabet.ElementAt(num % Base);
                sb.Insert(0, newChar);
                num = num / Base;
            }
            return sb.ToString();
        }

        // public static string Encode(int i)
        // {
        //     if (i == 0) return Alphabet[0].ToString();

        //     var s = string.Empty;

        //     while (i > 0)
        //     {  
        //         s += Alphabet[i % Base];
        //         i = i / Base;
        //     }

        //     return string.Join(string.Empty, s.Reverse());
        // }

        public static int Decode(string str)
        {
            var num = 0;
            for (var i = 0; i < str.Length; i++)
            {
                num = num * Base + Alphabet.IndexOf(str.ElementAt(i));
            }
            return num;
        }
    }
}
