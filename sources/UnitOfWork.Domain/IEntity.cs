using System;

namespace UnitOfWork.Domain
{
	// TODO: check if interface is needed
	public interface IEntity<TId>
	{
		TId Id { get; set; }
		DateTime CreatedAt { get; set; }
		DateTime LastUpdateAt { get; set; }
	}
}