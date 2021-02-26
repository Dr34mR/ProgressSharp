namespace ProgressSharp.Helpers
{
    public static class Roman
    {
        private static readonly string[] ThouLetters =
        {
            "", "M", "MM", "MMM"
        };

        private static readonly string[] HundLetters =
        {
            "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"
        };
        
        private static readonly string[] TensLetters =
        {
            "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"
        };
        
        private static readonly string[] OnesLetters =
        {
            "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"
        };

        public static string ToRoman(int arabic)
        {
            // See if it's >= 4000.
            if (arabic >= 4000)
            {
                // Use parentheses.
                var thou = arabic / 1000;
                arabic %= 1000;
                return $"({ToRoman(thou)}){ToRoman(arabic)}";
            }

            // Otherwise process the letters.
            var result = "";

            // Pull out thousands.
            var num = arabic / 1000;
            result += ThouLetters[num];
            arabic %= 1000;

            // Handle hundreds.
            num = arabic / 100;
            result += HundLetters[num];
            arabic %= 100;

            // Handle tens.
            num = arabic / 10;
            result += TensLetters[num];
            arabic %= 10;

            // Handle ones.
            result += OnesLetters[arabic];

            return result;
        }
    }
}
