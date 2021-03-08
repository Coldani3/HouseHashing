using System;
using System.Collections.Generic;

namespace HouseHashing
{
	public class AddDwellingMenu : TextInputMenu
	{
		public AddDwellingMenu() : base(GetPositions(), GetPreTextMessages())
		{

		}

		public override bool Submit()
		{
			string postCode = this.GetInputByIndex(0);
			string identifier = this.GetInputByIndex(1);
			string householderName = this.GetInputByIndex(2);
			string residents = this.GetInputByIndex(3);

			int residentsNum = 0;
			bool singleFlooredBool = true;

			if (this.InputAreas.Length > 4)
			{
				string singleFloored = this.GetInputByIndex(4).ToLower();

				if (!Int32.TryParse(residents, out residentsNum))
				{
					this.ErrorMessage = "The string entered into Residents was not a number!";
					return false;
				}

				if (singleFloored == "y")
				{
					singleFlooredBool = true;
				}
				else if (singleFloored == "n")
				{
					singleFlooredBool = false;
				}
				else
				{
					this.ErrorMessage = "The value entered for Single Floored was not one of the accepted values!";
					return false;
				}
			}

			Program.DwellingHashStorage.AddDwelling(DwellingFactory.GenerateDwelling((HouseType) Program.MenuManager.GetPersistentMenuData("housetype"), postCode, identifier, householderName, residentsNum, singleFlooredBool));
			Program.MenuManager.ChangeMenu(new MainMenu());

			return true;
		}

		private static int[][] GetPositions()
		{
			List<int[]> guaranteed = new List<int[]>() {new int[] {2, 2}, new int[] {2, 4}, new int[] {2, 6}, new int[] {2, 8}};
			object data = Program.MenuManager.GetPersistentMenuData("housetype");
			if (data != null && (HouseType) data == HouseType.House) guaranteed.Add(new int[] {2, 10});
			return guaranteed.ToArray();
		}

		private static string[] GetPreTextMessages()
		{
			List<string> guaranteed = new List<string>() {"Post Code:", "Identifier:", "Householder Name:", "Residents (number only):"};
			object data = Program.MenuManager.GetPersistentMenuData("housetype");
			if (data != null && (HouseType) data == HouseType.House) guaranteed.Add("Single Floored? (Y/N)");
			return guaranteed.ToArray();
		}
	}
}