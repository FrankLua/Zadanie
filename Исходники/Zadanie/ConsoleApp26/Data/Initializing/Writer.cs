using ConsoleApp26.Data.Entity;
using ConsoleApp26.Data.Intefaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26.Data.Initializing
{
    public class Writer : IWriter
    {
        public void TableFiles(List<Entity.Entity> listfiles, List<MimeTypeStatic> memeTypeStatics, string path)
        {
            long bytesize = 0;
            double megabyte = 0;
            string pathfile = $"{path}Zadanie.html";
            FileStream fileStream = File.Open(pathfile, FileMode.Append);
            using (StreamWriter output = new StreamWriter(fileStream))
            {
                output.WriteLine("<table border='1'>");
                output.WriteLine("<h2> Таблица Файлов </h2>");


                output.WriteLine("<tr>");

                output.WriteLine($"<th>Имя файла</th>");

                output.WriteLine($"<th>Размер байтах</th>");

                output.WriteLine($"<th>Размер в мегабайтах</th>");

                output.WriteLine($"<th>MimeType</th>");

                output.WriteLine($"<th>Количество файлов</th>");

                output.WriteLine("</tr>");


                bytesize = 0;
                megabyte = 0;
                foreach (Entity.Entity item in listfiles)
                {
                    bytesize += item.Size;
                    megabyte += item.SizeMb;
                    output.WriteLine("<tr>");
                    output.WriteLine($"<td>{item.Name}</td>");
                    output.WriteLine($"<td>{item.Size}</td>");
                    output.WriteLine($"<td>{item.SizeMb}</td>");
                    output.WriteLine($"<td>{item.MemeType}</td>");
                    output.WriteLine($"<td>1</td>");
                    output.WriteLine("</tr>");
                }
                output.WriteLine("<tr>");

                output.WriteLine($"<th>Общие</th>");

                output.WriteLine($"<th>{bytesize}</th>");

                output.WriteLine($"<th>{megabyte}</th>");

                output.WriteLine($"<th>{memeTypeStatics.Count} Количество memeType</th>");

                output.WriteLine($"<th>{listfiles.Count} Количество файлов </th>");


                output.WriteLine("</tr>");
                output.Close();
            }

        }

        public void TableFolder(List<Folder> listfolder, string path)
        {
            long bytesize = 0;
            double megabyte = 0;
            List<string> listMainDerrictories = Directory.EnumerateDirectories(path, "*", SearchOption.TopDirectoryOnly).ToList();
            foreach (var item in listMainDerrictories)
            {
                
                FileInfo mainfolder = new FileInfo(item);
                List<string> listmainfiles = Directory.GetFiles(mainfolder.FullName, "*", SearchOption.AllDirectories).ToList();
                foreach(var item1 in listmainfiles)
                {
                    FileInfo mainfile = new FileInfo(item1);
                    bytesize += mainfile.Length;
                    megabyte += Math.Round(((double)mainfile.Length / (1024 * 1024)), 6);
                }
          
            }
            string pathfile = $"{path}Zadanie.html";
            FileStream fileStream = File.Open(pathfile, FileMode.Append);
            using (StreamWriter output = new StreamWriter(fileStream))
            {
                // Таблица для папок.
                output.WriteLine("<h2> Таблица Папок </h2>");

                output.WriteLine("<table border='1'>");


                output.WriteLine("<tr>");

                output.WriteLine($"<th>Имя Дериктории</th>");

                output.WriteLine($"<th>Размер в байтах</th>");

                output.WriteLine($"<th>Размер в мегабайтах</th>");

                output.WriteLine($"<th>Количество папок</th>");


                output.WriteLine("</tr>");



                foreach (Folder item in listfolder)
                {
                    output.WriteLine("<tr>");
                    output.WriteLine($"<td>{item.Name}</td>");
                    output.WriteLine($"<td>{item.Size}</td>");
                    output.WriteLine($"<td>{item.MediumSizeMB}</td>");
                    output.WriteLine($"<td>1</td>");
                    output.WriteLine("</tr>");
                }


                output.WriteLine("<tr>");

                output.WriteLine($"<th>Общие</th>");

                output.WriteLine($"<th>{bytesize}</th>");

                output.WriteLine($"<th>{megabyte}</th>");

                output.WriteLine($"<th>{listfolder.Count}</th>");


                output.WriteLine("</tr>");

                output.Close();
            }

            }

        public void TableMemeType(List<MimeTypeStatic> memeTypeStatics, string path)
        {
   
            string pathfile = $"{path}Zadanie.html";
            FileStream fileStream = File.Open(pathfile, FileMode.Append);
            using (StreamWriter output = new StreamWriter(fileStream))
            {
                output.WriteLine("<table border='1'>");

                output.WriteLine("<h2> Таблица MimeType </h2>");

                output.WriteLine("<tr>");

                output.WriteLine($"<th>Имя MimeType</th>");

                output.WriteLine($"<th>Количество</th>");

                output.WriteLine($"<th>Частота (Средние количество по отношению ко всем файлам в %)</th>");

                output.WriteLine($"<th>Средний размер в байтах</th>");

                output.WriteLine($"<th>Средний размер в мегабайтах</th>");


                output.WriteLine("</tr>");
                foreach (MimeTypeStatic item in memeTypeStatics)
                {
     
                    output.WriteLine("<tr>");
                    output.WriteLine($"<td>{item.NameMemeType}</td>");
                    output.WriteLine($"<td>{item.Qantity}</td>");
                    output.WriteLine($"<td>{item.MediumQantity}</td>");
                    output.WriteLine($"<td>{item.MediumSize}</td>");
                    output.WriteLine($"<td>{item.MediumSizeMB}</td>");
                    output.WriteLine("</tr>");
                }
                output.WriteLine("<tr>");

                output.WriteLine($"<th>Общее </th>");

                output.WriteLine($"<th>{memeTypeStatics.Count}</th>");

                output.WriteLine($"<th>100</th>");

                output.WriteLine($"<th>----</th>");

                output.WriteLine($"<th>----</th>");


                output.WriteLine("</tr>");

                // end table
                output.WriteLine("</table>");

                // close file
                output.Close();
            }


        }
    }
}
