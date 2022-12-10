using Tryitter.Models;
using Tryitter.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Tryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentAccount>> GetStudents()
        {
            try
            {
                var studentAccounts = _context.StudentAccounts.ToList();

                if (studentAccounts is null)
                {
                    return NotFound("Nenhum estudante encontrado.");
                }

                return Ok(studentAccounts);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado.");
            }
        }

        [HttpGet("{id:int}", Name = "GetStudent")]
        public ActionResult<StudentAccount> GetStudent(int id)
        {
            try
            {
                var studentAccount = _context.StudentAccounts.FirstOrDefault(s => s.StudentAccountId == id);

                if (studentAccount is null)
                {
                    return NotFound("Estudante não encontrado.");
                }

                return Ok(studentAccount);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado.");
            }
            
        }

        [HttpPost]
        public ActionResult PostStudent(StudentAccount studentAccount)
        {
            if (studentAccount is null) return BadRequest("Dados inválidos.");

            _context.StudentAccounts.Add(studentAccount);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetStudent", new { id = studentAccount.StudentAccountId }, studentAccount);
        }

        [HttpPut("{id:int}")]
        public ActionResult PutStudent(int id, StudentAccount studentAccount)
        {
            if (id != studentAccount.StudentAccountId) return BadRequest("Id não encontrado.");

            _context.Entry(studentAccount).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(studentAccount);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteStudent(int id)
        {
            var studentAccount = _context.StudentAccounts.FirstOrDefault(s => s.StudentAccountId == id);

            if (studentAccount is null) return NotFound("Estudante não encontrado.");

            _context.StudentAccounts.Remove(studentAccount);
            _context.SaveChanges();

            return Ok(studentAccount);
        }
    }
}
