using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    class Coordinate {
        int x_;
        int y_;

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
