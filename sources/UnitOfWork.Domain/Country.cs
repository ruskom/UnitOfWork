using System;

namespace UnitOfWork.Domain
{
	public class Country : Entity<int>
	{
		public string Name { get; set; }
	}
}