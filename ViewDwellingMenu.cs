using System;

namespace HouseHashing
{
	public class ViewDwellingMenu : IMenu
	{
		private IDwelling Dwelling;
		public ViewDwellingMenu(IDwelling dwelling)
		{
			this.Dwelling = dwelling;
		}

		public void OnInput(ConsoleKeyInfo input)
		{
			if (input.Key == ConsoleKey.Enter) 
			{
				Program.MenuManager.ChangeMenu(new MainMenu());
			}
		}

		public void Display()
		{
			Console.SetCursorPosition(0, 0);
			HouseType houseType = this.Dwelling.Type;

			Console.WriteLine($"Type: {houseType}");
			Console.WriteLine($"Postcode: {this.Dwelling.PostCode}");
			Console.WriteLine($"Identifier: {this.Dwelling.Identifier}");
			Console.WriteLine($"Householder Name: {this.Dwelling.HouseholderName}");
			Console.WriteLine($"Residents: {this.Dwelling.Residents}");
			Console.WriteLine($"Single Floored: {this.Dwelling.SingleFloored}");
		}
	}
}