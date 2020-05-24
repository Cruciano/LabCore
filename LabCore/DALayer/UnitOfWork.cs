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

        public IMaterialRepository MatCountRepository { get; }
        public IBaugetteRepository BaugetteRepository { get; }

        public UnitOfWork()
        {
        }

        public UnitOfWork(AppDBContext dbContext)
        {
            this.dbContext = dbContext;
            MatCountRepository = new MaterialRepository(dbContext);
            BaugetteRepository = new BaugetteRepository(dbContext);
        }


        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
