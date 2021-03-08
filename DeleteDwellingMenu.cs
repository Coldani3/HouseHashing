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

			if (dwelling != null) Program.DwellingHashStorage.DeleteDwelling(this.GetInputByIndex(0) + this.GetInputByIndex(1));//Program.MenuManager.ChangeMenu(new ViewDwellingMenu(dwelling));
			else
			{
				this.ErrorMessage = "Could not find matching Dwelling!";
				return false;
			}
			
			return true;
        }
    }
}