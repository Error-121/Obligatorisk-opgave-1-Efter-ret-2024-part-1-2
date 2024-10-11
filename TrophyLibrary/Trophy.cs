namespace TrophyLibrary
{
	public class Trophy
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Year { get; set; }

		//public Trophy(int id, string name, int year)
		//{
		//	Id = id;
		//	Name = name;
		//	this.year = year;
		//}

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Name}, Year: {Year}";
		}

		public void ValidateName()
		{
			if (Name == null)
			{
				throw new ArgumentNullException(nameof(Name),"Name cannot be null");
			}
			if (Name.Length < 3)
			{
				throw new ArgumentException("Name must be at least 3 characters");
			}
		}

		public void ValidateYear()
		{
			if (Year < 1970 || Year > DateTime.Now.Year)
			{
				throw new ArgumentOutOfRangeException("Year must be greater than 1970");
			}
		}

		public void Validate()
		{
			ValidateName();
			ValidateYear();
		}

	}
}
