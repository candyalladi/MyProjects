namespace TweetnHash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSocialMediaTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FaceBookAccounts",
                c => new
                    {
                        FaceBookId = c.Int(nullable: false, identity: true),
                        CheckAccount = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FaceBookId);
            
            CreateTable(
                "dbo.SocialMediaAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        FaceBookAccount_FaceBookId = c.Int(),
                        SocialUser_Id = c.String(maxLength: 128),
                        TwitterAccount_TwitterId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FaceBookAccounts", t => t.FaceBookAccount_FaceBookId)
                .ForeignKey("dbo.AspNetUsers", t => t.SocialUser_Id)
                .ForeignKey("dbo.TwitterAccounts", t => t.TwitterAccount_TwitterId)
                .Index(t => t.FaceBookAccount_FaceBookId)
                .Index(t => t.SocialUser_Id)
                .Index(t => t.TwitterAccount_TwitterId);
            
            CreateTable(
                "dbo.TwitterAccounts",
                c => new
                    {
                        TwitterId = c.Int(nullable: false, identity: true),
                        CheckAccount = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TwitterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialMediaAccounts", "TwitterAccount_TwitterId", "dbo.TwitterAccounts");
            DropForeignKey("dbo.SocialMediaAccounts", "SocialUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SocialMediaAccounts", "FaceBookAccount_FaceBookId", "dbo.FaceBookAccounts");
            DropIndex("dbo.SocialMediaAccounts", new[] { "TwitterAccount_TwitterId" });
            DropIndex("dbo.SocialMediaAccounts", new[] { "SocialUser_Id" });
            DropIndex("dbo.SocialMediaAccounts", new[] { "FaceBookAccount_FaceBookId" });
            DropTable("dbo.TwitterAccounts");
            DropTable("dbo.SocialMediaAccounts");
            DropTable("dbo.FaceBookAccounts");
        }
    }
}
