using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitOfWork.Domain
{
	public interface IProfileRepository : IEntityRepository<Profile, int>
	{
		Task<Profile> GetByNameAsync(string name);
		Task<List<Profile>> GetAllAsync();
	}
}