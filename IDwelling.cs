namespace HouseHashing
{
	public interface IDwelling
	{
		string PostCode { get; }
		string Identifier { get; }
		string HouseholderName { get; }
		int Residents { get; }
		bool SingleFloored { get; }
		HouseType Type { get; }
		int GetHashCode();
	}
}