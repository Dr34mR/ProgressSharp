using System.Collections.Generic;

namespace ProgressSharp.GameClasses
{
    public class MonsterModifiers : List<string>
    {
        public MonsterModifiers()
        {
            var list = new List<string>
            {
                "-4 f'tal *",
                "-4 dying *",
                "-3 crippled *",
                "-3 baby *",
                "-2 adolescent",
                "-2 very sick *",
                "-1 lesser *",
                "-1 undernourished *",
                "+1 greater *",
                "+1 * Elder",
                "+2 war *",
                "+2 Battle-*",
                "+3 Were-*",
                "+3 undead *",
                "+4 giant *",
                "+4 * Rex",
            };

            AddRange(list);
        }
    }
}