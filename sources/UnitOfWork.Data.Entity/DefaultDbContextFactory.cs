using System;

namespace UnitOfWork.Data.Entity
{
    public class DefaultDbContextFactory<TDbContext> : SimpleDbContextFactory<TDbContext> where TDbContext : DbContext, new()
    {
        public DefaultDbContextFactory() : base(() => new TDbContext())
        {
        }
    }
}