using System;

namespace UnitOfWork.Data.Entity
{
    public interface IDbContextFactory<out TDbContext> where TDbContext : DbContext
    {
        TDbContext Create();
    }
}