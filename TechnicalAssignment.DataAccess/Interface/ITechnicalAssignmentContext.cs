using TechnicalAssignment.Domain.Implementation;
using System;
using System.Data.Entity;

namespace TechnicalAssignment.DataAccess
{
    public interface ITechnicalAssignmentContext : IDisposable
    {
        DbSet<Transaction> Transactions { get; set; }
    }
}
