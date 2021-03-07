using System;
using System.Threading.Tasks;

namespace HouseHashing
{
    class Program
    {
		public static IMenu CurrentMenu;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			Task inputThread = new Task(() => {
				CurrentMenu.OnInput(Console.ReadKey(true));
			});
        }
    }
}
