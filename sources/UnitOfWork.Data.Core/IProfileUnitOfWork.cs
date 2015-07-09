using System;
using UnitOfWork.Domain;

namespace UnitOfWork.Data
{
	public interface IProfileUnitOfWork : IUnitOfWork
	{
		IProfileRepository Profiles { get; }
	}
}