using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TrophyLibrary;

namespace TrophyTest
{
	[TestClass]
	public class TrophyRepositoryTest
	{
		private TrophyRepository? _repository;
		private readonly Trophy _badTrophy = new() { Id = 4, Name = "GoldInTriathlon", Year = 1969 };

		[TestInitialize]
		public void Initialize()
		{
			_repository = new();

			_repository.Add(new Trophy() { Name = "GoldInTriathlon", Year = 2000 });
			_repository.Add(new Trophy() { Name = "SilverInTriathlon", Year = 2000});
			_repository.Add(new Trophy() { Name = "BronzeInTriathlon", Year = 2000 });
		}

		[TestMethod()]
		public void GetAllTest()
		{
			List<Trophy> trophies = _repository.GetAll();
			Assert.AreEqual(3, trophies.Count);
		}

		[TestMethod()]
		public void AddTest()
		{
			Trophy m = new() { Name = "Test", Year = 2021 };
			Assert.AreEqual(4, _repository.Add(m).Id);
			Assert.AreEqual(4, _repository.GetAll().Count());

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repository.Add(_badTrophy));
		}

		[TestMethod()]
		public void RemoveTest()
		{
			Assert.IsNull(_repository.Remove(100));
			Assert.AreEqual(1, _repository.Remove(1)?.Id);
			Assert.AreEqual(2, _repository.GetAll().Count());
		}

		[TestMethod()]
		public void UpdateTest()
		{
			Assert.AreEqual(3, _repository.GetAll().Count());
			Trophy m = new() { Name = "Test", Year = 2021 };
			Assert.IsNull(_repository.Update(100, m));
			Assert.AreEqual(1, _repository.Update(1, m)?.Id);
			Assert.AreEqual(3, _repository.GetAll().Count());

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repository.Update(1, _badTrophy));
		}
	}
}
