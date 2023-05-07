using Microsoft.EntityFrameworkCore;

namespace ForLogic.ClienteAPI.Model.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext() {}
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) {}

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
