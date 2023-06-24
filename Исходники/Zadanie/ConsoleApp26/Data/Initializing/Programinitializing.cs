using ConsoleApp26.Data.Entity;

using ConsoleApp26.Data.Intefaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp26.Data.Entity.Entity;

namespace ConsoleApp26.Data.Initializing
{
    internal class Programinitializing : IProgram
    {
        public List<MimeTypeStatic> FileSort(List<Entity.Entity> listfiles)
        {
            List<MimeTypeStatic> listmemetype = new List<MimeTypeStatic>();
            foreach (var item in listfiles)
            {
                if (listmemetype.FirstOrDefault(x => x.NameMemeType == item.MemeType) == null)
                {
                    MimeTypeStatic memeType = new MimeTypeStatic();
                    memeType.NameMemeType = item.MemeType;
                    memeType.FullSize = item.Size;
                    memeType.ListFiles.Add(item);
                    listmemetype.Add(memeType);
                }
                else
                {
                    listmemetype.FirstOrDefault(x => x.NameMemeType == item.MemeType).Qantity++;
                    listmemetype.FirstOrDefault(x => x.NameMemeType == item.MemeType).FullSize = item.Size;
                    listmemetype.FirstOrDefault(x => x.NameMemeType == item.MemeType).ListFiles.Add(item);
                }              
                
            }
            foreach (var item in listmemetype)
            {
                item.MediumQantity = Math.Round(((double)item.Qantity / listfiles.Count), 3);

                item.MediumQantity = item.MediumQantity * 100;
                
                item.MediumSize = item.FullSize / item.Qantity;               

            }
            foreach(var item in listmemetype)
            {
                item.MediumSizeMB = Math.Round(((double)item.FullSize / (1024*1024)),6);
            }
            
            return listmemetype;
        }

        public List<Entity.Entity> FilesSearch(string path)
        {
            List<Entity.Entity> entities = new List<Entity.Entity>();
            List<string> files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories).ToList();
            List<string> exceptionpathfiles = new List<string>
                    {
                $"{path}ConsoleApp26.deps.json",
                        $"{path}ConsoleApp26.dll",
                        $"{path}ConsoleApp26.exe",
                        $"{path}ConsoleApp26.pdb",
                        $"{path}ConsoleApp26.runtimeconfig.json",
                        $"{path}MimeMapping.dll",
                        $"{path}Zadanie.html"
                   };






            var toRemove = files.Intersect(exceptionpathfiles);
            files.RemoveAll(x => toRemove.Contains(x));

           foreach (var file in files)
            {
                FileInfo i = new FileInfo(file);
                Entity.Entity entity = new Entity.Entity();
                entity.Name = i.Name;
                entity.Size = i.Length;
                entity.SizeMb = Math.Round(((double)entity.Size / (1024 * 1024)), 6);
                entity.FullName = i.FullName;
                entity.MemeType = MimeMapping.MimeUtility.GetMimeMapping(i.Name);
                entities.Add(entity);
            }
           return entities;
        }

        public  List<Folder> FolderSearch(string path)
        {
            List<Folder> result = new List<Folder>();
            List<string> files = Directory.EnumerateDirectories(path, "*", SearchOption.AllDirectories).ToList();
            foreach (var item in files)
            {
                FileInfo eir = new FileInfo(item);
                Folder folder = new Folder();
                folder.Name = eir.Name;
                folder.FullName = eir.FullName;

                DirectoryInfo dir = new DirectoryInfo(item);
                List<string> list2 = Directory.EnumerateFiles(item, "*", SearchOption.TopDirectoryOnly).ToList();
                foreach (var item1 in list2)
                {
                    FileInfo vir = new FileInfo(item1);
                    ConsoleApp26.Data.Entity.Entity answer = new ConsoleApp26.Data.Entity.Entity();
                    answer.Size = vir.Length;
                    answer.MemeType = MimeMapping.MimeUtility.GetMimeMapping(vir.Name);
                    answer.FullName = vir.FullName;
                    answer.Name = vir.Name;
                    folder.Files.Add(answer);
                }
                List<string> listsize = Directory.GetFiles(item, "*.*", SearchOption.AllDirectories).ToList();
                foreach (var item1 in listsize)
                {
                    FileInfo size = new FileInfo(item1);
                    folder.Size += size.Length;

                }
                folder.MediumSizeMB = Math.Round(((double)folder.Size / (1024 * 1024)), 6);
                result.Add(folder);
            }




            return result;
        }


    }
}
