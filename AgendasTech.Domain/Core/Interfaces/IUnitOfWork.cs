using Microsoft.EntityFrameworkCore;

namespace AgendasTech.Domain.Core.Interfaces
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        Task<int> SaveChanges();
    }
}
