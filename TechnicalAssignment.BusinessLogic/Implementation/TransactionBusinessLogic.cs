﻿using TechnicalAssignment.BusinessLogic.Interface;
using TechnicalAssignment.Domain.Interface;
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

        public Task<IList<ITransaction>> GetList()
        {
            return _transactionRepository.GetList();
        }

        public Task<ITransaction> Save(ITransaction item)
        {
            return _transactionRepository.Save(item);
        }

        public Task<ITransaction> Update(ITransaction item)
        {
            return _transactionRepository.Update(item);
        }
    }
}
