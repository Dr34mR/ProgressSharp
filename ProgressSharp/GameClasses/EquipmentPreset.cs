namespace ProgressSharp.GameClasses
{
    public class EquipmentPreset
    {
        public string Name;
        public int Quality;

        public EquipmentPreset(string name, int quality)
        {
            Name = name;
            Quality = quality;
        }

        public override string ToString()
        {
            return $"{Name} {(Quality >= 0 ? "+" : "-")}{Quality}";
        }
    }
}