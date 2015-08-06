using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using UnitOfWork.Data.Entity;
using UnitOfWork.Sample.Domain;

namespace UnitOfWork.Sample.Data.Entity
{
	public class ProfileRepository : Repository<Profile, int>, IProfileRepository
	{
		public ProfileRepository(IDbSet<Profile> items) : base(items)
		{
		}

		public override Task<Profile> GetByIdAsync(int id) => Items.FirstOrDefaultAsync(value => value.Id == id);
		public Task<Profile> GetByNameAsync(string name) => Items.FirstOrDefaultAsync(value => value.Name == name);

		public async Task<IEnumerable<Profile>> GetAllAsync()
		{
			var result = await Items.ToListAsync();
			return result;
		}
	}
}