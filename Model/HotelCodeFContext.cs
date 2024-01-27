using Microsoft.EntityFrameworkCore;

namespace HotelEntity
{
    public class HotelCodeFContext : DbContext
    {
        public DbSet<Cliente> Cliente {get; set;} = null!;
        public DbSet<Funcionario> Funcionario {get; set;} = null!;
        public DbSet<Quartos> Quartos {get; set;} = null!;
        public DbSet<Lavanderia> Lavanderia {get; set;} = null!;
        public DbSet<Restaurante> Restaurante {get; set;} = null!;
        public DbSet<Frigobar> Frigobar {get; set;} = null!;
        public DbSet<Filial> Filial {get; set;} = null!;
        public DbSet<NotaFiscal> NotaFiscal {get; set;} = null!;
        public DbSet<Reservas> Reserva {get; set;} = null!;
        public DbSet<ServicoFrigobar> ServicoFrigobar {get; set;} = null!;
        public DbSet<ServicoLavanderia> ServicoLavanderia {get; set;} = null!;
        public DbSet<Pedido> Pedido {get; set;} = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=HotelEntity;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
    }
}