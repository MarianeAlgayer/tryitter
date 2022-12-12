using Auth.Models;
using Tryitter.Context;
using Tryitter.Models;
using Tryitter.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Tryitter.Test;

public class StudentsControllerTest
{
    private readonly AppDbContext _context;
    public static DbContextOptions<AppDbContext> dbContextOptions {get; }
    public static string connectionString = "Server=localhost;DataBase=TryitterDB;Uid=root;Pwd=laza229955";

    static StudentsControllerTest()
    {
        dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString))
            .Options;
    }

    public StudentsControllerTest()
    {
        _context = new AppDbContext(dbContextOptions);
    }

    [Fact]
    public void GetStudentAccounts_Return_OkResult()
    {
        //Arrange
        var controller = new StudentsController(_context);

        //Act
        var data = controller.GetStudents();

        //Assert
        Assert.IsType<IEnumerable<StudentAccount>>(data.Value);
    }
}
