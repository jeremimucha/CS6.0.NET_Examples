using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
// Must reference System.Runtime.Serialization.Formatters.Soap.dll
using System.Runtime.Serialization.Formatters.Soap;
// Must reference System.Xml.dll
using System.Xml.Serialization;


namespace SimpleSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Object Serialization *****\n");
            JamesBondCar jbc = new JamesBondCar() { canFly = true, canSubmerge = false };
            jbc.theRadio.stationPresets = new double[] { 89.3, 105.1, 97.1 };
            jbc.theRadio.hasTweeters = true;

            // Save the file to a specific file ina binary format
            SaveAsBinaryFormat(jbc, "car_data.dat");
            LoadFromBinaryFile("car_data.dat");
            SaveAsSoapFormat(jbc, "car_data_soap.xml");
            LoadFromSoapFile("car_data_soap.xml");
            SaveAsXmlFormat(jbc, "car_data_xml.xml");
            LoadFromXmlFile("car_data_xml.xml");

            SaveListOfCarsAsXml();
            SaveListOfCarsAsBinary();
            Console.ReadLine();
        }

        static void SaveAsBinaryFormat(object obj_graph, string file_name)
        {
            BinaryFormatter binformat = new BinaryFormatter();

            using (Stream fstream = new FileStream(file_name,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binformat.Serialize(fstream, obj_graph);
            }

            Console.WriteLine("=> Saved car in binary format!");
        }

        static void SaveAsSoapFormat(object obj_graph, string file_name)
        {
            SoapFormatter soapFormat = new SoapFormatter();
            using (Stream fstream = new FileStream(file_name,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fstream, obj_graph);
            }

            Console.WriteLine("=> Saved car in SOAP format!");
        }

        // XmlSerializer demands that all serialized types have a default constructor
        // Only fields exposed publicly (also via properties) are serialized!
        // class fields can be decorated to control how they're serialized
        // e.g. as attributes or subelements
        static void SaveAsXmlFormat(object obj_graph, string file_name)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(JamesBondCar));
            using (Stream fstream = new FileStream(file_name,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fstream, obj_graph);
            }

            Console.WriteLine("=> Saved car in XML format!");
        }

        static void LoadFromBinaryFile(string fname)
        {
            BinaryFormatter bformat = new BinaryFormatter();

            // Read the JamesBondCar from the binary file
            using (Stream fstream = File.OpenRead(fname))
            {
                JamesBondCar carfromdisk = (JamesBondCar)bformat.Deserialize(fstream);
                Console.WriteLine("Can this car fly?: {0}", carfromdisk.canFly);
            }
        }

        static void LoadFromSoapFile(string filename)
        {
            SoapFormatter soapFormat = new SoapFormatter();
            using (Stream fstream = File.OpenRead(filename))
            {
                JamesBondCar carfromdisk = (JamesBondCar)soapFormat.Deserialize(fstream);
                Console.WriteLine("Can this car fly?: {0}", carfromdisk.canFly);
            }
        }

        static void LoadFromXmlFile(string filename)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(JamesBondCar));
            using (Stream fstream = File.OpenRead(filename))
            {
                JamesBondCar carfromdisk = (JamesBondCar)xmlFormat.Deserialize(fstream);
                Console.WriteLine("Can this car fly?: {0}", carfromdisk.canFly);
            }
        }


        static void SaveListOfCarsAsXml()
        {
            List<JamesBondCar> cars = new List<JamesBondCar>()
            {
                new JamesBondCar(true,true),
                new JamesBondCar(true,false),
                new JamesBondCar(false,true),
                new JamesBondCar(false,false)
            };

            using (Stream fstream = new FileStream("CarCollection.xml",
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<JamesBondCar>));
                xmlFormat.Serialize(fstream, cars);
            }
            Console.WriteLine("=> Saved a list of cars!");


            using (Stream fstream = File.OpenRead("CarCollection.xml"))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<JamesBondCar>));
                List<JamesBondCar> deserialized = (List<JamesBondCar>)xmlFormat.Deserialize(fstream);
                Console.WriteLine("\n=>Deserialized list of cars:");
                foreach(JamesBondCar c in deserialized)
                {
                    Console.WriteLine("JBC: canFly: {0}, canSubmerge: {1}", c.canFly, c.canSubmerge);
                }
            }
        }

        static void SaveListOfCarsAsBinary()
        {
            // Save ArrayList object as binary
            List<JamesBondCar> cars = new List<JamesBondCar>()
            {
                new JamesBondCar(true,true),
                new JamesBondCar(true,false),
                new JamesBondCar(false,true),
                new JamesBondCar(false,false)
            };

            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fstream = new FileStream("Cars.dat",
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fstream, cars);
            }

            Console.WriteLine("=> Saved a list of cars as binary!");


            using (Stream fstream = File.OpenRead("Cars.dat"))
            {
                List<JamesBondCar> deserialized = (List<JamesBondCar>)binFormat.Deserialize(fstream);
                Console.WriteLine("\n=> Deserialized list of cars:");
                foreach(JamesBondCar car in deserialized)
                {
                    Console.WriteLine("JBC: canFly: {0}, canSubmerge: {1}", car.canFly, car.canSubmerge);
                }
            }
        }
    }

}
