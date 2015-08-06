using System;
using UnitOfWork.Domain;

namespace UnitOfWork.Sample.Domain
{
	public class Profile : Entity<int>
	{
		public string Name { get; set; }
	}
}