namespace TechnicalAssignment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TechnicalAssignment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TransactionId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        CurrencyCode = c.String(),
                        Date = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transactions");
        }
    }
}
