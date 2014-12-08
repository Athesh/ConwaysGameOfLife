using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    public class GameEngine {
        UserInterface UI_;
        Generation currentGen;
        Rules evolution = new Rules();
        const int timeToSleep = 1000;
        bool iftrue = true;

        public GameEngine (Generation g, UserInterface UI) {
            currentGen = g;             //konstruktor GameEnginu s parametry pro předání
            UI_ = UI;                   //stavu pole (a.k.a. generace) + uživatelského rozhraní
        }

        public Generation CurrentGen {  //property pro získání současné generace
            get {
                return currentGen;
            }
        }

        private void Animate() {    //metoda pro automatický výpočet dalších generací
            while (iftrue) {        //s timeToSleep, což je čas mezi zobrazením
                Step();             //další vypočítané generace
                System.Threading.Thread.Sleep(timeToSleep);
            }
        }

        public void Step() {        //metoda pro vypočítáni jedné generace
            currentGen = evolution.NextGen(currentGen);
            UI_.Update();
        }

        public void Start() {
            iftrue = true;
            var thread = new Thread(Animate);   //vytvoření sekundárního vlákna,
            thread.IsBackground = true;         //které umožňuje aby mezitím co pracuje, evenloop
            thread.Start();                     //primárního vlákna příjímal příkazy od uživatele 
        }

        public void Stop() {    //zabránění výpočtu dalších generací při spuštění metody Start()
            iftrue = false;
        }

    }
}
