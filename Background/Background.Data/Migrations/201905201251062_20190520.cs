namespace Background.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20190520 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SystemFuntion",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ParentId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 128),
                        FunctionType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemRole",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(maxLength: 200),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyTime = c.DateTime(),
                        CreatorId = c.Guid(nullable: false),
                        LastModifiedUserId = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SyetemUser",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(),
                        PasswordHash = c.String(nullable: false, maxLength: 100),
                        AuthenticationToken = c.String(),
                        AuthenticationTokenValidTo = c.DateTime(),
                        LastLoginDate = c.DateTime(),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyTime = c.DateTime(),
                        SystemRoleId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SystemRole", t => t.SystemRoleId)
                .Index(t => t.SystemRoleId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemFunctionSystemRole",
                c => new
                    {
                        SystemFunctionId = c.Guid(nullable: false),
                        SystemRoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.SystemFunctionId, t.SystemRoleId })
                .ForeignKey("dbo.SystemRole", t => t.SystemFunctionId, cascadeDelete: true)
                .ForeignKey("dbo.SystemFuntion", t => t.SystemRoleId, cascadeDelete: true)
                .Index(t => t.SystemFunctionId)
                .Index(t => t.SystemRoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SyetemUser", "SystemRoleId", "dbo.SystemRole");
            DropForeignKey("dbo.SystemFunctionSystemRole", "SystemRoleId", "dbo.SystemFuntion");
            DropForeignKey("dbo.SystemFunctionSystemRole", "SystemFunctionId", "dbo.SystemRole");
            DropIndex("dbo.SystemFunctionSystemRole", new[] { "SystemRoleId" });
            DropIndex("dbo.SystemFunctionSystemRole", new[] { "SystemFunctionId" });
            DropIndex("dbo.SyetemUser", new[] { "SystemRoleId" });
            DropTable("dbo.SystemFunctionSystemRole");
            DropTable("dbo.User");
            DropTable("dbo.SyetemUser");
            DropTable("dbo.SystemRole");
            DropTable("dbo.SystemFuntion");
        }
    }
}
