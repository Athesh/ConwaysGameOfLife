﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    class Generation {
        bool[,] gameGrid_;
        int width_;
        int height_;

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
