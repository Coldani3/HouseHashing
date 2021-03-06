using System.Collections.Generic;

namespace HouseHashing
{
	public class DwellingHashStorage
	{
		private IDwelling[] Storage;
		private int Size;

		public DwellingHashStorage(int size)
		{
			this.Size = size;
			this.Storage = new IDwelling[size];
		}

		public IDwelling GetDwelling(string search)
		{
			int hash = search.GetHashCode();
			for (int i = 0; i < Size; i++)
			{
				IDwelling dwelling = this.Storage[hash];
				if (dwelling.PostCode + dwelling.Identifier == search)
				{
					return dwelling;
				}
			}

			return null;
		}

		public void AddDwelling(IDwelling dwelling)
		{
			int hash = dwelling.GetHashCode();
			List<int> alreadyTriedHashes = new List<int>();

			//quadratic probing
			for (int i = 0; i < this.Size - 1; i++)
			{
				int tryHashLocation = (hash + i * i) % Size;

				if (alreadyTriedHashes.Contains(tryHashLocation)) 
				{
					//instead of 1 4 9 16 it becomes
					//2 5 10 17
					alreadyTriedHashes.Clear();
					continue;
				}

				if (Storage[tryHashLocation] == null) Storage[tryHashLocation] = dwelling;
				else alreadyTriedHashes.Add(tryHashLocation);
			}


		}
	}
}