namespace ProgressSharp.Character
{
    public class Race
    {
        public string Name { get; }
        public Attributes Attributes { get; }

        public Race(string name, Attributes attribute)
        {
            Name = name;
            Attributes = attribute;
        }
    }
}