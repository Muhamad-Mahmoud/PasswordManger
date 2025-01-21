using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Encreption
    {

        public static readonly string _originalChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public static readonly string _altChars = "voYEV2n5gQytsBw60uWKTZkR41GHqd7zxIcjXpNferSMLDAJil3UhFmOb98aCP";
        public static string Encrept(string Password)
        {
            var sb = new StringBuilder();
            foreach (char c in Password)
            {
                var charIndex = _originalChars.IndexOf(c);
                sb.Append(_altChars[charIndex]);
            }
            return sb.ToString();
        }
        public static string Decrept(string Password) 
        {
            var sb = new StringBuilder();
            foreach (char c in Password)
            {
                var charIndex = _altChars.IndexOf(c);
                sb.Append(_originalChars[charIndex]);
            }
            return sb.ToString();
        }
    }
}
