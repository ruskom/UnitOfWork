using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork.Domain;

namespace UnitOfWork.Sample.Domain
{
	public interface IProfileRepository : IRepository<Profile, int>
	{
		Task<Profile> GetByNameAsync(string name);
		Task<IEnumerable<Profile>> GetAllAsync();
	}
}