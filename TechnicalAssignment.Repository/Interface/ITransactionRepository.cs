using TechnicalAssignment.Domain.Interface;
using TechnicalAssignment.Domain.Implementation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechnicalAssignment.Repository.Interface
{
    public interface ITransactionRepository : IRepositoryBase<ITransaction>
    {
        Task<IList<ITransaction>> Get(string currencyCode);
        Task<IList<ITransaction>> Get(long dateStart, long dateEnd);
        Task<IList<ITransaction>> Get(int status);
        Task<ITransaction> SaveMany(List<Transaction> items);
    }
}
