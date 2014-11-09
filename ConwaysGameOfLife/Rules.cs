using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    public class Rules {
        public Generation NextGen(Generation generation) {
            return null; //TODO: Do the shit.
        }

        public bool IsInGridAndAlive(Coordinate coor, Generation generation) {
            if ((coor.X >= 0) && (coor.Y >= 0) && (coor.X < generation.Width) && (coor.Y < generation.Height)) {
                return generation.Alive(coor);
            }
            return false;
        }

        public int CountNeighborsAlive(Coordinate coor, Generation generation) {
            //cisla u promennych jsou podle numericke klavesnice (napr. 7 - vlevo, nahore)
            Coordinate c7 = new Coordinate(coor.X - 1, coor.Y - 1);
            Coordinate c8 = new Coordinate(coor.X, coor.Y - 1);
            Coordinate c9 = new Coordinate(coor.X + 1, coor.Y - 1);
            Coordinate c4 = new Coordinate(coor.X - 1, coor.Y);
            //Coordinate c5 vynechano - je to pocatek [x, y]
            Coordinate c6 = new Coordinate(coor.X + 1, coor.Y);
            Coordinate c1 = new Coordinate(coor.X - 1, coor.Y + 1);
            Coordinate c2 = new Coordinate(coor.X, coor.Y + 1);
            Coordinate c3 = new Coordinate(coor.X + 1, coor.Y + 1);

            int count = 0;
            if (IsInGridAndAlive(c7, generation)) //test pro [x-1, y-1]
                    count++;
            if (IsInGridAndAlive(c8, generation)) //test pro [x, y-1]
                    count++;
            if (IsInGridAndAlive(c9, generation)) //test pro [x+1, y-1]
                    count++;
            if (IsInGridAndAlive(c4, generation)) //test pro [x-1, y]
                    count++;
            if (IsInGridAndAlive(c6, generation)) //test pro [x+1, y]
                    count++;
            if (IsInGridAndAlive(c1, generation)) //test pro [x-1 y+1]
                    count++;
            if (IsInGridAndAlive(c2, generation)) //test pro [x, y+1]
                    count++;
            if (IsInGridAndAlive(c3, generation)) //test pro [x+1, y+1]
                    count++;
            return count;
        }

        public bool IsAliveInNextGeneration(bool isAliveNow, int countNeighborsAlive) {
            if (isAliveNow == false && countNeighborsAlive == 3)
                return true;
            if (isAliveNow == true && (countNeighborsAlive == 2 || countNeighborsAlive == 3))
                return true;
            return false;
        }


    }
}
