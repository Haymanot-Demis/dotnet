using Microsoft.AspNetCore.Mvc;
using TestProject;
using WebApplication1.Controllers;

[Collection("Sequential")]
public class CommentsUnitTests{
    private readonly CommentsController controller;
    private readonly PostsController postController;

    public CommentsUnitTests()
    {
        // pass the optionsBuilder's options to the context
        var context = ContextGenerator.GetContext();
        
        // set up the mapper 
        var mapper = ContextGenerator.GetMapper();

        // setup the controller with the context
        controller = new CommentsController(context, mapper);
        postController = new PostsController(context, mapper);
    }

    [Fact]
    public async Task Testing_Add_And_GetAll()
    { 
        // Arrange i.e setup the test
            // add a post using the controller and object initializer
            // await postController.Add(new Post{
            // PostId = 1, Title = "Post one", Content = "Post one"
            // });
            
            // await postController.Add(new Post{
            // PostId = 2, Title = "Post two", Content = "Post two"
            // });

        // Add Comments 
        var insert_res1 = await controller.Add(new CreateCommentDto{
            Text = "Comment one", 
            PostId = 1
        });

        var insert_res2 = await controller.Add(new CreateCommentDto
        {
           Text = "Comment two",
           PostId = 2
        });

        // Act i.e call the method to be tested
        var response = controller.GetAll() as OkObjectResult;
        var comments = response.Value as List<Comment>;

        // Assert i.e check if the result is as expected
        Assert.IsType<CreatedAtActionResult>(insert_res1);
        Assert.IsType<CreatedAtActionResult>(insert_res2);
        Assert.NotNull(comments);    
        Assert.Equal(2, comments.Count);    
    }


    [Fact]
    public async Task Test_GetOne()
    {
        // Act i.e call the method to be tested
        var res = controller.GetOne(1) as OkObjectResult;
        var comment = res.Value as Comment;

        // Assert i.e check if the result is as expected
        Assert.Equal(200, res.StatusCode);
        Assert.NotNull(comment);
        Assert.Equal(1, comment.CommentId);
    }


    [Fact]
    public async Task Test_GetOne_IdNotFound()
    {
        // Act i.e call the method to be tested
        var res = controller.GetOne(100);

        // Assert i.e check if the result is as expected
        Assert.IsType<NotFoundResult>(res);
    }

}


[Collection("Sequential")]
public class Update_Comment_Test{

    private readonly CommentsController controller;

    public Update_Comment_Test()
    {
        // set up the mapper 
        var mapper = ContextGenerator.GetMapper();

        // set the context
        var context = ContextGenerator.GetContext();

        // setup the controller with the context and mapper
        controller = new CommentsController(context, mapper);
    }

    [Fact]
    public async Task Test_Update()
    {
        // Arrange i.e setup the test
        var comment = new UpdateCommentDto
        {
            Text = "updated Comment one",
            PostId = 1
        };

        // Act i.e call the method to be tested
        var res = await controller.Update(1, comment) as OkObjectResult;
        var updated_comment = res.Value as Comment;

        // Assert i.e check if the result is as expected
        Assert.Equal(200, res.StatusCode);
        Assert.Equal(comment.Text, updated_comment.Text);
    }

    [Fact]
    public async Task Test_Update_IdNotFound()
    {
        // Arrange i.e setup the test
        var comment = new UpdateCommentDto
        {
            Text = "updated Comment one",
            PostId = 1
        };

        // Act i.e call the method to be tested
        var res = await controller.Update(100, comment);

        // Assert i.e check if the result is as expected
        Assert.IsType<NotFoundResult>(res);
    }
}

[Collection("Sequential")]
public class Delete_Comment_Test{
    private readonly CommentsController controller;

    public Delete_Comment_Test()
    {
        // set up the mapper 
        var mapper = ContextGenerator.GetMapper();

        // set the context
        var context = ContextGenerator.GetContext();

        // setup the controller with the context and mapper
        controller = new CommentsController(context, mapper);
    }

    [Fact]
    public async Task Test_Delete()
    {
        // Act i.e call the method to be tested
        var res = await controller.Delete(1);

        // Assert i.e check if the result is as expected
        Assert.IsType<NoContentResult>(res);
        Assert.IsType<NotFoundResult>(controller.GetOne(1));
    }

    [Fact]
    public async Task Test_Delete_IdNotFound()
    {
        // Act i.e call the method to be tested
        var res = await controller.Delete(100);

        // Assert i.e check if the result is as expected
        Assert.IsType<NotFoundResult>(res);
    }
    
}