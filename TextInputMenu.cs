using System;
using System.Collections.Generic;

namespace HouseHashing
{
	public class TextInputMenu : IMenu
	{
		private Tuple<int[], string>[] InputAreas;
		private string[] PreTextMessages;
		private int InputAreaIndex = 0;
		private int CursorIndex = 0;

		public TextInputMenu(int[][] inputAreas, string[] preTextMessages)
		{
			this.InputAreas = new Tuple<int[], string>[inputAreas.Length];
			for (int i = 0; i < inputAreas.Length; i++) 
			{
				this.InputAreas[i] = Tuple.Create<int[], string>(inputAreas[i], "");
				this.PreTextMessages[i] = preTextMessages[i];
			}
		}

		public void OnInput(ConsoleKeyInfo input)
		{
			//manual text editor stuff wooo
			//can't wait for this to break horribly
			switch (input.Key)
			{
				case ConsoleKey.UpArrow:
					if (InputAreaIndex - 1 >= 0) 
					{
						InputAreaIndex--;
						if (CursorIndex > InputAreas[InputAreaIndex].Item2.Length) CursorIndex = InputAreas[InputAreaIndex].Item2.Length;
					}

					break;
				case ConsoleKey.DownArrow:
					if (InputAreaIndex + 1 < InputAreas.Length) 
					{
						InputAreaIndex++;
						if (CursorIndex > InputAreas[InputAreaIndex].Item2.Length) CursorIndex = InputAreas[InputAreaIndex].Item2.Length;
					}
					break;
				//navigating in a text entry
				case ConsoleKey.LeftArrow:
					if (this.CursorIndex > 0) CursorIndex--;
					break;
				case ConsoleKey.RightArrow:
					if (this.CursorIndex <= InputAreas[InputAreaIndex].Item2.Length) CursorIndex++;
					break;
				case ConsoleKey.Delete:
					//you can't delete nothing
					if (CursorIndex > 0) 
					{
						InputAreas[InputAreaIndex].Item2.Remove(CursorIndex - 1, 1);
						goto case ConsoleKey.LeftArrow;
					}
					break;
				default:
					InputAreas[InputAreaIndex].Item2.Insert(CursorIndex, input.KeyChar.ToString());
					goto case ConsoleKey.RightArrow;
			}

		}

		public void Display()
		{
			Console.CursorVisible = false;
			for (int i = 0; i < this.InputAreas.Length; i++)
			{
				int[] coords = this.InputAreas[i].Item1;
				Console.SetCursorPosition(coords[0], coords[1]);
				Console.Write(this.PreTextMessages[i] + " " + this.InputAreas[i].Item2);
			}

			int[] startCoords = this.InputAreas[InputAreaIndex].Item1;
			int inputStart = startCoords[0] + this.PreTextMessages[InputAreaIndex].Length + 1;
			Console.SetCursorPosition(inputStart + CursorIndex, startCoords[1]);
			Console.CursorVisible = true;
		}
	}
}