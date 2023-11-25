using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var connString = "Server=localhost;Port=3306;Database=dbapi;Uid=root;Pwd=jedite94";
            var optBuilder = new DbContextOptionsBuilder<MyContext>();
            optBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString));

            return new MyContext(optBuilder.Options);
        }
    }
}
