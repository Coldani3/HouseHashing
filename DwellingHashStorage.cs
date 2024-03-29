using System;
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
			int hash = Math.Abs(search.GetHashCode());
			for (int i = 0; i < Size; i++)
			{
				int location = (hash + i * i) % Size;
				IDwelling dwelling = this.Storage[location];
				if (dwelling != null && dwelling.PostCode + dwelling.Identifier == search) 
				{
					return dwelling;
				}
			}

			return null;
		}

		public void AddDwelling(IDwelling dwelling)
		{
			int hash = Math.Abs(dwelling.GetHashCode());

			//quadratic probing
			for (int i = 0; i < this.Size; i++)
			{
				int tryHashLocation = (hash + i * i) % Size;

				if (Storage[tryHashLocation] == null) 
				{
					Storage[tryHashLocation] = dwelling;
				}
			}
		}

		public void DeleteDwelling(string search)
		{
			int hash = Math.Abs(search.GetHashCode());
			for (int i = 0; i < Size; i++)
			{
				int testingHash = (hash + i * i) % Size;
				IDwelling dwelling = this.Storage[testingHash];
				
				if (dwelling != null && dwelling.PostCode + dwelling.Identifier == search) 
				{
					this.Storage[testingHash] = null;
				}
			}
		}
	}
}