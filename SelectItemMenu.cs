using System;
using System.Collections.Generic;

namespace HouseHashing
{
	//For menus that are only an up and down and press enter to select type thing
	public class SelectItemMenu : IMenu
	{
		private int SelectedIndex = 0;
		private Action[] ActionsForIndex;
		private string[] Options;

		public SelectItemMenu(string[] options, Action[] actions)
		{
			this.ActionsForIndex = new Action[actions.Length];
			this.Options = new string[options.Length];

			for (int i = 0; i < options.Length; i++)
			{
				this.ActionsForIndex[i] = actions[i];
				this.Options[i] = options[i];
			}
		}

		public void OnInput(ConsoleKeyInfo input)
		{
			switch (input.Key)
			{
				case ConsoleKey.DownArrow:
					if (this.SelectedIndex + 1 < this.Options.Length) this.SelectedIndex++;
					break;
				case ConsoleKey.UpArrow:
					if (this.SelectedIndex - 1 >= 0) this.SelectedIndex--;
					break;
				case ConsoleKey.Enter:
					this.ActionsForIndex[this.SelectedIndex]();
					break;
			}
		}

		public void Display()
		{
			for (int i = 0; i < this.Options.Length; i++)
			{
				Console.SetCursorPosition(2, 2 + i);
				if (i == this.SelectedIndex) 
				{
					Console.Write("> ");
					Console.BackgroundColor = ConsoleColor.White;
					Console.ForegroundColor = ConsoleColor.Black;
				}
				else Console.Write("  ");

				Console.Write(this.Options[i]);
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.White;
			}
			
		}
	}
}