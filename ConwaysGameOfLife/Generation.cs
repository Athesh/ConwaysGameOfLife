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

        public bool Equals(Generation g) {
            if (this.width_ != g.width_)
                return false;
            if (this.height_ != g.height_)
                return false;
            for (int row = 0; row < this.height_; row++) {
                for (int col = 0; col < this.width_; col++) {
                    if (this.gameGrid_[col, row] != g.gameGrid_[col, row]) {
                        return false;
                    }
                }
            }
            return true;
        }
        public Generation(bool[,] gameGrid) {
            width_ = gameGrid.GetLength(0);
            height_ = gameGrid.GetLength(1);
            gameGrid_ = gameGrid;
        }

        public bool Alive (Coordinate coor){
            return gameGrid_[coor.X, coor.Y];
        }

        public int Width {
            get { return width_; }
        }

        public int Height {
            get { return height_; }
        }
    }
}
