using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IWriteService<T> where T : class
    {
        Task UpsertCredit(T item);
        Task RemoveCredit(int id);
    }
}
