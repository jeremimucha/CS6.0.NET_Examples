using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FileInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** FileInfo App *****\n");

            // Creating a file
            FileInfo f = new FileInfo(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory\Test.dat");
            using (FileStream fs = f.Create())
            {
                // Use the FileStream object
            }


            // FileInfo.Open() method provides lots of controll over opening/creating a file
            FileInfo f2 = new FileInfo(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory\Test2.dat");
            using (FileStream fs = f2.Open(FileMode.OpenOrCreate,
                FileAccess.ReadWrite, FileShare.None))
            {
                // Use the FileStream obj
            }


            // Create Test3.dat and Test4.dat files
            foreach(string file in new string[] { "Test3.dat", "Test4.dat" })
            {
                FileInfo finfo = new FileInfo(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory\" + file);
                if (!finfo.Exists)
                    finfo.Create().Close();

            }


            // Get a FileStream object with read-only permissions
            FileInfo f3 = new FileInfo(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory\Test3.dat");
            using (FileStream readOnlyStream = f3.OpenRead())
            {
                // use the FileStream object...
            }


            // Get a FileStream object with write-only permissions
            FileInfo f4 = new FileInfo(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory\Test4.dat");
            using (FileStream writeOnlyStream = f4.OpenWrite())
            {
                // Use the FileStream object...
            }


            // Get a StreamReader object
            FileInfo f5 = new FileInfo(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory\TestStreamReader.txt");
            using (StreamReader sreader = f5.OpenText())
            {
                // Use the StreamReader object...
            }


            // Get a StreamWriter object for a new text file
            FileInfo f6 = new FileInfo(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory\Test6.txt");
            using (StreamWriter swriter = f6.CreateText())
            {
                // Use the StreamWriter object...
            }


            // Get a StreamWriter object opened for appending to a text file
            FileInfo f7 = new FileInfo(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory\Test7.txt");
            using (StreamWriter swriterAppend = f7.AppendText())
            {
                // Use the StreamWriter object
            }

            //
            // File type can be used instead of FileInfo - it exposes some of the same functionality
            // as static methods.
            //

            using (FileStream fs = File.Create(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory\File_Test.txt"))
            { }

            using (FileStream fs = File.Open(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory\File_Test2.txt",
                FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            { }

            using (FileStream readOnly = File.OpenRead(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory\Test3.txt"))
            { }

            using (FileStream writeOnly = File.OpenWrite(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory\Test4.txt"))
            { }

            using (StreamReader sreader = File.OpenText(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory\Test6.txt"))
            { }

            using (StreamWriter swriter = File.CreateText(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory\File_TestText.txt"))
            { }

            using (StreamWriter swrite_append = File.AppendText(@"G:\C#\C#60_NET46\Ch20_FileIO_ObjectSerialization\test_directory\File_TestAppend.txt"))
            { }

        }
    }
}
