using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    class Program {

        public static string GetLibraryDirectory() {
            string exeFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return exeFolder + @"\..\..\Library\";
            }

        static void Main(string[] args) {
            string file = System.IO.File.ReadAllText(GetLibraryDirectory() + @"Testing.txt");
            //bool[,] arr = new bool[,] {{false, true, false},{false, true, false},{false, true, false}};
            //Generation g = new Generation(arr);
            GenFileLoader loader = new GenFileLoader();
            Generation g = loader.Load(file);
            Generation g1 = g;

            //ConsoleUI ui = new ConsoleUI();
            GUI ui = new GUI();
            GameEngine ge = new GameEngine(g, ui);

            ui.Run(ge);

            /*Rules r = new Rules();
            
            int zzz = 100;

            for (int i = 0; i < g.Height; i++){
                Console.WriteLine("O");
			}
            System.Threading.Thread.Sleep(10000);

            ConsoleWriter cc = new ConsoleWriter();
            cc.Draw(g);
            System.Threading.Thread.Sleep(zzz);

            for (int i = 0; i < 200; i++) {
                g1 = r.NextGen(g1);
                cc.Draw(g1);
                System.Threading.Thread.Sleep(zzz);
            }

            
            Console.ReadLine();*/
        }
    }
}