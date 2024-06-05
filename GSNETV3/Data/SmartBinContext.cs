namespace GSNETV3.Data {
    using Microsoft.EntityFrameworkCore;
    using GSNETV3.Models; 

    public class SmartBinContext : DbContext {
        public SmartBinContext(DbContextOptions<SmartBinContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Lixeira> Lixeiras { get; set; }
        public DbSet<ItemLixeira> ItemLixeira { get; set; }
        public DbSet<Pontos> Pontos { get; set; }
    }

}