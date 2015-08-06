using System;

namespace UnitOfWork.Domain
{
	public interface IHasChangeTimestamps
	{
		DateTime CreatedAt { get; set; }
		DateTime LastUpdatedAt { get; set; }
	}
}