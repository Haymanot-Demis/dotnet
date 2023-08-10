using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;
using WebApplication1.DBContexts;

namespace TestProject
{
    public class PostsUnitTest
    {   
        private readonly PostsController controller;

        // Constructor for initializing the controller
        public PostsUnitTest()
        {
            // setup the inmemory database for testing using the options builder
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>()
                            .UseInMemoryDatabase("TestDB");
            // pass the optionsBuilder's options to the context
            var context = new AppDBContext(optionsBuilder.Options);

            // setup the controller with the context
            controller = new PostsController(context);
        }

        [Fact]
        public async Task Testing_Add_And_GetAll()
        { 
            // var controller = GenerateController();

            // Arrange i.e setup the test
            // add a post using the controller and object initializer
            var insert_res1 = await controller.Add(new Post{
            PostId = 1, Title = "Post one", Content = "Post one"
            });

            var insert_res2 = await controller.Add(new Post
            {
               PostId = 2,
               Title = "Post two",
               Content = "Post two"
            });

            // Act i.e call the method to be tested
            var response = controller.GetAll() as OkObjectResult;
            var posts = response.Value as List<Post>;

            // Assert i.e check if the result is as expected
            Assert.IsType<CreatedAtActionResult>(insert_res1);
            Assert.IsType<CreatedAtActionResult>(insert_res2);
            Assert.NotNull(posts);    
            Assert.Equal(2, posts.Count);    
        }

        [Fact]
        public async Task Test_GetOne()
        {
            // Act i.e call the method to be tested
            var res = await controller.GetOne(1) as OkObjectResult;
            var post = res.Value as Post;

            // Assert i.e check if the result is as expected
            Assert.Equal(200, res.StatusCode);
            Assert.Equal(1, post.PostId);
            // Assert.Equal("Post one", post.Title);
        }

        [Fact]
        public async Task Test_Add_Duplicate()
        {
            // var controller = GenerateController();

            // Arrange i.e setup the test
            var post = new Post{
               PostId = 1, Title = "Post one", Content = "Post one"
            };

            // Act and Assert at the same time
            await Assert.ThrowsAsync<ArgumentException>(() => controller.Add(post));
        }

        [Fact]
        public async Task Test_Update()
        {
            // var controller = GenerateController();

            // Arrange i.e setup the test
            var post = new Post{
                PostId = 1,
               Title = "updated post", Content = "updated Post one"
            };

            // Act i.e call the method to be tested
            var res = await controller.Update(1, post) as OkObjectResult;
            var updated_post = res.Value as Post;

            // Assert i.e check if the result is as expected
            Assert.Equal(200, res.StatusCode);
            Assert.Equal(updated_post.Title, post.Title);
            Assert.Equal(updated_post.Content, post.Content);
        }

        [Fact]
        public void Test_Delete()
        {
            // var controller = GenerateController();

            // Act i.e call the method to be tested
            var res = controller.Delete(1);

            // Assert i.e check if the result is as expected
            Assert.IsType<NoContentResult>(res);
        }

    }
}