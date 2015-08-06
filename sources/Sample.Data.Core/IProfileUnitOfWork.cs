using System;
using UnitOfWork.Data;
using UnitOfWork.Sample.Domain;

namespace UnitOfWork.Sample.Data
{
	public interface IProfileUnitOfWork : IUnitOfWork
	{
		IProfileRepository Profiles { get; }
	}
}