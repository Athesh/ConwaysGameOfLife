using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    public class ConsoleUI : UserInterface{ ///Konzolová část hry
        GameEngine engine_;

        public void Update() {  //metoda pro překreslení (v tomhle případě konzole)
            ConsoleWriter writer = new ConsoleWriter();
            writer.Draw(engine_.CurrentGen);
        }

        public void Run(GameEngine engine) {    //metoda pro přebrání enginu
            engine_ = engine;

            while (true) {  //eventloop hlavního vlákna
                string command = Console.ReadLine();
                if (command == "step") {
                    engine_.Step();
                }
                if (command == "start") {
                    engine_.Start();
                }
                if (command == "") {
                    engine_.Stop();
                }
                if (command == "end") {
                    break;
                }
                if (command == "convert") {
                    Console.Write("X: ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Y: ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    Coordinate coor = new Coordinate (x, y);
                    engine_.InvertAt(coor);
                }
                if (command == "load") {

                }
                if (command == "save") {
                    Console.Write("Path: ");
                    string path = Convert.ToString(Console.ReadLine());
                    GenFileSaver saver = new GenFileSaver();
                    saver.Save(engine_.CurrentGen, path);
                }

            }
        }

    }
}
