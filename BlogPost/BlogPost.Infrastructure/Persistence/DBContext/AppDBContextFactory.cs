using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Infrastructure.Persistence.DBContext
{
    public class AppDBContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder
().SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\BlogPost.Api"))
  .AddJsonFile("appsettings.json")
  .Build();
            var builder = new DbContextOptionsBuilder<AppDBContext>();
            var connectionString = configuration.GetConnectionString("BlogPost");

            builder.UseNpgsql(connectionString);

            return new AppDBContext(builder.Options);
        }
    }
}
