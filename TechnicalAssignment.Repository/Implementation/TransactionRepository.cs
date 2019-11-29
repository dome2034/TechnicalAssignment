using TechnicalAssignment.DataAccess;
using TechnicalAssignment.Domain.Implementation;
using TechnicalAssignment.Domain.Interface;
using TechnicalAssignment.Repository.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using System;
using System.Data.Entity.Validation;

namespace TechnicalAssignment.Repository.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {

        public async Task<ITransaction> Get(long internalId)
        {
            using (var context = new TechnicalAssignmentContext())
            {
                return await context.Transactions.FirstOrDefaultAsync(x => x.Id == internalId);
            }
        }
        public async Task<IList<ITransaction>> Get(string currencyCode)
        {
            using (var context = new TechnicalAssignmentContext())
            {
                var res = await context.Transactions.ToListAsync<ITransaction>();
                res = res.FindAll(x => x.CurrencyCode == currencyCode);
                return res;
            }
        }
        public async Task<IList<ITransaction>> Get(long dateStart, long dateEnd)
        {
            using (var context = new TechnicalAssignmentContext())
            {
                var res = await context.Transactions.ToListAsync<ITransaction>();
                res = res.FindAll(x => x.Date >= dateStart || x.Date <= dateEnd);
                return res;
            }
        }
        public async Task<IList<ITransaction>> Get(int status)
        {
            using (var context = new TechnicalAssignmentContext())
            {
                var res = await context.Transactions.ToListAsync<ITransaction>();
                res = res.FindAll(x => (int)x.Status == status);
                return res;
            }
        }

        public async Task<IList<ITransaction>> GetList()
        {
            using (var context = new TechnicalAssignmentContext())
            {
                return await context.Transactions.ToListAsync<ITransaction>();
            }
        }

        public async Task<ITransaction> Save(ITransaction item)
        {
            try
            {
                var context = new TechnicalAssignmentContext();

                    Transaction transaction = new Transaction();
                    transaction = (Transaction)item;
                    context.Transactions.Add(transaction);
                    context.SaveChanges();
                }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            
            return await Get(item.Id);
        }
        public async Task<ITransaction> SaveMany(List<Transaction> items)
        {
            try
            {
                var context = new TechnicalAssignmentContext();

                List<Transaction> transactions = new List<Transaction>();
                transactions = (List<Transaction>)items;
                context.Transactions.AddRange(transactions);
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }

            return await Get(items[0].Id);
        }

        public async Task<ITransaction> Update(ITransaction item)
        {
            return await Save(item);
        }

    }
}
