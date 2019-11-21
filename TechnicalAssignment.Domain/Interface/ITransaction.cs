using TechnicalAssignment.Domain.Enum;

namespace TechnicalAssignment.Domain.Interface
{
    public interface ITransaction : IDomainBase
    {
        string TransactionId { get; set; }
        double Amount { get; set; }
        string CurrencyCode { get; set; }
        long Date { get; set; }
        TransactionStatus Status { get; set; }
    }
}
