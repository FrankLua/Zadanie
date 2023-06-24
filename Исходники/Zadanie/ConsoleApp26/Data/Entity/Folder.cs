using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26.Data.Entity
{
    public class Folder
    {
        public string Name { get; set; }

        public string FullName { get; set; }

        public long Size { get; set; }
        
        public double MediumSizeMB { get; set; }
        

        public List<Entity> Files { get; set; }
        public Folder()
        {
            Files = new List<Entity>();
            
        }


    }
}
