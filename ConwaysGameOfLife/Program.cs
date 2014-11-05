using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    class Program {
        static void Main(string[] args) {
            bool[,] arr = new bool[,] {{false, true, true},{true, true, false},{false, true, true}};
            Generation g = new Generation(arr);
            ConsoleWriter cc = new ConsoleWriter();
            cc.Draw(g);

            Console.ReadLine();
        }
    }
}
