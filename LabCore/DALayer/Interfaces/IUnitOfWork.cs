using System;
using System.Collections.Generic;
using System.Text;
using LabCore.DALayer.Entities;

namespace LabCore.DALayer.Interfaces
{
    interface IUnitOfWork
    {
        IRepository<MaterialCountEntity> MatCountRepository { get; }
        IRepository<BaugetteEntity> BaugetteRepository { get; }

        void Save();
    }
}
