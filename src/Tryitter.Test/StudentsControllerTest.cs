using Auth.Models;
using Tryitter.Context;

namespace Tryitter.Test;

public class StudentsControllerTest
{
    private readonly AppDbContext _context;
    public StudentsController(AppDbContext context)
    {
        _context = context;
    }

    [Fact]
    public void Test1()
    {
        var login = new Login();
    }
}
