using System;

namespace UnitOfWork.Domain
{
	public abstract class Entity<TId> : IEntity<TId>
	{
		public TId Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime LastUpdateAt { get; set; }
	}
}