namespace YapilacaklarWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yapilacaklar", "Gorev", c => c.String(nullable: false));
            DropColumn("dbo.Yapilacaklar", "Görev");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Yapilacaklar", "Görev", c => c.String(nullable: false));
            DropColumn("dbo.Yapilacaklar", "Gorev");
        }
    }
}
