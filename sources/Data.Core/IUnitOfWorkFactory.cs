﻿using System;

namespace UnitOfWork.Data
{
	public interface IUnitOfWorkFactory<out TUnitOfWork> where TUnitOfWork : IUnitOfWork
	{
		TUnitOfWork Create();
	}
}