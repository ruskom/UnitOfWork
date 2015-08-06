using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitOfWork.Domain
{
	public interface IProfileRepository : IRepository<Profile, int>
	{
		Task<Profile> GetByNameAsync(string name);
		Task<IEnumerable<Profile>> GetAllAsync();
	}
}