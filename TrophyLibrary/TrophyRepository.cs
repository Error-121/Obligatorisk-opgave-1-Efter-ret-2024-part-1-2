using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TrophyLibrary
{
	public class TrophyRepository
	{
		private readonly List<Trophy> _trophies = new();

		private int _nextId = 1;

		//List<Trophy> _copyTrophies = new List<Trophy>(_trophies);

		public List<Trophy> GetAll()
		{
			return new List<Trophy>(_trophies);
		}

		public Trophy? GetById(int id)
		{
			return _trophies.Find(trophy => trophy.Id == id);
		}

		public Trophy Add(Trophy trophy)
		{
			trophy.Validate();
			trophy.Id = _nextId++;
			_trophies.Add(trophy);
			return trophy;
		}

		public Trophy? Remove(int id)
		{
			Trophy? trophy = GetById(id);
			if (trophy == null)
			{
				return null;
			}
			_trophies.Remove(trophy);
			return trophy;
		}

		public Trophy? Update(int id, Trophy trophy)
		{
			trophy.Validate();
			Trophy? existingTrophy = GetById(id);
			if (existingTrophy == null)
			{
				return null;
			}
			existingTrophy.Name = trophy.Name;
			existingTrophy.Year = trophy.Year;
			return existingTrophy;
		}

		public IEnumerable<Trophy> Get(int? yearAfter = null, string? nameIncludes = null, string? orderBy = null)
		{
			IEnumerable<Trophy> result = new List<Trophy>(_trophies);
			// Filtering
			if (yearAfter != null)
			{
				result = result.Where(m => m.Year > yearAfter);
			}
			if (nameIncludes != null)
			{
				result = result.Where(m => m.Name.Contains(nameIncludes));
			}

			// Ordering aka. Sorting
			if (orderBy != null)
			{
				orderBy = orderBy.ToLower();
				switch (orderBy)
				{
					case "name": // fall through to next case
					case "name_asc":
						result = result.OrderBy(m => m.Name);
						break;
					case "name_desc":
						result = result.OrderByDescending(m => m.Name);
						break;
					case "birthyear": // fall through to next case
					case "birthyear_asc":
						result = result.OrderBy(m => m.Year);
						break;
					case "birthyear_desc":
						result = result.OrderByDescending(m => m.Year);
						break;
					default:
						break; // do nothing
							   //throw new ArgumentException("Unknown sort order: " + orderBy);
				}
			}
			return result;

		}
	}
}
