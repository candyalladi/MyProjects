namespace TweetnHash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForSocialMediaAccounts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SocialMediaAccounts", "FaceBookAccount_FaceBookId", "dbo.FaceBookAccounts");
            DropForeignKey("dbo.SocialMediaAccounts", "SocialUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SocialMediaAccounts", "TwitterAccount_TwitterId", "dbo.TwitterAccounts");
            DropIndex("dbo.SocialMediaAccounts", new[] { "FaceBookAccount_FaceBookId" });
            DropIndex("dbo.SocialMediaAccounts", new[] { "SocialUser_Id" });
            DropIndex("dbo.SocialMediaAccounts", new[] { "TwitterAccount_TwitterId" });
            AlterColumn("dbo.SocialMediaAccounts", "FaceBookAccount_FaceBookId", c => c.Int(nullable: false));
            AlterColumn("dbo.SocialMediaAccounts", "SocialUser_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SocialMediaAccounts", "TwitterAccount_TwitterId", c => c.Int(nullable: false));
            CreateIndex("dbo.SocialMediaAccounts", "FaceBookAccount_FaceBookId");
            CreateIndex("dbo.SocialMediaAccounts", "SocialUser_Id");
            CreateIndex("dbo.SocialMediaAccounts", "TwitterAccount_TwitterId");
            AddForeignKey("dbo.SocialMediaAccounts", "FaceBookAccount_FaceBookId", "dbo.FaceBookAccounts", "FaceBookId", cascadeDelete: true);
            AddForeignKey("dbo.SocialMediaAccounts", "SocialUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SocialMediaAccounts", "TwitterAccount_TwitterId", "dbo.TwitterAccounts", "TwitterId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialMediaAccounts", "TwitterAccount_TwitterId", "dbo.TwitterAccounts");
            DropForeignKey("dbo.SocialMediaAccounts", "SocialUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SocialMediaAccounts", "FaceBookAccount_FaceBookId", "dbo.FaceBookAccounts");
            DropIndex("dbo.SocialMediaAccounts", new[] { "TwitterAccount_TwitterId" });
            DropIndex("dbo.SocialMediaAccounts", new[] { "SocialUser_Id" });
            DropIndex("dbo.SocialMediaAccounts", new[] { "FaceBookAccount_FaceBookId" });
            AlterColumn("dbo.SocialMediaAccounts", "TwitterAccount_TwitterId", c => c.Int());
            AlterColumn("dbo.SocialMediaAccounts", "SocialUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.SocialMediaAccounts", "FaceBookAccount_FaceBookId", c => c.Int());
            CreateIndex("dbo.SocialMediaAccounts", "TwitterAccount_TwitterId");
            CreateIndex("dbo.SocialMediaAccounts", "SocialUser_Id");
            CreateIndex("dbo.SocialMediaAccounts", "FaceBookAccount_FaceBookId");
            AddForeignKey("dbo.SocialMediaAccounts", "TwitterAccount_TwitterId", "dbo.TwitterAccounts", "TwitterId");
            AddForeignKey("dbo.SocialMediaAccounts", "SocialUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.SocialMediaAccounts", "FaceBookAccount_FaceBookId", "dbo.FaceBookAccounts", "FaceBookId");
        }
    }
}
