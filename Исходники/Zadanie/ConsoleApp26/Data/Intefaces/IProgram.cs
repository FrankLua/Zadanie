using ConsoleApp26.Data.Entity;
using ConsoleApp26.Data.Initializing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp26.Data.Intefaces
{
    public  interface IProgram
    {
        public  List<Folder> FolderSearch(string path);
        
        public List<ConsoleApp26.Data.Entity.MimeTypeStatic> FileSort(List<ConsoleApp26.Data.Entity.Entity> listfiles);

        public List<ConsoleApp26.Data.Entity.Entity>FilesSearch(string path);

        
    }
}
