using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26.Data.Entity
{
    public class MimeTypeStatic
    {
        public string NameMemeType { get; set; }



        public int Qantity { get; set; }

        public double MediumQantity { get; set; }   //Процентное соотношение

        public long FullSize { get; set; }

        public long MediumSize { get; set; }

        public double MediumSizeMB { get; set; }

        public List<Entity> ListFiles { get; set; }

       public  MimeTypeStatic() 
        {
            Qantity = 1; ListFiles = new List<Entity>();
        }

    }
}
