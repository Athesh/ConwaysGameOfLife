﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    public class Coordinate {
        int x_;
        int y_;

        //kostruktor pro Coordinate
        public Coordinate(int xx, int yy) {
            x_ = xx;
            y_ = yy;
        }

        public int X {
            get { return x_; }
        }

        public int Y {
            get { return y_; }
        }
    }
}
