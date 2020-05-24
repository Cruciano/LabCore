using System;
using System.Collections.Generic;
using System.Text;
using LabCore.DALayer.Entities;

namespace LabCore.DALayer.Interfaces
{
    interface IUnitOfWork
    {
        IMaterialRepository MatCountRepository { get; }
        IBaugetteRepository BaugetteRepository { get; }

        void Save();
    }
}
