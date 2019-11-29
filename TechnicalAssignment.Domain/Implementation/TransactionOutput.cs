using TechnicalAssignment.Domain.Enum;
using TechnicalAssignment.Domain.Interface;

namespace TechnicalAssignment.Domain.Implementation
{
    public class TransactionOutput : ITransactionOutput
    {
        public TransactionOutput()
        {
        }
        public virtual string Id { get; set; }

        public virtual string Payment { get; set; }

        public virtual TransactionStatus Status { get; set; }

    }
}
