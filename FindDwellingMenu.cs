namespace HouseHashing
{
	public class FindDwellingMenu : TextInputMenu
	{
		public FindDwellingMenu() : base(
			new int[][] {new int[] {2, 3}, new int[] {2, 5}},
			new string[] {"Postcode:", "Identifier:"}
		)
		{

		}

		public override bool Submit()
		{
			IDwelling dwelling = Program.DwellingHashStorage.GetDwelling(this.GetInputByIndex(0) + this.GetInputByIndex(1));

			if (dwelling != null) Program.MenuManager.ChangeMenu(new ViewDwellingMenu(dwelling));
			else
			{
				this.ErrorMessage = "Could not find matching Dwelling!";
				return false;
			}
			
			return true;
		}
	}
}