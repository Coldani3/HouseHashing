namespace HouseHashing
{
	public class SelectDwellingTypeMenu : SelectItemMenu
	{
		public SelectDwellingTypeMenu() : base(
			new string[] {"Flat", "Bungalow", "House"}, 
			new System.Action[]
			{
				() => {
					Program.MenuManager.SetPersistentMenuData("housetype", HouseType.Flat);
					Program.MenuManager.ChangeMenu(new AddDwellingMenu());
				},
				() => {
					Program.MenuManager.SetPersistentMenuData("housetype", HouseType.Bungalow);
					Program.MenuManager.ChangeMenu(new AddDwellingMenu());
				},
				() => {
					Program.MenuManager.SetPersistentMenuData("housetype", HouseType.House);
					Program.MenuManager.ChangeMenu(new AddDwellingMenu());
				},
			})
		{
			
		}
	}
}