using System;
using System.Linq;
using ProgressSharp.Helpers;
using ProgressSharp.PlayerTasks;

namespace ProgressSharp
{
    public class Simulation
    {
        public Player.Player Player;
        public DateTime LastTick;

        public Simulation(Player.Player player)
        {
            Player = player;
            LastTick = DateTime.Now;
        }

        public void Tick(float elapsed = 100)
        {
            Player.Elapsed += elapsed;

            if (Player.CurrentTask == null)
            {
                Player.SetTask(new RegularTask("Loading", 2000));

                var msg = "Experiencing an enigmatic and foreboding night vision";
                Player.QueuedTasks.Add(new RegularTask(msg, 10000));

                msg = "Much is revealed about that wise old bastard you'd underestimated";
                Player.QueuedTasks.Add(new RegularTask(msg, 6000));

                msg = "A shocking series of events leaves you alone and bewildered, but resolute";
                Player.QueuedTasks.Add(new RegularTask(msg, 6000));

                msg = "Drawing upon an unrealized reserve of determination, you set out on a long and dangerous journey";
                Player.QueuedTasks.Add(new RegularTask(msg, 4000));

                Player.QueuedTasks.Add(new PlotTask($"Loading {StringHelpers.ActName(1)}", 2000));
            }

            if (!Player.TaskBar.Done())
            {
                Player.TaskBar.Increment(elapsed);
            }

            // Gain XP / Level Up

            var gain = Player.CurrentTask is KillTask;
            if (gain)
            {
                if (Player.ExpBar.Done())
                {
                    Player.LevelUp();
                }
                else
                {
                    // ReSharper disable once PossibleLossOfFraction
                    Player.ExpBar.Increment(Player.ExpBar.Max / 1000);
                }
            }

            // Advance Quest

            if (gain && Player.QuestBook.Act >= 1 && Player.TaskBar.Done())
            {
                var questBar = Player.QuestBook.QuestBar;
                if (questBar.Done() || string.IsNullOrEmpty(Player.QuestBook.CurrentQuest))
                {
                    CompleteQuest();
                }
                else
                {
                    // ReSharper disable once PossibleLossOfFraction
                    questBar.Increment(Player.TaskBar.Max / 1000);
                }
            }

            // Advance Plot

            if (gain)
            {
                var plotBar = Player.QuestBook.PlotBar;
                if (plotBar.Done())
                {
                    InterplotCinematic();
                }
                else
                {
                    // ReSharper disable once PossibleLossOfFraction
                    plotBar.Increment(Player.TaskBar.Max / 1000);
                }
            }

            Dequeue();
        }

        private void Dequeue()
        {
            var shouldBreak = false;
            while (Player.TaskBar.Done())
            {
                switch (Player.CurrentTask)
                {
                    case KillTask killTask:
                    {
                        var monster = killTask.Monster;
                        if (monster?.Item == null)
                        {
                            // NPC
                            Player.WinItem();
                        }
                        else if (monster.Item != null)
                        {
                            Player.Inventory.Add($"{monster.Name} {monster.Item}".ToLower(), 1);
                        }
                        break;
                    }
                    case BuyTask _:
                    {
                        // buy some equipment
                        var equipPrice = Player.EquipPrice();
                        Player.Inventory.AddGold(-1 * equipPrice);
                        Player.WinEquipment();
                        break;
                    }
                    case HeadingToMarketTask _:
                    case SellTask _:
                    {
                        if (Player.CurrentTask is SellTask)
                        {
                            var item = Player.Inventory.Items.First();
                            var amount = item.Quantity * Player.Level;
                            if (item.Name.Contains(" of "))
                            {
                                amount *= (1 + RandomHelper.BelowLow(10)) * (1 + RandomHelper.BelowLow(Player.Level));
                            }
                            Player.Inventory.Pop(0);
                            Player.Inventory.AddGold(amount);
                        }
                        if (Player.Inventory.Items.Any())
                        {
                            var item = Player.Inventory.Items.First();
                            var indefinite = StringHelpers.Indefinite(item.Name, item.Quantity);
                            Player.SetTask(new SellTask($"Selling {indefinite}", 1000));
                            shouldBreak = true;
                        }
                        break;
                    }
                    case PlotTask _:
                    {
                        CompleteAct();
                        break;
                    }
                }

                if (shouldBreak) break;

                var old = Player.CurrentTask;
                if (Player.QueuedTasks.Any())
                {
                    var task = Player.QueuedTasks.First();
                    Player.QueuedTasks.RemoveAt(0);
                    Player.SetTask(task);
                }
                else if (Player.Inventory.EncumBar.Done())
                {
                    Player.SetTask(new HeadingToMarketTask("Heading to market to sell loot", 4000));
                }
                else if (!(old is KillTask || old is HeadingToKillingFieldsTask))
                {
                    if (Player.Inventory.Gold > Player.EquipPrice())
                    {
                        Player.SetTask(new BuyTask("Negotiating purchase of better equipment", 5000));
                    }
                    else
                    {
                        Player.SetTask(new HeadingToKillingFieldsTask("Heading to the killing fields", 4000));
                    }
                }
                else
                {
                    Player.SetTask(Mechanic.MonsterTask(Player.Level, Player.QuestBook.Monster));
                }
            }
        }

        private void CompleteAct()
        {
            Player.QuestBook.IncrementAct();
            Player.QuestBook.PlotBar.Reset(60 * 60 * (1 + 5 * Player.QuestBook.Act));

            // ReSharper disable once InvertIf
            if (Player.QuestBook.Act > 1)
            {
                Player.WinItem();
                Player.WinEquipment();
            }
        }

        private void CompleteQuest()
        {
            Player.QuestBook.QuestBar.Reset(50 + RandomHelper.BelowLow(1000));
            if (!string.IsNullOrEmpty(Player.QuestBook.CurrentQuest))
            {
                Logger.Info($"Quest completed: {Player.QuestBook.CurrentQuest}");

                var value = RandomHelper.Below(4);
                switch (value)
                {
                    case 0:
                        Player.WinSpell();
                        break;
                    case 1:
                        Player.WinEquipment();
                        break;
                    case 2:
                        Player.WinStat();
                        break;
                    case 3:
                        Player.WinItem();
                        break;
                }
            }

            Player.QuestBook.Monster = null;
            string caption;
            var choice = RandomHelper.Below(5);

            switch (choice)
            {
                case 0:
                    var monster = Mechanic.UnnamedMonster(Player.Level, 3);
                    Player.QuestBook.Monster = monster;
                    caption = $"Exterminate {StringHelpers.Definite(monster.Name, 2)}";
                    break;
                case 1:
                    caption = $"Seek {StringHelpers.Definite(Mechanic.InterestingItem(), 1)}";
                    break;
                case 2:
                    caption = $"Deliver this {Mechanic.BoringItem()}";
                    break;
                case 3:
                    caption = $"Fetch me {StringHelpers.Indefinite(Mechanic.BoringItem(), 1)}";
                    break;
                case 4:
                    monster = Mechanic.UnnamedMonster(Player.Level, 1);
                    caption = $"Placate {StringHelpers.Definite(monster.Name, 2)}";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Player.QuestBook.AddQuest(caption);
        }

        private void InterplotCinematic()
        {
            var choice = RandomHelper.Below(3);
            switch (choice)
            {
                case 0:
                {
                    EnqueueReg("Exhausted, you arrive at a friendly oasis in a hostile land", 1000);
                    EnqueueReg("You greet old friends and meet new allies", 2000);
                    EnqueueReg("You are privy to a council of powerful do-gooders", 2000);
                    EnqueueReg("There is much to be done. You are chosen!", 1000);
                    break;
                }
                case 1:
                {
                    EnqueueReg("Your quarry is in sight, but a mighty enemy bars your path!", 1000);

                    var nemesis = Mechanic.NamedMonster(Player.Level + 3);
                    EnqueueReg($"A desperate struggle commences with {nemesis}", 4000);

                    var s = RandomHelper.Below(3);
                    var i = 0;
                    while (true)
                    {
                        i += 1;
                        if (i > RandomHelper.Below(1 + Player.QuestBook.Act + 1))
                        {
                            break;
                        }
                        s += 1 + RandomHelper.Below(2);
                        switch (s % 3)
                        {
                            case 0:
                                EnqueueReg($"Locked in grim combat with {nemesis}", 2000);
                                break;
                            case 1:
                                EnqueueReg($"{nemesis} seems to have the upper hand", 2000);
                                break;
                            case 2:
                                EnqueueReg($"You seem to gain the advantage over {nemesis}", 2000);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    EnqueueReg($"Victory! {nemesis} is slain! Exhaused, you lose conciousness", 3000);
                    EnqueueReg("You awake in a friendly place, but the road awaits", 2000);
                    break;
                }
                case 2:
                {
                    var nemesis = Mechanic.ImpressiveGuy();
                    EnqueueReg($"Oh sweet relief! You've reached the protection of the good {nemesis}", 2000);
                    EnqueueReg($"There is rejoicing, and an unnerving encounter with {nemesis} in private", 3000);

                    var boringItem = Mechanic.BoringItem();
                    EnqueueReg($"You forget your {boringItem} and go back to get it", 2000);
                    EnqueueReg("What's this!? You overhear something shocking!", 2000);
                    EnqueueReg($"Could {nemesis} be a dirty double-dealer?", 2000);
                    EnqueueReg("Who can possibly be trusted with this news!? ... Oh yes, of course", 3000);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            EnqueuePlot($"Loading {StringHelpers.ActName(Player.QuestBook.Act + 1)}", 1000);
        }

        private void EnqueuePlot(string message, int duration)
        {
            var plotTask = new PlotTask(message, duration);
            Player.QueuedTasks.Add(plotTask);
            Dequeue();
        }

        private void EnqueueReg(string message, int duration)
        {
            var regTask = new RegularTask(message, duration);
            Player.QueuedTasks.Add(regTask);
            Dequeue();
        }
    }
}
