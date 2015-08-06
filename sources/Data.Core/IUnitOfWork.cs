using System;
using System.Threading.Tasks;

namespace UnitOfWork.Data
{
	public interface IUnitOfWork : IDisposable
	{
		Task SaveAsync();
	}
}