using System.Collections.Generic;
using System.Linq;
using ProgressSharp.GameClasses;

namespace ProgressSharp.Player
{
    public class QuestBook
    {
        public delegate void QuestEventHandler(object sender, QuestArgs args);

        public event QuestEventHandler StartAct;

        public event QuestEventHandler NewQuest;

        public event QuestEventHandler RemoveQuest;

        public readonly List<string> Quests = new List<string>();

        public int Act { get; set; }

        public Monster Monster = null;

        public string CurrentQuest => Quests.LastOrDefault();

        public ProgressBar PlotBar = new ProgressBar {Max = 1};

        public ProgressBar QuestBar = new ProgressBar {Max = 1};

        public void IncrementAct()
        {
            Act += 1;

            StartAct?.Invoke(this, new QuestArgs());
        }

        public void AddQuest(string name)
        {
            while (Quests.Count > 100)
            {
                var first = Quests.First();
                Quests.RemoveAt(0);
                RemoveQuest?.Invoke(this, new QuestArgs{Name = first});
            }
            Quests.Add(name);

            var message = $"Commencing quest: {name}";
            Logger.Info(message);

            NewQuest?.Invoke(this, new QuestArgs {Name = name});
        }
    }
}
