using System;

namespace HouseHashing
{
    public class DeleteDwellingMenu : FindDwellingMenu
    {
        public DeleteDwellingMenu() : base()
        {

        }

        public override bool Submit()
        {
            IDwelling dwelling = Program.DwellingHashStorage.GetDwelling(this.GetInputByIndex(0) + this.GetInputByIndex(1));

			if (dwelling != null) 
            {
                Program.DwellingHashStorage.DeleteDwelling(this.GetInputByIndex(0) + this.GetInputByIndex(1));//Program.MenuManager.ChangeMenu(new ViewDwellingMenu(dwelling));
                Console.Clear();
                Console.SetCursorPosition(2, 10);
                Console.WriteLine("Successfully deleted Dwelling!");
                System.Threading.Thread.Sleep(1000);

                Program.MenuManager.ChangeMenu(new MainMenu());
            }
			else
			{
				this.ErrorMessage = "Could not find matching Dwelling!";
                Program.Renderer.Render();
				return false;
			}
			
			return true;
        }
    }
}