using System;
using System.Collections.Generic;

namespace HouseHashing
{
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
			if (input.Key == ConsoleKey.DownArrow)
			{
				if (this.SelectedIndex + 1 < this.Options.Length) this.SelectedIndex++;
			}
			else if (input.Key == ConsoleKey.UpArrow)
			{
				if (this.SelectedIndex - 1 >= 0) this.SelectedIndex--;
			}
			else if (input.Key == ConsoleKey.Enter)
			{
				this.ActionsForIndex[this.SelectedIndex]();
			}
		}

		public void Display()
		{

		}
	}
}