using TechnicalAssignment.Domain.Enum;

namespace TechnicalAssignment.Domain.Interface
{
    public interface ITransactionOutput
    {
        string Id { get; set; }

        string Payment { get; set; }

        TransactionStatus Status { get; set; }
    }
}
