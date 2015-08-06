using System;

namespace UnitOfWork.Domain
{
	// TODO: domain.core, .data, .services?
	public class Address : Entity<int>
	{
		public string City { get; set; }
		public Country Country { get; set; }
	}
}