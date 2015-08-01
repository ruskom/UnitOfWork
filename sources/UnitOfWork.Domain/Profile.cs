using System;
using System.Collections.Generic;

namespace UnitOfWork.Domain
{
	public class Profile : Entity<int>
	{
		public string Name { get; set; }
		public ICollection<Address> Addresses { get; set; }
	}
}