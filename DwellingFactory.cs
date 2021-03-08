namespace HouseHashing
{
	public class DwellingFactory
	{
		public static IDwelling GenerateDwelling(HouseType type, string postCode, string identifier, string householderName, int residents, bool singleFloored = true)
		{
			IDwelling result = null;
			switch (type)
			{
				case HouseType.Bungalow:
					Bungalow bungalow = new Bungalow(postCode, identifier);
					bungalow.HouseholderName = householderName;
					bungalow.Residents = residents;
					result = bungalow;
					break;
				case HouseType.Flat:
					Flat flat = new Flat(postCode, identifier);
					flat.HouseholderName = householderName;
					flat.Residents = residents;
					result = flat;
					break;
				default:
					//HouseType.House
					House house = new House(postCode, identifier);
					house.HouseholderName = householderName;
					house.Residents = residents;
					house.SingleFloored = singleFloored;
					result = house;
					break;
			}

			return result;
		}
	}
}