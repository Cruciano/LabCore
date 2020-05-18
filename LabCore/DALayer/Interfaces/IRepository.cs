using System;
using System.Collections.Generic;
using System.Text;

namespace LabCore.DALayer.Interfaces
{
    interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        TEntity Read(int id);
        void Update(TEntity item);
        void Delete(int id);
        IEnumerable<TEntity> GetAll();
    }
}
