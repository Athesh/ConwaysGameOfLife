using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    public class GenFileLoader {

        string jmenoSouboru_;

        public GenFileLoader(string jmenoSouboru) {
            jmenoSouboru_ = jmenoSouboru;
        }

        private void ParseLine (bool[,] arr, int rowNumber, string row){
            for (int i = 0; i < row.Length; i++) {
                char cell = row.ElementAt(i);
                if (cell == '_') {
                    arr[i, rowNumber] = false;
                }
                else if (cell == 'X'){
                    arr[i, rowNumber] = true;
                }
            }
        }

        public Generation Load() {
            string[] lines = System.IO.File.ReadAllLines(@jmenoSouboru_);
            int width = Convert.ToInt32(lines[0]);
            int height = Convert.ToInt32(lines[1]);

            bool[,] arr = new bool[width, height];

            for (int i = 0; i < height; i++) {
                ParseLine(arr, i, lines[i + 2]);
            }
            return new Generation(arr);
        }
    }
}
