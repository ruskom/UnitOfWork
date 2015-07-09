using System;

namespace UnitOfWork.Domain
{
	public class Profile : Entity<int>
	{
		public string Name { get; set; }
	}
}