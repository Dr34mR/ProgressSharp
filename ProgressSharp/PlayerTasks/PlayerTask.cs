namespace ProgressSharp.PlayerTasks
{
    public class PlayerTask
    {
        public string Description { get; set; }
        public int Duration { get; set; }

        public PlayerTask(string description, int duration)
        {
            Description = description;
            Duration = duration;
        }
    }
}