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
			
		}
	}
}