namespace HouseHashing
{
	public class House : IDwelling
	{
		public string PostCode { get; }
		public string Identifier { get; set; }
		public string HouseholderName { get; set; }
		public int Residents { get; set; }
		public bool SingleFloored { get; set; }
		public override int GetHashCode() => (PostCode + Identifier).GetHashCode();

		public House(string postCode, string identifier)
		{
			PostCode = postCode;
			Identifier = identifier;
		}

		public House(string postCode, string identifier, string householderName, int residents, bool singleFloored) : this(postCode, identifier)
		{
			this.HouseholderName = householderName;
			this.Residents = residents;
			this.SingleFloored = singleFloored;
		}
	}	
}