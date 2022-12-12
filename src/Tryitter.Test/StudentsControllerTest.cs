using Auth.Models;
using Tryitter.Context;
using Tryitter.Models;
using Tryitter.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace Tryitter.Test;

public class StudentsControllerTest
{
    private readonly AppDbContext _context;
    public static DbContextOptions<AppDbContext> dbContextOptions {get; }
    public static string connectionString = "Server=localhost;DataBase=TryitterDB;Uid=root;Pwd=M@rianeR00T";

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
    public void GetStudents_Return_OkResult()
    {
        //Arrange
        var controller = new StudentsController(_context);

        //Act
        var data = controller.GetStudents();

        //Assert
        Assert.IsType<OkObjectResult>(data.Result);
    }

    [Fact]
    public void GetStudent_Return_OkResult()
    {
        //Arrange
        var controller = new StudentsController(_context);
        var studentId = 1;

        //Act
        var data = controller.GetStudent(studentId);

        //Assert
        Assert.IsType<OkObjectResult>(data.Result);
    }

    [Fact]
    public void GetStudent_Return_NotFound()
    {
        //Arrange
        var controller = new StudentsController(_context);
        var studentId = 1000;

        //Act
        var data = controller.GetStudent(studentId);

        //Assert
        Assert.IsType<NotFoundObjectResult>(data.Result);
    }

    [Fact]
    public void PostStudent_Return_CreatedResult()
    {
        //Arrange
        var controller = new StudentsController(_context);
        var newStudent = new StudentAccount() { Name = "Mariane Algayer", Email = "mariane.algayer@xpi.com.br", Password = "123456", Status = "Trabalhando", Module = 4 };

        //Act
        var data = controller.PostStudent(newStudent);

        //Assert
        Assert.IsType<CreatedAtRouteResult>(data);
    }

    [Fact]
    public void DeleteStudent_Return_OkResult()
    {
        //Arrange
        var controller = new StudentsController(_context);
        var studentId = 1;

        //Act
        var data = controller.DeleteStudent(studentId);

        //Assert
        Assert.IsType<OkObjectResult>(data);
    }
}
