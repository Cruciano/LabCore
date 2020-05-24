using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using LabCore.DALayer.Interfaces;
using System.Data.Entity.Migrations;

namespace LabCore.DALayer
{
    class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected AppDBContext dbContext;
        private DbSet<TEntity> entities;

        public Repository(AppDBContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            entities.Add(entity);
        }

        public void Delete(int id)
        {
            entities.Remove(dbContext.Set<TEntity>().Find(id));
        }

        public TEntity Read(int id)
        {
            return entities.Find(id);
        }

        public void Update(TEntity entity)
        {
            entities.AddOrUpdate(entity);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return entities;
        }
    }
}
