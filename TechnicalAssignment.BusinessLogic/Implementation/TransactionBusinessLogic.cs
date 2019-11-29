using TechnicalAssignment.BusinessLogic.Interface;
using TechnicalAssignment.Domain.Interface;
using TechnicalAssignment.Domain.Implementation;
using TechnicalAssignment.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechnicalAssignment.BusinessLogic.Implementation
{
    // only business logic implementation is allowed.
    public class TransactionBusinessLogic : ITransactionBusinessLogic
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionBusinessLogic(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Task<ITransaction> Get(long internalId)
        {
            return _transactionRepository.Get(internalId);
        }
        public Task<IList<ITransaction>> Get(string currencyCode)
        {
            return _transactionRepository.Get(currencyCode);
        }
        public Task<IList<ITransaction>> Get(long dateStart, long dateEnd)
        {
            return _transactionRepository.Get(dateStart, dateEnd);
        }
        public Task<IList<ITransaction>> Get(int status)
        {
            return _transactionRepository.Get(status);
        }

        public Task<IList<ITransaction>> GetList()
        {
            return _transactionRepository.GetList();
        }

        public Task<ITransaction> Save(ITransaction item)
        {
            return _transactionRepository.Save(item);
        }
        public Task<ITransaction> SaveMany(List<Transaction> items)
        {
            return _transactionRepository.SaveMany(items);
        }

        public Task<ITransaction> Update(ITransaction item)
        {
            return _transactionRepository.Update(item);
        }
    }
}
