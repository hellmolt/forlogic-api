using Microsoft.EntityFrameworkCore;

namespace ForLogic.AvaliacaoAPI.Model.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext() {}
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) {}
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<AvaliacaoCliente> AvaliacoesDosClientes { get; set; }
        public DbSet<CategoriaNota> CategoriasDeNota { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Dados Iniciais 
            //Clientes
            modelBuilder.Entity<Cliente>().HasData(new Cliente
            {
                Id = 1,
                NomeCliente = "Cliente A",
                NomeContato = "Cliente A Contato",
                Cnpj = "10.234.111/0001-01",
                DataInsercao = DateTime.Now
            });
            modelBuilder.Entity<Cliente>().HasData(new Cliente
            {
                Id = 2,
                NomeCliente = "Cliente B",
                NomeContato = "Cliente B Contato",
                Cnpj = "10.334.111/0001-01",
                DataInsercao = DateTime.Now
            });

            //Categoria Nota
            modelBuilder.Entity<CategoriaNota>().HasData(new CategoriaNota
            {
                Id = 1,
                NotaMinima = 0,
                NotaMaxima = 6,
                NomeCategoria = "Detratores"                
            });
            modelBuilder.Entity<CategoriaNota>().HasData(new CategoriaNota
            {
                Id = 2,
                NotaMinima = 7,
                NotaMaxima = 8,
                NomeCategoria = "Neutros"
            });
            modelBuilder.Entity<CategoriaNota>().HasData(new CategoriaNota
            {
                Id = 3,
                NotaMinima = 9,
                NotaMaxima = 10,
                NomeCategoria = "Promotores"
            });


            //Avaliacao
            modelBuilder.Entity<Avaliacao>().HasData(new Avaliacao
            {
                Id = 1,
                DataReferencia = new DateTime(2023, 4, 1)               
            });
            modelBuilder.Entity<Avaliacao>().HasData(new Avaliacao
            {
                Id = 2,
                DataReferencia = new DateTime(2023, 5, 1)
            });

            //AvaliacaoCliente
            //modelBuilder.Entity<AvaliacaoCliente>().HasData(new AvaliacaoCliente
            //{
            //    Id = 1,
            //    AvaliacaoId = 3,
            //    Avaliacao = new Avaliacao
            //    {
            //        Id = 3,
            //        DataReferencia = new DateTime(2023, 4, 1)
            //    },
            //    CategoriaNotaId = 1,
            //    CategoriaNota = new CategoriaNota
            //    {
            //        Id = 1,
            //        NotaMinima = 0,
            //        NotaMaxima = 6,
            //        NomeCategoria = "Detratores"
            //    }, 
            //    ClienteId = 1,
            //    Cliente = new Cliente
            //    {
            //        Id = 1,
            //        NomeCliente = "Cliente A",
            //        NomeContato = "Cliente A Contato",
            //        Cnpj = "10.234.111/0001-01",
            //        DataInsercao = DateTime.Now
            //    },
            //    DataAvaliacao = new DateTime(2023, 4, 10),
            //    Motivo = "Nao gostei",
            //    Nota = 1
            //});
            //modelBuilder.Entity<AvaliacaoCliente>().HasData(new AvaliacaoCliente
            //{
            //    Id = 2,
            //    AvaliacaoId = 1,
            //    Avaliacao = new Avaliacao
            //    {
            //        Id = 1,
            //        DataReferencia = new DateTime(2023, 4, 1)
            //    },
            //    CategoriaNotaId = 4,
            //    CategoriaNota = new CategoriaNota
            //    {
            //        Id = 3,
            //        NotaMinima = 9,
            //        NotaMaxima = 10,
            //        NomeCategoria = "Promotores"
            //    },
            //    ClienteId = 2,
            //    Cliente = new Cliente
            //    {
            //        Id = 2,
            //        NomeCliente = "Cliente B",
            //        NomeContato = "Cliente B Contato",
            //        Cnpj = "10.334.111/0001-01",
            //        DataInsercao = DateTime.Now
            //    },
            //    DataAvaliacao = new DateTime(2023, 4, 10),
            //    Motivo = "Gostei bastante!",
            //    Nota = 10
            //});

        }
    }
}
