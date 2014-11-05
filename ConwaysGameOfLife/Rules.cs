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

        private int CountNeighborsAlive(Coordinate coor, Generation generation) {
            return 0; //TODO Implement.
        }

    }
}
