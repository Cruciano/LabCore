using System;
using System.Collections.Generic;
using System.Text;
using LabCore.BusinessLayer.BaseType;

namespace LabCore.BusinessLayer.Interfaces
{
    interface IWorkshopService
    {
        ICollection<string> GetBaugetteNames();
        ICollection<MaterialCount> GetNessMaterials(Dictionary<string, int> order);
    }
}
