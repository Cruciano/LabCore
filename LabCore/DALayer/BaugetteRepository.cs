using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using LabCore.DALayer.Entities;
using LabCore.DALayer.Interfaces;

namespace LabCore.DALayer
{
    class BaugetteRepository : Repository<BaugetteEntity>, IBaugetteRepository
    {
        public BaugetteRepository(AppDBContext dbContext) : base(dbContext) { }

        public override IEnumerable<BaugetteEntity> GetAll()
        {
            return dbContext.Baugettes.Include(b => b.Details).ToList();
        }
    }
}
