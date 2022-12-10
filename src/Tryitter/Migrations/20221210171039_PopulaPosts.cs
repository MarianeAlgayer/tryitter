using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tryitter.Migrations
{
    public partial class PopulaPosts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Posts(Text, ImageUrl, PostDate, StudentAccountId) Values('Hello World', 'image1.jpg', now(), 1)");

            mb.Sql("Insert into Posts(Text, ImageUrl, PostDate, StudentAccountId) Values('Hello World', 'image2.jpg', now(), 2)");

            mb.Sql("Insert into Posts(Text, ImageUrl, PostDate, StudentAccountId) Values('Hello World', 'image3.jpg', now(), 3)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Posts");
        }
    }
}
