using Microsoft.EntityFrameworkCore;
using WebApplication1.DBContexts;

namespace TestProject;
public static class ContextGenerator{
    public static AppDBContext GetContext(){

        var options = new DbContextOptionsBuilder<AppDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

        var context = new AppDBContext(options);
        return context;
    }
}