using System;
using System.Collections.Generic;
using System.Text;

namespace LabCore.BusinessLayer.BaseType
{
    public class MaterialCount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public MaterialCount(int Id, string name, int count)
        {
            this.Id = Id;
            this.Name = name;
            this.Count = count;
        }
    }
}
