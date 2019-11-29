using TechnicalAssignment.Domain.Enum;
using TechnicalAssignment.Domain.Interface;
using TechnicalAssignment.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace TechnicalAssignment.Domain.Implementation
{
    public class Transaction : DomainBase, ITransaction
    {
        public Transaction()
        {
            Date = DateTime.Now.ToUnixTimestamp();
        }

        public virtual string TransactionId { get; set; }

        [RegularExpression(@"^\d+(?:\.\d{0,2})?$")]
        [Range(0, 9999999999999999.99)]
        public virtual double Amount { get; set; }

        public virtual string CurrencyCode { get; set; }

        public virtual long Date { get; set; }

        public virtual TransactionStatus Status { get; set; }

    }
}
