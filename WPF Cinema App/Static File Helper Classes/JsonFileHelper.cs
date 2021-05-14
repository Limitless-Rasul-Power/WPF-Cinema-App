using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Cinema_App.Models;

namespace WPF_Cinema_App.Static_File_Helper_Classes
{
    public static class JsonFileHelper
    {
        public static void JsonSerialization<T>(ObservableCollection<T> datas, string fileName)
        {
            if ((!string.IsNullOrWhiteSpace(fileName)) && datas != null)
            {
                string directoryName = fileName.Substring(0, fileName.LastIndexOf('/'));

                if (Directory.Exists(directoryName) == false)
                {
                    Directory.CreateDirectory(directoryName);
                }

                var serializer = new JsonSerializer();

                using (var sw = new StreamWriter($"{fileName}.json"))
                {
                    using (var jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Formatting.Indented;
                        serializer.Serialize(jw, datas);
                    }
                }
            }

        }

        public static ObservableCollection<T> JsonDeserialization<T>(string fileName)
        {
            if (File.Exists($"{fileName}.json") == false || string.IsNullOrWhiteSpace(fileName))
            {
                throw new InvalidOperationException("File name didn't exist or filename is null or white space.");
            }

            ObservableCollection<T> movies;

            var serializer = new JsonSerializer();

            using (var sr = new StreamReader($"{fileName}.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    movies = serializer.Deserialize<ObservableCollection<T>>(jr);
                }
            }

            return movies;

        }
    }
}
