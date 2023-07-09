using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ScreenTime
{
    
    public class DataLoader
    {
        public static string fileName = "saves.json";

        public static void Save(string data)
        {
            File.WriteAllText(fileName, data);
        }

        public static string? Load()
        {
            return (File.Exists(fileName)) ? 
                File.ReadAllText(fileName) : null;
        }

    }
}
