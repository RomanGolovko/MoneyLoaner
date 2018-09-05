using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IWriteRepository<T> where T : class
    {
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}
