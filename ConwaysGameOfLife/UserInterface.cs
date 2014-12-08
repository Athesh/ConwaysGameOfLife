using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    public interface UserInterface { //definice struktury UIčka
        void Update();
        void Run(GameEngine engine);
    }
}
