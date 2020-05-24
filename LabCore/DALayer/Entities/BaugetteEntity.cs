using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LabCore.DALayer.Entities
{
    public class BaugetteEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DetailEntity> Details { get; set; }
    }
}
