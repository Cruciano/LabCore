using LabCore.DALayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LabCore.DALayer.Interfaces;

namespace LabCore.DALayer
{
    class MaterialRepository : Repository<MaterialCountEntity>, IMaterialRepository
    {
        public MaterialRepository(AppDBContext dbContext) : base(dbContext) { }        
    }
}
