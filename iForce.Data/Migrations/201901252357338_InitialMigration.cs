namespace iForce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserRoleId = c.Int(nullable: false),
                        UserStatusId = c.Int(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleId, cascadeDelete: true)
                .ForeignKey("dbo.UserStatus", t => t.UserStatusId, cascadeDelete: true)
                .Index(t => t.UserRoleId)
                .Index(t => t.UserStatusId);
            
            CreateTable(
                "dbo.UserStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserStatusId", "dbo.UserStatus");
            DropForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserStatusId" });
            DropIndex("dbo.Users", new[] { "UserRoleId" });
            DropTable("dbo.UserStatus");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
        }
    }
}
