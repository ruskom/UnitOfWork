using System;

namespace UnitOfWork.Domain
{
	public class Address : Entity<int>
	{
		public string City { get; set; }
		public Country Country { get; set; }
	}
}