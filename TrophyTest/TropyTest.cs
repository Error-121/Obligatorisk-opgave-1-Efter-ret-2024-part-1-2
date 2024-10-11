using System.Numerics;
using TrophyLibrary;

namespace TrophyTest
{
	[TestClass]
	public class TropyTest
	{

		private readonly Trophy _trophy = new() { Id = 1, Name = "GoldInTriathlon", Year = 2000 };
		private readonly Trophy _nullName = new() { Id = 2, Year = 2001 };
		private readonly Trophy _shortName = new() { Id = 3, Name = "Go", Year = 2002 };
		private readonly Trophy _emptyName = new() { Id = 4, Name = "", Year = 2003 };
		private readonly Trophy _invalidYear = new() { Id = 4, Name = "GoldInTriathlon", Year = 1969 };


		[TestMethod]
		public void ToStringTest()
		{
			Assert.AreEqual("Id: 1, Name: GoldInTriathlon, Year: 2000", _trophy.ToString());
		}

		[TestMethod()]
		public void ValidateNameTest()
		{
			_trophy.ValidateName();
			Assert.ThrowsException<ArgumentNullException>(() => _nullName.ValidateName());
			Assert.ThrowsException<ArgumentException>(() => _emptyName.ValidateName());
			Assert.ThrowsException<ArgumentException>(() => _shortName.ValidateName());
		}

		[TestMethod()]
		public void ValidateYearTest()
		{
			_trophy.ValidateYear();
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _invalidYear.ValidateYear());
		}

		[TestMethod()]
		public void ValidateTest()
		{
			_trophy.Validate();
		}
	}
}