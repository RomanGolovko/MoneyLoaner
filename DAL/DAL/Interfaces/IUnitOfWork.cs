using Models.BusinessModels;
using System;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IReadRepository<CreditEntity> ReadCredits { get; }
        IWriteRepository<CreditEntity> WriteCredits { get; }
        Task Save();
    }
}
