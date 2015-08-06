using System;

namespace UnitOfWork.Domain
{
	public abstract class Entity<TId> : IHasChangeTimestamps
	{
		public TId Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime LastUpdatedAt { get; set; }
	}
}