namespace AcademyTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Friends : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Relationships = c.String(),
                        First_user_Id = c.String(maxLength: 128),
                        Second_user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.First_user_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Second_user_Id)
                .Index(t => t.First_user_Id)
                .Index(t => t.Second_user_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "Second_user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "First_user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Friends", new[] { "Second_user_Id" });
            DropIndex("dbo.Friends", new[] { "First_user_Id" });
            DropTable("dbo.Friends");
        }
    }
}
