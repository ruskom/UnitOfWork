using System;
using JetBrains.Annotations;

namespace UnitOfWork.Data.Entity
{
    public class SimpleDbContextFactory<TDbContext> : IDbContextFactory<TDbContext> where TDbContext : DbContext
    {
        public SimpleDbContextFactory([NotNull] Func<TDbContext> createDbContext)
        {
	        if (createDbContext == null)
	        {
		        throw new ArgumentNullException(nameof(createDbContext));
	        }

	        CreateDbContext = createDbContext;
        }

	    private Func<TDbContext> CreateDbContext { get; }

        public TDbContext Create() => CreateDbContext();
    }
}