using TechnicalAssignment.Domain.Enum;
using TechnicalAssignment.Domain.Interface;
using TechnicalAssignment.Utils;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
