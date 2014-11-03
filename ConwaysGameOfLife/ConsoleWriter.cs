using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    class ConsoleWriter {
        public void Draw(Generation generation) {
            for (int row = 0; row < generation.Height; row++) {
                for (int col = 0; col < generation.Width; col++) {
                    Coordinate coor = new Coordinate(col, row);
                    bool alive = generation.Alive(coor);
                    if (alive)
                        Console.Write("X");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }

        }

    }
}
