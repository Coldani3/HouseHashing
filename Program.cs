﻿using System;
using System.Threading.Tasks;

namespace HouseHashing
{
    class Program
    {
		public static MenuManager MenuManager = new MenuManager();
		public static Renderer Renderer = new Renderer();
		public static DwellingHashStorage DwellingHashStorage = new DwellingHashStorage(113);
		public static bool Running = true;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
			Console.CursorVisible = true;
			Console.WindowHeight = 40;
			Console.WindowWidth = 70;

			Task inputThread = new Task(() => {
				MenuManager.ActiveMenu.OnInput(Console.ReadKey(true));
				Renderer.Render();
			});

			while (Running);

			Console.Clear();
			Console.SetCursorPosition(0, 0);
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey(true);
        }
    }
}
