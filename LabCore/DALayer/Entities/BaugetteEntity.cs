using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LabCore.DALayer.Entities
{
    public class BaugetteEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MaterialCountEntity> MaterialCounts { get; set; }
    }
}
