using TechnicalAssignment.Domain.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechnicalAssignment.Repository.Interface
{
    public interface IRepositoryBase<T>
    {
        Task<IList<T>> GetList();
        Task<T> Get(long internalId);
        Task<IList<T>> Get(string currencyCode);
        Task<IList<T>> Get(long dateStart, long dateEnd);
        Task<IList<T>> Get(int status);
        Task<T> Update(T item);
        Task<T> Save(T item);
    }
}
