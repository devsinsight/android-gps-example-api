using AndroidGPSExample.Domain.Contract;
using AndroidGPSExample.Repository.Context;
using System;
using System.Threading.Tasks;

namespace AndroidGPSExample.Repository.Configuration
{
    public class UnitOfWork : IUnitOfWork
    {
        public GeoLocationDbContext context;

        public UnitOfWork(GeoLocationDbContext context)
        {
            this.context = context;
        }

        public void Commit() => context.SaveChanges();

        public async Task CommitAsync() => await context.SaveChangesAsync();

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
                context.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
