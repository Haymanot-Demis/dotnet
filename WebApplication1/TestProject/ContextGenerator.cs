using AutoMapper;
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

    public static Mapper GetMapper(){
        var config = new MapperConfiguration(cfg => {
            cfg.AddProfile<AutomapperProfile>();
        });
        return new Mapper(config);
    }
}