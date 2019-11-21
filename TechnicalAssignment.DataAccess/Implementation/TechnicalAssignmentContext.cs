using TechnicalAssignment.Domain.Implementation;
using System.Data.Entity;

namespace TechnicalAssignment.DataAccess
{
    public class TechnicalAssignmentContext : DbContext, ITechnicalAssignmentContext
    {
        public TechnicalAssignmentContext() : base("name=TechnicalAssignmentConnectionString")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<TechnicalAssignmentContext>());
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
