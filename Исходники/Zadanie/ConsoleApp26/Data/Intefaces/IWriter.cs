using ConsoleApp26.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26.Data.Intefaces
{
    public interface IWriter
    {
        public void TableFolder(List<Folder> listfolder,string path);

        public void TableFiles (List<Entity.Entity> listfiles, List<MimeTypeStatic> memeTypeStatics, string path);

        public void TableMemeType(List<MimeTypeStatic> memeTypeStatics, string path);


    }
}
