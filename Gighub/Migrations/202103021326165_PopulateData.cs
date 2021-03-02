namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (Id, Name) VALUES (1, 'Jazz')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (2, 'Blues')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (3, 'Rock')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (4, 'Country')");
        }
   
        public override void Down()
        {
            Sql("Delete From Genres Where Id In (1, 2, 3, 4)");
        }
    }
}
