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
			if (input.Key == ConsoleKey.Enter) Program.MenuManager.ChangeMenu(new MainMenu());
		}

		public void Display()
		{
			Console.SetCursorPosition(0, 0);
			//hacky and bad but can't think of better way (without going against Task brief code we're forced to include) :/
			HouseType houseType;
			
			if (this.Dwelling is House) houseType = HouseType.House;
			else if (this.Dwelling is Flat) houseType = HouseType.Flat;
			else houseType = HouseType.Bungalow;

			Console.WriteLine($"Type: {houseType}");
			Console.WriteLine($"Postcode: {this.Dwelling.PostCode}");
			Console.WriteLine($"Identifier: {this.Dwelling.Identifier}");
			Console.WriteLine($"Householder Name: {this.Dwelling.HouseholderName}");
			Console.WriteLine($"Residents: {this.Dwelling.Residents}");
			Console.WriteLine($"Single Floored: {this.Dwelling.SingleFloored}");
		}
	}
}