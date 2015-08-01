using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace UnitOfWork.Data.Entity
{
	public abstract class DbContextUnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext, new()
	{
		protected TDbContext DbContext { get; set; }
		private bool IsDisposed { get; set; }

		protected DbContextUnitOfWork()
		{
			DbContext = new TDbContext();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public Task SaveAsync()
		{
			return DbContext.SaveChangesAsync();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (IsDisposed)
			{
				return;
			}

			if (disposing)
			{
				DbContext.Dispose();
			}

			IsDisposed = true;
		}
	}
}