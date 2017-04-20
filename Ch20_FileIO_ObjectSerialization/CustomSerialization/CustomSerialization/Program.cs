using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;


namespace CustomSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Custom Serialization *****\n");

            StringData data = new StringData(); // Implements ISerializable
            MoreData moredata = new MoreData(); // Uses annotations instead

            // Save to a local file in SOAP format
            SoapFormatter soapFormat = new SoapFormatter();
            using (Stream fstream = new FileStream("data.soap",
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fstream, data);
            }
            Console.WriteLine("Serialized StringData");
            using (Stream fstream = new FileStream("moredata.soap",
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fstream, moredata);
            }
            Console.WriteLine("Serialized MoreData");
            using (Stream fstream = File.OpenRead("data.soap"))
            {
                StringData deserialized = (StringData)soapFormat.Deserialize(fstream);
                Console.WriteLine("Deserialized StringData:");
                Console.WriteLine(deserialized.ToString());
            }
            using (Stream fstream = File.OpenRead("moredata.soap"))
            {
                MoreData dmd = (MoreData)soapFormat.Deserialize(fstream);
                Console.WriteLine("Deserialized MoreData:");
                Console.WriteLine(dmd);
            }

                Console.ReadLine();
        }
    }
}
