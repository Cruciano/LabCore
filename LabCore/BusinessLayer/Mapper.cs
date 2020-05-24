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

        public static MaterialCountEntity Map(this MaterialCount blObject)
        {
            return new MaterialCountEntity() { Id = blObject.Id, Name = blObject.Name, Count = blObject.Count };
        }

        public static Baugette Map(this BaugetteEntity entity)
        {
            List<MaterialCount> matList = new List<MaterialCount>();
            foreach (var n in entity.Details)
            {
                matList.Add(n.Map());
            }

            return new Baugette(entity.Id, entity.Name, matList);
        }

        public static BaugetteEntity Map(this Baugette blObject)
        {
            List<DetailEntity> matEntityList = new List<DetailEntity>();
            foreach (var n in blObject.Materials)
            {
                matEntityList.Add((DetailEntity)n.Map());
            }

            return new BaugetteEntity() { Id = blObject.Id, Name = blObject.Name, Details = matEntityList };
        }
    }
}
