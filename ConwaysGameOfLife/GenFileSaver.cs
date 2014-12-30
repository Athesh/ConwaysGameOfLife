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

        public void Save (Generation gen) {
            string exeFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            TextWriter tw = new StreamWriter(exeFolder + @"\..\..\Library\Testing.txt");
            Rules r = new Rules();

            int width = gen.Width;
            int height = gen.Height;

            tw.WriteLine(width);
            tw.WriteLine(height);

            char[,] arr = new char[width, height];

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    Coordinate coor = new Coordinate(x, y);
                    bool cell = r.IsInGridAndAlive(coor, gen);
                    if (cell == false) {
                        arr[x, y] = '_';
                    }
                    else if (cell == true) {
                        arr[x, y] = 'X';
                    }
                    tw.Write(arr[x, y]);
                }
                tw.WriteLine();
            }

            tw.Close();
        }
    }
}
