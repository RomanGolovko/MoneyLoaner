using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CreditReadRepository : IReadRepository<CreditEntity>
    {
        private readonly ApplicationContext _db;

        public CreditReadRepository(ApplicationContext appContext)
        {
            _db = appContext;
        }

        public async Task<IEnumerable<CreditEntity>> GetAll() => await _db.Credits.Include(b => b.Borrower).Include(a => a.Borrower.Address).ToListAsync();

        public async Task<CreditEntity> Get(int id) => await _db.Credits.FindAsync(id);

        public async Task<IEnumerable<CreditEntity>> Find(Func<CreditEntity, bool> predicate) 
            => await Task.FromResult(_db.Credits.Include(b => b.Borrower).Include(a => a.Borrower.Address).Where(predicate).ToList());
    }
}
