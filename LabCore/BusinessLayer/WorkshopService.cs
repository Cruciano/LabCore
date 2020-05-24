using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using LabCore.BusinessLayer.Interfaces;
using LabCore.BusinessLayer.BaseType;
using LabCore.DALayer.Interfaces;

using LabCore.DALayer.Entities;

namespace LabCore.BusinessLayer
{
    class WorkshopService : IWorkshopService
    {
        private IUnitOfWork unitOfWork;

        private List<MaterialCount> materialCounts;
        private List<Baugette> baugettes;
        private List<MaterialCount> nessMaterialCounts;

        public WorkshopService()
        {
        }

        public WorkshopService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            UpLoadData();
            //LoadData();
            //LoadDataFile();
            nessMaterialCounts = new List<MaterialCount>();
        }

        public ICollection<string> GetBaugetteNames()
        {
            ObservableCollection<string> outcolletion = new ObservableCollection<string>();
            foreach (var b in baugettes)
                outcolletion.Add(b.Name);

            return outcolletion;
        }

        public ICollection<MaterialCount> GetNessMaterials(Dictionary<string, int> order)
        {
            nessMaterialCounts.Clear();
            List<Baugette> nessBaugette = new List<Baugette>();
            List<int> nessBaugetteCount = new List<int>();
            int index;

            foreach (var o in order)
                if ((index = IndexFromNameBaug(o.Key)) >= 0)
                    for (int i = 0; i < baugettes[index].Materials.Count; i++)
                        AddNessMaterials(baugettes[index].Materials[i].Name, baugettes[index].Materials[i].Count * o.Value);

            SubMaterails();

            return nessMaterialCounts;
        }

        private void LoadDataFile()
        {
            materialCounts = FileReader.ReadMaterialCount("Files/Materials.txt");
            baugettes = FileReader.ReadBaugette("Files/Baugette.txt", materialCounts);
        }

        private void LoadData()
        {
            materialCounts = new List<MaterialCount>(unitOfWork.MatCountRepository.GetAll().Select(materialCount => materialCount.Map()));
            baugettes = new List<Baugette>(unitOfWork.BaugetteRepository.GetAll().Select(baugette => baugette.Map()));
        }

        private void UpLoadData()
        {
            List<MaterialCountEntity> matCountList = new List<MaterialCountEntity>()
            {
                new MaterialCountEntity {Id = 11, Name = "metal", Count = 30},
                new MaterialCountEntity {Id = 12, Name = "plastic", Count = 40},
                new MaterialCountEntity {Id = 13, Name = "wood", Count = 20},
                new MaterialCountEntity {Id = 14, Name = "paint", Count = 50},
            };



            List<DetailEntity> listType1 = new List<DetailEntity>()
            {
                new DetailEntity {Id = 1, Name = "wood", Count = 3},
                new DetailEntity {Id = 2, Name = "paint", Count = 2}
            };
            List<DetailEntity> listType2 = new List<DetailEntity>()
            {
                new DetailEntity {Id = 3, Name = "metal", Count = 4},
                new DetailEntity {Id = 4, Name = "plastic", Count = 5}
            };
            List<DetailEntity> listType3 = new List<DetailEntity>()
            {
                new DetailEntity {Id = 5, Name = "metal", Count = 5},
                new DetailEntity {Id = 6, Name = "plastic", Count = 2}
            };
            List<DetailEntity> listType4 = new List<DetailEntity>()
            {
                new DetailEntity {Id = 7, Name = "plastic", Count = 3},
                new DetailEntity {Id = 8, Name = "paint", Count = 2}
            };

            List<BaugetteEntity> baugetteEntities = new List<BaugetteEntity>()
            {
                new BaugetteEntity {Id = 21, Name = "type1", Details = listType1},
                new BaugetteEntity {Id = 22, Name = "type1", Details = listType2},
                new BaugetteEntity {Id = 23, Name = "type1", Details = listType3},
                new BaugetteEntity {Id = 24, Name = "type1", Details = listType4}
            };

            foreach (var item in matCountList)
            {
                unitOfWork.MatCountRepository.Create(item);
            }

          /*  foreach(var item in baugetteEntities)
            {
                unitOfWork.BaugetteRepository.Create(item);
            }*/
            unitOfWork.Save();
        }

        private int IndexFromNameBaug(string name)
        {
            int index = 0;
            foreach (var b in baugettes)
            {
                if (b.Name.Equals(name))
                    return index;
                index++;
            }
            return -1;
        }

        private int ValueFromNameMat(string name)
        {
            foreach (var m in materialCounts)
                if (m.Name.Equals(name))
                    return m.Count;
            return 0;
        }

        private void AddNessMaterials(string name, int count)
        {
            int i;
            if ((i = IndexFromNameMat(name)) >= 0)
                nessMaterialCounts[i].Count += count;
            else
                nessMaterialCounts.Add(new MaterialCount(1, name, count));
        }

        private int IndexFromNameMat(string name)
        {
            for (int i = 0; i < nessMaterialCounts.Count; i++)
                if (nessMaterialCounts[i].Name.Equals(name))
                    return i;
            return -1;
        }

        private void SubMaterails()
        {
            List<string> namesTemp = new List<string>();
            foreach (var n in nessMaterialCounts)
                namesTemp.Add(n.Name);

            for (int i = 0; i < namesTemp.Count; i++)
                if ((nessMaterialCounts[IndexFromNameMat(namesTemp[i])].Count -= ValueFromNameMat(namesTemp[i])) < 0)
                    nessMaterialCounts.Remove(nessMaterialCounts[IndexFromNameMat(namesTemp[i])]);
        }
    }
}
