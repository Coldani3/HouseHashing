using System;

namespace HouseHashing
{
	public class MainMenu : SelectItemMenu
	{

		public MainMenu() : base(new string[] {
				"Add Dwelling",
				"Find Dwelling",
				"Delete Dwelling"
			}, new Action[] {
				() => {

				},
				() => {

				},
				() => {

				}
			})
		{
			
		}
	}
}