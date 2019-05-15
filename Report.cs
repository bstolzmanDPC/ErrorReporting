using System;
using System.IO;
using System.Xml.Serialization;

namespace ErrorReporting
{

    static public class Report
    {

        /// <summary>
        /// Generates an error file on the users Desktop that includes information about the passed exception
        /// <para/>Includes an XML data dump from the given object
        /// <para/>Returns path to the generated file as a string, or the expeption message if it failed to generate the file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        static public string Generate<T>(Exception e, T obj)
        {
            try
            {
                string eFilename = (DateTime.Now.ToString("yyMMdd-hhmm-")) + Environment.UserName;
                string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{eFilename}.txt";
                using (StreamWriter eFile = new StreamWriter(path))
                {
                    eFile.WriteLine("Error Report: \r\n\r\n");
                    eFile.WriteLine(e);
                    eFile.WriteLine("--------------------------------------------------------------------------------------------");
                    eFile.WriteLine(e.Message);
                    eFile.WriteLine("--------------------------------------------------------------------------------------------");
                    eFile.WriteLine("Object Data: \r\n");
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    xs.Serialize(eFile, obj);
                }
                return path;
            }
            catch(Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        /// <summary>
        /// Generates an error file on the users Desktop that includes information about the passed exception
        /// <para/>Returns path to the generated file as a string, or the expeption message if it failed to generate the file.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        static public string Generate(Exception e)
        {
            try
            {
                string eFilename = (DateTime.Now.ToString("yyMMdd-hhmm-")) + Environment.UserName;
                string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{eFilename}.txt";
                using (StreamWriter eFile = new StreamWriter(path))
                {
                    eFile.WriteLine("Error Report: \r\n\r\n");
                    eFile.WriteLine(e);
                    eFile.WriteLine("--------------------------------------------------------------------------------------------");
                    eFile.WriteLine(e.Message);
                    eFile.WriteLine("--------------------------------------------------------------------------------------------");
                    eFile.WriteLine("Object Data: \r\n");
                }
                return path;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        /// <summary>
        /// Loads object data from XML file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns>object of type <T></returns>
        static public object LoadTestData<T>(string path)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                StreamReader file = new StreamReader(path);
                T o = (T)xs.Deserialize(file);
                return o;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Writes object data to an XML file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        static public void ExportObj<T>(T obj, string name)
        {
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
            FileStream file = File.Create($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{name}.xml");
            xs.Serialize(file, obj);
            file.Close();
        }
    }
}
