using System;

namespace UnitOfWork.Data.Entity
{
	public class ProfileUnitOfWorkFactory : IUnitOfWorkFactory<IProfileUnitOfWork>
	{
		public IProfileUnitOfWork Create()
		{
			return new ProfileUnitOfWork();
		}
	}
}