using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using ProgressSharp.Extensions;

namespace ProgressSharp.Helpers
{
    public static class StringHelpers
    {
        public static string GenerateName()
        {
            var strBuilder = new StringBuilder();

            var parts = new []
            {
                "br|cr|dr|fr|gr|j|kr|l|m|n|pr||||r|sh|tr|v|wh|x|y|z".Split("|"),
                "a|a|e|e|i|i|o|o|u|u|ae|ie|oo|ou".Split("|"),
                "b|ck|d|g|k|m|n|p|t|v|x|z".Split("|")
            };

            for (var i = 0; i < 6; i++)
            {
                var stringPart = parts[i % 3];
                var getRandom = stringPart.Random();
                strBuilder.Append(getRandom);
            }

            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(strBuilder.ToString().Trim());
        }
        
        public static string ActName(int value)
        {
            return value == 0 ? "Prologue" : $"Act {Roman.ToRoman(value)}";
        }

        public static string Plural(string value)
        {
            if (value.EndsWith("ch")) return $"{value}es";
            if (value.EndsWith("x")) return $"{value}es";
            if (value.EndsWith("s")) return $"{value}es";
            if (value.EndsWith("sh")) return $"{value}es";

            if (value.EndsWith("y")) return $"{value.Substring(0, value.Length - 1)}ies";
            if (value.EndsWith("f")) return $"{value.Substring(0, value.Length - 1)}ves";
            if (value.EndsWith("us")) return $"{value.Substring(0, value.Length - 2)}i";
            
            if (value.EndsWith("man")) return $"{value.Substring(0, value.Length - 2)}en";
            if (value.EndsWith("Man")) return $"{value.Substring(0, value.Length - 2)}en";
            
            return $"{value}s";
        }

        public static string Indefinite(string subject, int qty)
        {
            if (qty != 1) return $"{qty} {Plural(subject)}";

            var vowels = new[] {'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U'};
            var firstChar = subject.First();

            return vowels.Any(i => i == firstChar) 
                ? $"an {subject}" 
                : $"a {subject}";
        }

        public static string Definite(string subject, int qty)
        {
            return qty > 1 
                ? Plural(subject) 
                : $"the {subject}";
        }

        public static string Prefix(string[] a, int m, string subject, string sep = " ")
        {
            var n = Math.Abs(m);
            if (n < 1 || n > a.Length) return subject;
            return a[n - 1] + sep + subject;
        }

        public static string Sick(int m, string subject)
        {
            var n = Math.Abs(m);
            var a = new[] {"dead", "comatose", "crippled", "sick", "undernourished"};
            return Prefix(a, n, subject);
        }

        public static string Young(int m, string subject)
        {
            var n = 6 - Math.Abs(m);
            var a = new[] {"foetal", "baby", "preadolescent", "teenage", "underage"};
            return Prefix(a, n, subject);
        }

        public static string Big(int m, string subject)
        {
            var a = new[] {"greater", "massive", "enormous", "giant", "titanic"};
            return Prefix(a, m, subject);
        }

        public static string Special(int m, string subject)
        {
            var a = subject.Contains(" ")
                ? new[] {"veteran", "cursed", "warrior", "undead", "demon"}
                : new[] {"Battle-", "cursed ", "Where-", "undead ", "demon "};

            return Prefix(a, m, subject);
        }

        private static string Terminate(string player_name)
        {
            var a = new[] {"faithful", "nobel", "loyal", "brave"};
            return $"Terminate {a.Random()} {player_name}?";
        }
    }
}
