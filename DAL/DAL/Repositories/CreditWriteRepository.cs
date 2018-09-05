using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.BusinessModels;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CreditWriteRepository : IWriteRepository<CreditEntity>
    {
        private readonly ApplicationContext _db;

        public CreditWriteRepository(ApplicationContext appContext)
        {
            _db = appContext;
        }

        public async Task Create(CreditEntity credit) => await _db.Credits.AddAsync(credit);

        public async Task Update(CreditEntity credit) => await Task.FromResult(_db.Entry(credit).State = EntityState.Modified);

        public async Task Delete(int id) => _db.Credits.Remove(await _db.Credits.FindAsync(id));
    }
}
