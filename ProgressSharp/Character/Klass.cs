namespace ProgressSharp.Character
{
    public class Klass
    {
        public string Name { get; }
        public Attributes Attribute { get; }

        public Klass(string name, Attributes attribute)
        {
            Name = name;
            Attribute = attribute;
        }
    }
}