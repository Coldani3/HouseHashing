using System;

namespace HouseHashing
{
	public class Renderer
	{
		public Renderer()
		{
			//TODO: redraw on user input
		}

		public void Render()
		{
			Console.Clear();
			Program.MenuManager.ActiveMenu.Display();
		}
	}
}