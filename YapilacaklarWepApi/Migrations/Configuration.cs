namespace YapilacaklarWepApi.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using YapilacaklarWebApi.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<YapilacaklarWebApi.Contexts.YapilacaklarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(YapilacaklarWebApi.Contexts.YapilacaklarContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            List<Yapilacak> yapılacaklar = new List<Yapilacak>()
            {
                new Yapilacak()
                {
                    Gorev = "Görev 1",
                    CreateDate = DateTime.Now,
                    CreatedBy = "system",
                    IsDeleted = false,
                    YapildiMi = false,
                    Kullanici = new Kullanici()
                    {
                        KullaniciAdi = "erdal",
                        Sifre ="12345",
                        CreateDate = DateTime.Now,
                        CreatedBy = "system",
                        Adi = "Erdal",
                        Soyadi = "Sarışen",
                        IsDeleted = false
                    }
                },
                new Yapilacak()
                {
                    Gorev = "Görev 2",
                    CreateDate = DateTime.Now,
                    CreatedBy = "system",
                    IsDeleted = false,
                    YapildiMi = false,
                    Kullanici = new Kullanici()
                    {
                        Id = 1,
                        KullaniciAdi = "aslan",
                        Sifre ="12345",
                        CreateDate = DateTime.Now,
                        CreatedBy = "system",
                        Adi = "Kaplan",
                        Soyadi = "Erdal",
                        IsDeleted = false
                    }
                },
                new Yapilacak()
                {
                    Gorev = "Görev 3",
                    CreateDate = DateTime.Now,
                    CreatedBy = "system",
                    IsDeleted = false,
                    YapildiMi = false,
                    KullaniciId = 1
                }
            };
            //context üzerinden veritabanıuna kayıtları silme
            var kullaniciEntities = context.Kullanicilar.ToList();
            context.Kullanicilar.RemoveRange(kullaniciEntities);
            var yapilacakEntities = context.Yapilacaklar.ToList();
            context.Yapilacaklar.RemoveRange(yapilacakEntities);
            context.SaveChanges();

            //context üzerinden veritabanıuna kayıtları ekleme
            context.Yapilacaklar.AddRange(yapılacaklar);
        }
    }
}
