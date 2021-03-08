using System;
using System.Threading.Tasks;

namespace HouseHashing
{
    class Program
    {
		public static bool Running = true;
		public static MenuManager MenuManager = new MenuManager();
		public static Renderer Renderer = new Renderer();
		public static DwellingHashStorage DwellingHashStorage = new DwellingHashStorage(113);
        static void Main(string[] args)
        {
			Console.CursorVisible = false;
			Console.WindowHeight = 40;
			Console.WindowWidth = 70;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;

			Task inputThread = new Task(() => {
				try
				{
					bool ranOnce = false;
					while (Running)
					{
						if (ranOnce) MenuManager.ActiveMenu.OnInput(Console.ReadKey(true));
						else ranOnce = true;
						Renderer.Render();
						System.Threading.Thread.Sleep(100);
					}
				}
				catch (Exception e)
				{
					Console.Clear();
					Console.WriteLine(e.Message);
					Console.WriteLine(e.StackTrace);
				}
			});
			inputThread.Start();

			while (Running);

			Console.Clear();
			Console.SetCursorPosition(0, 0);
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey(true);
        }
    }
}
