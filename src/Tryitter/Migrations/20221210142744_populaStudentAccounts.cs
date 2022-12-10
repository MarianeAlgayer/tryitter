using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tryitter.Migrations
{
    public partial class populaStudentAccounts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into StudentAccounts(Name, Email, Password, Status, Module) Values('Byanca Knorst', 'byanca.knorst@xpi.com.br', '123456', 'Trabalhando', 4)");

            mb.Sql("Insert into StudentAccounts(Name, Email, Password, Status, Module) Values('Lázaro Kabib', 'lazaro.kabib@xpi.com.br', '123456', 'Trabalhando', 4)");

            mb.Sql("Insert into StudentAccounts(Name, Email, Password, Status, Module) Values('Mariane Algayer', 'mariane.algayer@xpi.com.br', '123456', 'Trabalhando', 4)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from StudentAccounts");
        }
    }
}
