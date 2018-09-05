using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IReadService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllCredits();
        Task<T> GetCreditById(int id);
    }
}
