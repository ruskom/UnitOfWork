using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace UnitOfWork.Data.Entity
{
	public abstract class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
	{
		protected UnitOfWork([NotNull] IDbContextFactory<TDbContext> dbContextFactory)
		{
			if (dbContextFactory == null)
			{
				throw new ArgumentNullException(nameof(dbContextFactory));
			}

			DbContextFactory = dbContextFactory;
			DbContext = DbContextFactory.Create();
		}

		private IDbContextFactory<TDbContext> DbContextFactory { get; }
		protected TDbContext DbContext { get; set; }
		private bool IsDisposed { get; set; }

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public Task SaveAsync()
		{
			if (IsDisposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}

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
				DbContext?.Dispose();
			}

			IsDisposed = true;
		}
	}
}