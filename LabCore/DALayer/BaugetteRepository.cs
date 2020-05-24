using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LabCore.DALayer.Entities;
using LabCore.DALayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LabCore.DALayer
{
    class BaugetteRepository : Repository<BaugetteEntity>, IBaugetteRepository
    {
        public BaugetteRepository(AppDBContext dbContext) : base(dbContext) { }

        public IEnumerable<BaugetteEntity> GetAll()
        {
            return dbContext.Baugettes.Include(b => b.Details).ToList();
        }
    }
}
