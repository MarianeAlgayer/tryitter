using Auth.Models;
using Tryitter.Context;
using Tryitter.Models;
using Tryitter.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace Tryitter.Test;

public class PostsControllerTest
{
    private readonly AppDbContext _context;
    public static DbContextOptions<AppDbContext> dbContextOptions {get; }
    public static string connectionString = "Server=localhost;DataBase=TryitterDB;Uid=root;Pwd=M@rianeR00T";

    static PostsControllerTest()
    {
        dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString))
            .Options;
    }

    public PostsControllerTest()
    {
        _context = new AppDbContext(dbContextOptions);
    }

    [Fact]
    public void GetPosts_Return_OkResult()
    {
        //Arrange
        var controller = new PostsController(_context);

        //Act
        var data = controller.GetPosts();

        //Assert
        Assert.IsType<OkObjectResult>(data.Result);
    }

    [Fact]
    public void GetPost_Return_OkResult()
    {
        //Arrange
        var controller = new PostsController(_context);
        var postId = 2;

        //Act
        var data = controller.GetPost(postId);

        //Assert
        Assert.IsType<OkObjectResult>(data.Result);
    }

    [Fact]
    public void GetPost_Return_NotFound()
    {
        //Arrange
        var controller = new PostsController(_context);
        var postId = 1000;

        //Act
        var data = controller.GetPost(postId);

        //Assert
        Assert.IsType<NotFoundObjectResult>(data.Result);
    }

    [Fact]
    public void DeletePost_Return_OkResult()
    {
        //Arrange
        var controller = new PostsController(_context);
        var postId = 3;

        //Act
        var data = controller.DeletePost(postId);

        //Assert
        Assert.IsType<OkObjectResult>(data);
    }
}
