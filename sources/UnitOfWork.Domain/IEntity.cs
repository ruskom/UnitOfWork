using System;

namespace UnitOfWork.Domain
{
	public interface IEntity<TId>
	{
		TId Id { get; set; }
		DateTime CreatedAt { get; set; }
		DateTime ModifiedAt { get; set; }
	}
}