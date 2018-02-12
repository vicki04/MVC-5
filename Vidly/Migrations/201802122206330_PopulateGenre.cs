namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres(Id,GenreName) values(1,'Comedy')");
            Sql("insert into Genres(Id,GenreName) values(2,'Drama')");
            Sql("insert into Genres(Id,GenreName) values(3,'Romance')");
            Sql("insert into Genres(Id,GenreName) values(4,'Thriller')");
            Sql("insert into Genres(Id,GenreName) values(5,'Horror')");
            Sql("insert into Genres(Id,GenreName) values(6,'SciFi')");
        }
        
        public override void Down()
        {
        }
    }
}
