using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    public class Generation {
        bool[,] gameGrid_;
        int width_;
        int height_;

        public bool Equals(Generation g) { //metoda pro porovnání podobnosti dvou polí
            if (this.width_ != g.width_)    //šířka
                return false;
            if (this.height_ != g.height_)  //výška
                return false;
            for (int row = 0; row < this.height_; row++) {  //cyklus pro porovnání jednotlivých prvků
                for (int col = 0; col < this.width_; col++) {
                    if (this.gameGrid_[col, row] != g.gameGrid_[col, row]) {
                        return false;
                    }
                }
            }
            return true;
        }
        public Generation(bool[,] gameGrid) {   //konstruktor pro Generaci
            width_ = gameGrid.GetLength(0);
            height_ = gameGrid.GetLength(1);
            gameGrid_ = gameGrid;
        }

        public bool Alive (Coordinate coor){    //metoda pro zjištění stavu buňky
            return gameGrid_[coor.X, coor.Y];
        }

        public int Width {  //property pro šířku
            get { return width_; }
        }

        public int Height { //property pro výšku
            get { return height_; }
        }

        public void Invert(Coordinate coor) {
            gameGrid_[coor.X, coor.Y] = !gameGrid_[coor.X, coor.Y];
        }
    }
}
