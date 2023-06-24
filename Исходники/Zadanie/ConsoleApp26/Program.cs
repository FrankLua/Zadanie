using System.IO;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Web;
using ConsoleApp26.Data.Entity;
using ConsoleApp26.Data.Initializing;
using ConsoleApp26.Data.Intefaces;

namespace ConsoleApp26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProgram program = new Programinitializing();
            IWriter writer = new Writer();

            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            List<Folder> folders = new List<Folder>();
            List<Entity> files = new List<Entity>();            
            List<MimeTypeStatic> filesStatic = new List<MimeTypeStatic>();
            string pathfile = $"{appDirectory}Zadanie.html";
            FileStream fs = File.Create(pathfile);
            fs.Close();

            files = program.FilesSearch(appDirectory);
            folders = program.FolderSearch(appDirectory);
            filesStatic = program.FileSort(files);
            writer.TableFolder(folders, appDirectory);
            writer.TableFiles(files, filesStatic, appDirectory);
            writer.TableMemeType(filesStatic, appDirectory);




        }
        
    }
}