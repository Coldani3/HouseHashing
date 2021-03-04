namespace HouseHashing
{
	public class Bungalow : IDwelling
	{
		public string PostCode { get; }
		public string Identifier { get; set; }
		public string HouseholderName { get; set; }
		public int Residents { get; set; }
		public bool SingleFloored { get => true; }
		public override int GetHashCode() => (PostCode + Identifier).GetHashCode();

		public Bungalow(string postCode, string identifier)
		{
			PostCode = postCode;
			Identifier = identifier;
		}
	}
}