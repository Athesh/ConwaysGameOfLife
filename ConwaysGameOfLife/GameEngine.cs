using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    public class GameEngine {   ///Jádro hry, které interaguje mezi logikou a uživatelským rozhraním
        UserInterface UI_;
        Generation currentGen;
        Rules evolution = new Rules();
        int timeToSleep;
        bool started = false;
        long genNumber = 0;

        public GameEngine (Generation g, UserInterface UI) {
            currentGen = g;             //konstruktor GameEnginu s parametry pro předání
            UI_ = UI;                   //stavu pole (a.k.a. generace) + uživatelského rozhraní
        }

        public int Speed { //property pro nastavení rychlosti
            set {
                this.timeToSleep = value;
            }
        }

        public long Number {
            get {
                return genNumber;
            }
        }

        public Generation CurrentGen {  //property pro získání současné generace
            get {
                return currentGen;
            }
            set {
                this.currentGen = value;
                genNumber = 0;
            }
        }

        public void Refresh() {
            UI_.Update();
        }

        private void Animate() {    //metoda pro automatický výpočet dalších generací
            while (started) {        //s timeToSleep, což je čas mezi zobrazením
                DoStep();             //další vypočítané generace
                System.Threading.Thread.Sleep(timeToSleep);
            }
        }

        private void DoStep() {
            currentGen = evolution.NextGen(currentGen);
            genNumber++;
            UI_.Update();
        }
        public void Step() {        //metoda pro vypočítáni jedné generace
            if (!started) {
                DoStep();
            }
        }

        public void Start() {
            if (!started) {
                started = true;
                var thread = new Thread(Animate);   //vytvoření sekundárního vlákna,
                thread.IsBackground = true;         //které umožňuje aby mezitím co pracuje, evenloop
                thread.Start();                     //primárního vlákna příjímal příkazy od uživatele
            }
        }

        public void Stop() {    //zabránění výpočtu dalších generací při spuštění metody Start()
            started = false;
        }

        public void InvertAt(Coordinate coor) { //Inverze buňky na pozici X, Y
            currentGen.Invert(coor);
            UI_.Update();
        }

    }
}
