using System;
using System.Text;
using System.Linq;

namespace base_conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // decimal to binary

            Console.Write("Decimal: ");

            int decimalNumber = int.Parse(Console.ReadLine());

            string binaryNumber = Base10_2_Base2(decimalNumber);


            // binary to decimal

            Console.WriteLine("Binary:  {0}",binaryNumber);

            decimalNumber = BinaryToDec(binaryNumber);

            Console.WriteLine("Decimal again:  {0}",decimalNumber);

            // decimal to hexa

            string hexaNumber = DecimalToHexadecimal(decimalNumber);

            Console.WriteLine("Hexadecimal:  {0}",hexaNumber);

            // decimal to base 62

            string base62String = DecimalToBase62(decimalNumber);

            Console.WriteLine("Base62:  {0}",base62String);

            // base 62 to decimal

            decimalNumber = Base62ToDecimal(base62String);

            Console.WriteLine("Decimal:  {0}",decimalNumber);
        }

        static string Base10_2_Base2(int num) 
        {
            int remainder;
            string result = string.Empty;

            while (num>0)
            {
                remainder = num % 2;

                num = num / 2;

                result = remainder.ToString() + result;
            }

            return result;
        }

        static int BinaryToDec(string input)
        {
            char[] array = input.ToCharArray();
            // Reverse since 16-8-4-2-1 not 1-2-4-8-16. 
            Array.Reverse(array);
            /*
            * [0] = 1
            * [1] = 2
            * [2] = 4
            * etc
            */
            int sum = 0; 

            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    // Method uses raising 2 to the power of the index. 
                    if (i == 0)
                    {
                        sum += 1;
                    }
                    else
                    {
                        sum += (int)Math.Pow(2, i);
                    }
                }

            }

            return sum;
        }

       public static string DecimalToHexadecimal(int dec)
        {
            if (dec < 1) return "0";

            int hex = dec;
            string hexStr = string.Empty;

            while (dec > 0)
            {
                hex = dec % 16;

                if (hex < 10)
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 48).ToString());
                else
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 55).ToString());

                dec /= 16;
            }

            return hexStr;
        }

        public static string DecimalToBase62(int num)
        {
            const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int Base = Alphabet.Length;

            var sb = new StringBuilder();
            while (num > 0)
            {
                char newChar = Alphabet.ElementAt(num % Base);
                sb.Insert(0, newChar);
                num = num / Base;
            }
            return sb.ToString();
        }

        public static int Base62ToDecimal(string str)
        {
            const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int Base = Alphabet.Length;
            
            var num = 0;
            for (var i = 0; i < str.Length; i++)
            {
                num = num * Base + Alphabet.IndexOf(str.ElementAt(i));
            }
            return num;
        }
    }
}
