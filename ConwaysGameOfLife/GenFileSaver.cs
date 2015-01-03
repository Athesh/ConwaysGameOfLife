using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConwaysGameOfLife {
    public class GenFileSaver {

        public GenFileSaver() { }

        public char[,] SerializeGeneration(Generation gen) {
            char[,] arr = new char[gen.Width, gen.Height];
            Rules r = new Rules();
            for (int y = 0; y < gen.Height; y++) {
                for (int x = 0; x < gen.Width; x++) {
                    Coordinate coor = new Coordinate(x, y);
                    bool cell = r.IsInGridAndAlive(coor, gen);
                    if (cell == false) {
                        arr[x, y] = '_';
                    }
                    else if (cell == true) {
                        arr[x, y] = 'X';
                    }
                }
            }
            return arr;
        }

        public void WriteArrayToFile(char[,] arr, string fileName, Generation gen){
            string exeFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            TextWriter tw = new StreamWriter(exeFolder + @"\..\..\Library\" + fileName);
            tw.WriteLine(gen.Width);
            tw.WriteLine(gen.Height);
            for (int y = 0; y < gen.Height; y++) {
                for (int x = 0; x < gen.Width; x++) {
                    tw.Write(arr[x, y]);
                }
                tw.WriteLine();
            }
            tw.Close();
        }

        public void Save (Generation gen, string fileName) {
            WriteArrayToFile(SerializeGeneration(gen), fileName, gen);
        }
    }
}
