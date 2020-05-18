using System;
using System.Collections.Generic;
using System.Text;
using LabCore.DALayer.Entities;
using LabCore.BusinessLayer.BaseType;

namespace LabCore.BusinessLayer
{
    public static class Mapper
    {
        public static MaterialCount Map(this MaterialCountEntity entity)
        {
            return new MaterialCount(entity.Id, entity.Name, entity.Count);
        }

        public static MaterialCountEntity Map(this MaterialCount entity)
        {
            return new MaterialCountEntity() { Id = entity.Id, Name = entity.Name, Count = entity.Count };
        }

        public static Baugette Map(this BaugetteEntity entity)
        {
            List<MaterialCount> matList = new List<MaterialCount>();
            foreach (var n in entity.MaterialCounts)
            {
                matList.Add(n.Map());
            }

            return new Baugette(entity.Id, entity.Name, matList);
        }

        public static BaugetteEntity Map(this Baugette entity)
        {
            List<MaterialCountEntity> matEntityList = new List<MaterialCountEntity>();
            foreach (var n in entity.Materials)
            {
                matEntityList.Add(n.Map());
            }

            return new BaugetteEntity() { Id = entity.Id, Name = entity.Name, MaterialCounts = matEntityList };
        }
    }
}
