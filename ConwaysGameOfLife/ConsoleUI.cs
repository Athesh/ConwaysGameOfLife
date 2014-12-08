using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    public class ConsoleUI : UserInterface{
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
            }
        }

    }
}
