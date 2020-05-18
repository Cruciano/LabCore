using System;
using System.Collections.Generic;
using System.Text;
using LabCore.DALayer.Entities;
using LabCore.DALayer.Interfaces;

namespace LabCore.DALayer
{
    class UnitOfWork : IUnitOfWork
    {
        private AppDBContext dbContext;

        public IRepository<MaterialCountEntity> MatCountRepository { get; }
        public IRepository<BaugetteEntity> BaugetteRepository { get; }

        public UnitOfWork()
        {
        }

        public UnitOfWork(AppDBContext dbContext)
        {
            this.dbContext = dbContext;
            MatCountRepository = new Repository<MaterialCountEntity>(dbContext);
            BaugetteRepository = new Repository<BaugetteEntity>(dbContext);
        }


        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
