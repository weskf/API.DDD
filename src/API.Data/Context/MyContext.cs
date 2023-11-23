using API.Data.Mapping;
using API.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.Entity<UserEntity>(new UserMap().Configure);
        }
    }
}
