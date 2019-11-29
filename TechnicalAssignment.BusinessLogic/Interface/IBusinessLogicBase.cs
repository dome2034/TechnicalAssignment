using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechnicalAssignment.BusinessLogic.Interface
{
    public interface IBusinessLogicBase<T> where T : class
    {
        Task<IList<T>> GetList();
        Task<T> Get(long internalId);
        Task<T> Update(T item);
        Task<T> Save(T item);
    }
}
