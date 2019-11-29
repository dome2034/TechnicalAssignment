using TechnicalAssignment.BusinessLogic.Interface;
using TechnicalAssignment.Domain.Implementation;
using TechnicalAssignment.Domain.Interface;
using TechnicalAssignment.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace TechnicalAssignment.Service.Controllers
{
    // api/transactions
    public class TransactionsController : ApiControllerBase
    {
        private readonly ITransactionBusinessLogic _transactionBusinessLogic;

        public TransactionsController(ITransactionBusinessLogic transactionBusinessLogic)
        {
            _transactionBusinessLogic = transactionBusinessLogic;
        }

        // GET api/transactions
        public async Task<HttpResponseMessage> Get()
        {
            IList<ITransaction> transactions = await _transactionBusinessLogic.GetList();
            return CreateResponse(transactions);
        }
        // GET api/transactions/id
        public async Task<HttpResponseMessage> Get(long id)
        {
            ITransaction transaction = await _transactionBusinessLogic.Get(id);
            return CreateResponse(transaction);
        }
        // GET api/transactions/currencyCode
        public async Task<HttpResponseMessage> Get(string currencyCode)
        {
            IList<ITransaction> transaction = await _transactionBusinessLogic.Get(currencyCode);
            return CreateResponse(ConvertToOutput(transaction));
        }
        // GET api/transactions/id
        public async Task<HttpResponseMessage> Get(long dateStart, long dateEnd)
        {
            IList<ITransaction> transaction = await _transactionBusinessLogic.Get(dateStart, dateEnd);
            return CreateResponse(ConvertToOutput(transaction));
        }
        // GET api/transactions/id
        public async Task<HttpResponseMessage> Get(int status)
        {
            IList<ITransaction> transaction = await _transactionBusinessLogic.Get(status);
            return CreateResponse(ConvertToOutput(transaction));
        }
        // POST api/transactions
        public async Task<HttpResponseMessage> Post(List<Transaction> transactions)
        {
            ITransaction res = await _transactionBusinessLogic.SaveMany(transactions);
            return CreateResponse(res);
        }
        private List<TransactionOutput> ConvertToOutput(IList<ITransaction> transaction)
        {
            var output = new List<TransactionOutput>();
            transaction.ToList().ForEach(t =>
            {
                output.Add(new TransactionOutput
                {
                    Id = t.TransactionId.ToString(),
                    Payment = t.Amount.ToString() + " " + t.CurrencyCode.ToString(),
                    Status = t.Status
                });
            });
            return output;
        }
    }
}