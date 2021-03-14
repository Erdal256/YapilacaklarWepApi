using System.Data.Entity;
using YapilacaklarWebApi.Entities;

namespace YapilacaklarWebApi.Contexts
{
    public class YapilacaklarContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Yapilacak> Yapilacaklar { get; set; }

        public YapilacaklarContext() : base("YapilacaklarContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)//migrationlarda v1 de kullanılars ve yapılacaklar düzeltiliyot
        {
            modelBuilder.Entity<Kullanici>().ToTable("Kullanicilar");
            modelBuilder.Entity<Yapilacak>().ToTable("Yapilacaklar")
                .HasRequired(y => y.Kullanici)
                .WithMany(k => k.Yapilacaklar)     
                .HasForeignKey(y => y.KullaniciId)
                .WillCascadeOnDelete(false);

        }
    }
}