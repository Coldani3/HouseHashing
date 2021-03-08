using System.Collections.Generic;

namespace HouseHashing
{
	public class MenuManager
	{
		public IMenu ActiveMenu { get; private set; }
		private IMenu PreviousMenu { get; set; }
		//data saved between menus
		private Dictionary<string, object> PersistentMenuData = new Dictionary<string, object>();

		public MenuManager()
		{
			this.ActiveMenu = new MainMenu();
		}

		public void ChangeMenu(IMenu newMenu)
		{
			this.PreviousMenu = this.ActiveMenu;
			this.ActiveMenu = newMenu;
			System.Console.CursorVisible = false;
			Program.Renderer.Render();
		}

		public void SetPersistentMenuData(string key, object data)
		{
			if (!this.PersistentMenuData.ContainsKey(key)) this.PersistentMenuData.Add(key, data);
			else this.PersistentMenuData[key] = data;
		}

		public object GetPersistentMenuData(string key)
		{
			if (this.PersistentMenuData.ContainsKey(key)) return this.PersistentMenuData[key];
			else return null;
		}

		public void ClearPersistentMenuData()
		{
			this.PersistentMenuData.Clear();
		}

		public IMenu GetPreviousMenu()
		{
			return PreviousMenu;
		}
	}
}