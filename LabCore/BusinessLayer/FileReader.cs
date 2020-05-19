using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LabCore.BusinessLayer.BaseType;

namespace LabCore.BusinessLayer
{
    static class FileReader
    {
        static public List<Baugette> ReadBaugette(string path, List<MaterialCount> matlist)
        {
            List<string> matnames = new List<string>();
            foreach (var m in matlist)
            {
                matnames.Add(m.Name);
            }

            StreamReader sr = new StreamReader(path);
            List<Baugette> bauglist = new List<Baugette>();

            string name, line, line2;
            int Id = 0;
            int index, index2;
            int count, count2;
            while ((name = sr.ReadLine()) != null)
            {
                line = sr.ReadLine();
                line2 = sr.ReadLine();
                index = matnames.IndexOf(line);
                index2 = matnames.IndexOf(line2);

                count = Convert.ToInt32(sr.ReadLine());
                count2 = Convert.ToInt32(sr.ReadLine());

                matlist[index].Count = count;
                matlist[index2].Count = count2;
                bauglist.Add(new Baugette(Id, name, new List<MaterialCount> { matlist[index], matlist[index2] }));
                Id++;
            }

            sr.Close();
            return bauglist;
        }

        static public List<MaterialCount> ReadMaterialCount(string path)
        {
            StreamReader sr = new StreamReader(path);
            List<MaterialCount> matlist = new List<MaterialCount>();

            string line;
            int Id = 0;
            int count;
            while ((line = sr.ReadLine()) != null)
            {
                count = Convert.ToInt32(sr.ReadLine());
                matlist.Add(new MaterialCount(Id, line, count));
                Id++;
            }

            sr.Close();
            return matlist;
        }
    }
}
