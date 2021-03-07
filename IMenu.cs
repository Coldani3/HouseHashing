using System;

namespace HouseHashing
{
	public interface IMenu
	{
		void OnInput(ConsoleKeyInfo input);
		void Display();
	}
}