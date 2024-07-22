using Microsoft.EntityFrameworkCore;
using webapi.DAL.Database.Entities;

namespace webapi.DAL.Database.DatabaseContext
{
    public class EkwatisoDbContext : DbContext
    {
        public DbSet<TbUser> TbUsers { get; set; }
        public DbSet<TbDoacao> TbDoacoes { get; set; }
        public DbSet<TbCampanha> TbCampanhas { get; set; }
        public DbSet<TbGerente> TbGerentes { get; set; }
        public DbSet<TbCategoria> TbCategorias { get; set; }
        public DbSet<TbPais> TbPaises { get; set; }
        public DbSet<TbProvincia> TbProvincias { get; set; }
    }
}