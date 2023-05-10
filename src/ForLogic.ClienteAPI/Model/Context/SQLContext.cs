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
            modelBuilder.Entity<Cliente>().HasData(new Cliente
            {
                Id = 1,
                NomeCliente = "Cliente A",
                NomeContato = "Cliente A Contato",
                Cnpj = "11111111000111",
                DataInsercao = DateTime.Now
            });
            modelBuilder.Entity<Cliente>().HasData(new Cliente
            {
                Id = 2,
                NomeCliente = "Cliente B",
                NomeContato = "Cliente B Contato",
                Cnpj = "XX.XXX.XXX/0001-XX",
                DataInsercao = DateTime.Now
            });

        }
    }
}
