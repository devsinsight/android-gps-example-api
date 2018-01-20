using System;
using System.Threading.Tasks;

namespace AndroidGPSExample.Domain.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync();
    }
}
