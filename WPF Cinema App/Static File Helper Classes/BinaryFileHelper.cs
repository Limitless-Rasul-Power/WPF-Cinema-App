using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Cinema_App.Static_File_Helper_Classes
{
    public static class BinaryFileHelper
    {
        public static void BinarySerialization(decimal totalBudget, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName) == false)
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (var fs = new FileStream($"{fileName}.bin", FileMode.OpenOrCreate))
                {
                    bf.Serialize(fs, totalBudget);
                }
            }
        }

        public static decimal BinaryDeserialization(string fileName)
        {
            if (File.Exists($"{fileName}.bin") == false)
            {
                return 0;
            }

            BinaryFormatter bf = new BinaryFormatter();
            decimal totalBudget;

            using (var fs = new FileStream($"{fileName}.bin", FileMode.Open))
            {
                totalBudget = (decimal)bf.Deserialize(fs);
            }
            return totalBudget;
        }

    }
}
