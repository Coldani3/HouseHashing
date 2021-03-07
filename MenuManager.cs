namespace HouseHashing
{
	public class MenuManager
	{
		public IMenu ActiveMenu { get; private set; }

		public MenuManager()
		{
			this.ActiveMenu = new MainMenu();
		}

		public void ChangeMenu(IMenu newMenu)
		{
			this.ActiveMenu = newMenu;
		}
	}
}