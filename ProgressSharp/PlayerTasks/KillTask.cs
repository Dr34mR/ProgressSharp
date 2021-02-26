using ProgressSharp.GameClasses;

namespace ProgressSharp.PlayerTasks
{
    public class KillTask : PlayerTask
    {
        public Monster Monster { get; set; }

        public KillTask(string description, int duration) : base(description, duration)
        {
        }
    }
}