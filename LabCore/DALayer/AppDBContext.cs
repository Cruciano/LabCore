using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using LabCore.DALayer.Entities;


namespace LabCore.DALayer
{
    class AppDBContext : DbContext
    {
        public DbSet<MaterialCountEntity> MaterialCounts { get; set; }
        public DbSet<BaugetteEntity> Baugettes { get; set; }
        public DbSet<DetailEntity> details { get; set; }

        public AppDBContext() : base("labDataBase")
        {
            
        }

     /*   protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<MaterialCountEntity> matCountList = new List<MaterialCountEntity>()
            {
                new MaterialCountEntity {Id = 1, Name = "metal", Count = 30},
                new MaterialCountEntity {Id = 2, Name = "plastic", Count = 40},
                new MaterialCountEntity {Id = 3, Name = "wood", Count = 20},
                new MaterialCountEntity {Id = 4, Name = "paint", Count = 50},
            };



            List<MaterialCountEntity> listType1 = new List<MaterialCountEntity>()
            {
                new MaterialCountEntity {Id = 3, Name = "wood", Count = 3},
                new MaterialCountEntity {Id = 4, Name = "paint", Count = 2}
            };
            List<MaterialCountEntity> listType2 = new List<MaterialCountEntity>()
            {
                new MaterialCountEntity {Id = 1, Name = "metal", Count = 4},
                new MaterialCountEntity {Id = 2, Name = "plastic", Count = 5}
            };
            List<MaterialCountEntity> listType3 = new List<MaterialCountEntity>()
            {
                new MaterialCountEntity {Id = 3, Name = "metal", Count = 5},
                new MaterialCountEntity {Id = 4, Name = "plastic", Count = 2}
            };
            List<MaterialCountEntity> listType4 = new List<MaterialCountEntity>()
            {
                new MaterialCountEntity {Id = 3, Name = "plastic", Count = 3},
                new MaterialCountEntity {Id = 4, Name = "paint", Count = 2}
            };

            List<BaugetteEntity> baugetteEntities = new List<BaugetteEntity>()
            {
                new BaugetteEntity {Id = 1, Name = "type1", MaterialCounts = listType1},
                new BaugetteEntity {Id = 1, Name = "type1", MaterialCounts = listType2},
                new BaugetteEntity {Id = 1, Name = "type1", MaterialCounts = listType3},
                new BaugetteEntity {Id = 1, Name = "type1", MaterialCounts = listType4}
            };

            modelBuilder.Entity<MaterialCountEntity>().HasData(matCountList);
            modelBuilder.Entity<MaterialCountEntity>().HasData(baugetteEntities);
        }*/
    }
}
