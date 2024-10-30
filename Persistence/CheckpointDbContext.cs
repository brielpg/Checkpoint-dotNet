using Checkpoint1GabrielPescarolli.Models;
using Microsoft.EntityFrameworkCore;

namespace Checkpoint1GabrielPescarolli.Persistence
{
    public class CheckpointDbContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public CheckpointDbContext(DbContextOptions<CheckpointDbContext> options) : base(options)
        {

        }
    }
}
