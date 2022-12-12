using Tryitter.Context;
using Tryitter.Models;

namespace Tryitter.Test
{
    public class DBUnitTestsMockInitializer
    {
        public DBUnitTestsMockInitializer()
        { }
        public void Seed(AppDbContext context)
        {
            context.StudentAccounts.Add
            (new StudentAccount { Name = "Byanca Knorst", Email = "byanca.knorst@xpi.com.br", Password = "123456", Status = "Trabalhando", Module = 4 });

            context.StudentAccounts.Add
            (new StudentAccount { Name = "Lázaro Kabib", Email = "lazaro.kabib@xpi.com.br", Password = "123456", Status = "Trabalhando", Module = 4 });

            context.StudentAccounts.Add
            (new StudentAccount { Name = "Mariane Algayer", Email = "mariane.algayer@xpi.com.br", Password = "123456", Status = "Trabalhando", Module = 4 });

            context.SaveChanges();
        }

    }
}
