using DAL.EF;
using DAL.Interfaces;
using Models.BusinessModels;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _db;
        private CreditReadRepository _creditReadRepository;
        private CreditWriteRepository _creditWriteRepository;

        public EFUnitOfWork() => _db = new ApplicationContextFactory().CreateDbContext(new string[1]);

        public IReadRepository<CreditEntity> ReadCredits => _creditReadRepository ?? (_creditReadRepository = new CreditReadRepository(_db));

        public IWriteRepository<CreditEntity> WriteCredits => _creditWriteRepository ?? (_creditWriteRepository = new CreditWriteRepository(_db));

        public async Task Save() => await _db.SaveChangesAsync();

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
