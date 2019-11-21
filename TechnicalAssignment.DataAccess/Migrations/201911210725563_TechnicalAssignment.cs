namespace TechnicalAssignment.DataAccess
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TechnicalAssignment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "TransactionId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "TransactionId", c => c.Int(nullable: false));
        }
    }
}
