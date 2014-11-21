using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    class Program {
        static void Main(string[] args) {
            GenFileLoader loader = new GenFileLoader(@"E:\Škola\.NET C# Visual Studio Programming I4.B\ConwaysGameOfLife\ConwaysGameOfLife\Library\Stripes.txt");
            //bool[,] arr = new bool[,] {{false, true, false},{false, true, false},{false, true, false}};
            //Generation g = new Generation(arr);
            Generation g = loader.Load();
            Generation g1 = g;
            Rules r = new Rules();
            

            int zzz = 500;

            for (int i = 0; i < g.Height; i++)
			{
                Console.WriteLine("O");
			}
            System.Threading.Thread.Sleep(10000);

            ConsoleWriter cc = new ConsoleWriter();
            cc.Draw(g);
            System.Threading.Thread.Sleep(zzz);

            for (int i = 0; i < 50; i++) {
                g1 = r.NextGen(g1);
                cc.Draw(g1);
                System.Threading.Thread.Sleep(zzz);
            }


            Console.ReadLine();
        }
    }
}
