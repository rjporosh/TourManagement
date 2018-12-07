namespace TourManagementApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAgentInquiryModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AgentInquiries", "Country_Id", "dbo.Countries");
            DropIndex("dbo.AgentInquiries", new[] { "Country_Id" });
            RenameColumn(table: "dbo.AgentInquiries", name: "Country_Id", newName: "CountryId");
            AlterColumn("dbo.AgentInquiries", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.AgentInquiries", "CountryId");
            AddForeignKey("dbo.AgentInquiries", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
            DropColumn("dbo.AgentInquiries", "CountyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AgentInquiries", "CountyId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AgentInquiries", "CountryId", "dbo.Countries");
            DropIndex("dbo.AgentInquiries", new[] { "CountryId" });
            AlterColumn("dbo.AgentInquiries", "CountryId", c => c.Int());
            RenameColumn(table: "dbo.AgentInquiries", name: "CountryId", newName: "Country_Id");
            CreateIndex("dbo.AgentInquiries", "Country_Id");
            AddForeignKey("dbo.AgentInquiries", "Country_Id", "dbo.Countries", "Id");
        }
    }
}
