using Auth.Models;
using Tryitter.Context;

namespace Tryitter.Repository
{
    public class StudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Login GetStudent(Login login)
        {
            if(string.IsNullOrEmpty(login.Name) || string.IsNullOrEmpty(login.Password))
            {
                throw new NullReferenceException("Preencha todos os campos.");
            }

            var student = _context.StudentAccounts.First(s => s.Name == login.Name && s.Password == login.Password);
            var loginData = new Login(){ Name = student.Name, Password = student.Password };

            return loginData;
        }
    }
}