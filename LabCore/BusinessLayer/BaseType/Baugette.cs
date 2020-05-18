using System;
using System.Collections.Generic;
using System.Text;

namespace LabCore.BusinessLayer.BaseType
{
    public class Baugette
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<MaterialCount> Materials { get; set; }

        public Baugette(int Id, string name, List<MaterialCount> materials)
        {
            this.Id = Id;
            this.Name = name;
            this.Materials = materials;
        }
    }
}
