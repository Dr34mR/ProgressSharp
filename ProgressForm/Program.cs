using System;
using System.Windows.Forms;
using ProgressSharp.Character;
using ProgressSharp.Extensions;
using ProgressSharp.GameClasses;
using ProgressSharp.Player;

namespace ProgressForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var player = new Player
            {
                Name = "Scoot",
                Birthday = DateTime.Now,
                Klass = Klasses.GetKlasses().Random(),
                Race = Races.GetRaces().Random()
            };

            var statBuilder = new StatsBuilder();
            player.Stats = statBuilder.Roll();
            player.SetCapacity();

            var mainForm = new MainForm(player);
            mainForm.Setup();

            Application.Run(mainForm);
        }
    }
}
