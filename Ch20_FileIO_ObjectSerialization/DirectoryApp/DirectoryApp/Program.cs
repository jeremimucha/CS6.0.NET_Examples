using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace DirectoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowWindowsDirectoryInfo();
            DisplayImageFile();
            ModifyAppDirectory();
            FunWithDirectoryType();
            Console.ReadLine();
        }

        static void ShowWindowsDirectoryInfo()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("***** Directory Info *****");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("**************************\n");
        }

        static void DisplayImageFile()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");
            // Get all files with a *.jpg extension
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            Console.WriteLine("\n***** File Info *****");
            Console.WriteLine("Found {0} *.jpg files\n", imageFiles.Length);

            foreach(FileInfo f in imageFiles)
            {
                Console.WriteLine("*************************");
                Console.WriteLine("File name: {0}", f.Name);
                Console.WriteLine("File size: {0}", f.Length);
                Console.WriteLine("Creation: {0}", f.CreationTime);
                Console.WriteLine("Attributes: {0}", f.Attributes);
                Console.WriteLine("*************************");
            }
        }

        static void ModifyAppDirectory()
        {
            Console.WriteLine("\n***** Create Subdirectory *****");
            DirectoryInfo dir = new DirectoryInfo(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory");

            // Create \MyFolder 
            dir.CreateSubdirectory("MyFolder");
            // Create \MyFolder2\Data
            DirectoryInfo myFolder = dir.CreateSubdirectory(@"MyFolder2\Data");

            Console.WriteLine("New Folder is: {0}", myFolder);
        }

        static void FunWithDirectoryType()
        {
            Console.WriteLine("\n***** Directory Type *****");
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here are your dirves:");
            foreach (string s in drives)
                Console.WriteLine("--> {0} ", s);

            // Delete what was created
            DirectoryInfo dir = new DirectoryInfo(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory");
            Console.WriteLine("Press enter to delete dirs:");
            Console.ReadLine();
            var subdirs = from subdir in dir.GetDirectories()
                          select subdir.FullName;
            foreach(string d in subdirs)
            {
                try
                {
                    Console.WriteLine("Deleting {0}", d);
                    Directory.Delete(d);
                }catch(IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
