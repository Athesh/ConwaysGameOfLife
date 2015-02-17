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

        public string SerializeGeneration(Generation gen) {    //metoda pro zpracování generace do pole charů reprezentující bool hodnoty
            StringBuilder MahStringBuilder = new StringBuilder();
            MahStringBuilder.Append(gen.Width).Append("\n");
            MahStringBuilder.Append(gen.Height).Append("\n");

            Rules r = new Rules();
            for (int y = 0; y < gen.Height; y++)
            {
                for (int x = 0; x < gen.Width; x++)
                {
                    Coordinate coor = new Coordinate(x, y);
                    bool cell = r.IsInGridAndAlive(coor, gen);
                    if (cell == false)
                    {
                        MahStringBuilder.Append('_');
                    }
                    else if (cell == true)
                    {
                        MahStringBuilder.Append('X');
                    }
                }
                MahStringBuilder.Append("\n"); //newline
            }
            return MahStringBuilder.ToString();

            /* char[,] arr = new char[gen.Width, gen.Height];
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
                 //newline
            }
            return arr; */
        }

        public void WriteArrayToFile(string arr, string fileName, Generation gen){ //metoda pro zapsání pole charů do souboru
            string exeFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            TextWriter tw = new StreamWriter(exeFolder + @"\..\..\Library\" + fileName);
            tw.WriteLine(gen.Width);
            tw.WriteLine(gen.Height);
            tw.Write(arr);

            tw.Close();
        }

        public void Save (Generation gen, string fileName) {    //metoda pro ukládání (volá ostatní potřebné metody pro uložení)
            WriteArrayToFile(SerializeGeneration(gen), fileName, gen);
        }
    }
}
