using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using UnitOfWork.Domain;

namespace UnitOfWork.Data.Entity
{
	public class ProfileRepository : EntityRepository<Profile, int>, IProfileRepository
	{
		public ProfileRepository(IDbSet<Profile> values) : base(values)
		{
		}

		public override Task<Profile> GetByIdAsync(int id)
		{
			return Values.FirstOrDefaultAsync(value => value.Id == id);
		}

		public Task<Profile> GetByNameAsync(string name)
		{
			return Values.FirstOrDefaultAsync(value => value.Name == name);
		}

		public Task<List<Profile>> GetAllAsync()
		{
			return Values.ToListAsync();
		}
	}
}