using System;
using System.Text;

namespace StringSplitterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string t = "IP_TV:234IsA_NiceNumber";

            Console.WriteLine(t);

            Console.WriteLine(ReadableString(t));
            
        }

        public static string ReadableString(string pInput)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < pInput.Length; i++)
            {
                if (pInput[i] == '_' || (char.IsLetter(pInput[i]) && ((i != 0 && (char.IsLower(pInput[i - 1]) && char.IsUpper(pInput[i]))) || (i != pInput.Length - 1 && (char.IsUpper(pInput[i]) && char.IsLower(pInput[i + 1])))))) sb.Append(" ");
                if (pInput[i] != '_') sb.Append(pInput[i]);
            }

            return sb.ToString();
        }
    }
}
