using System;
using ConwaysGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLifeTests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void IsInGridAndAliveTest() {
            bool[,] pole = new bool[,] { { false, true, true }, { true, true, false }, { false, true, true } };
            Generation g = new Generation(pole);
            Rules r = new Rules();
            Coordinate c1 = new Coordinate(0, 1); //test zive bunky v poli
            Coordinate c2 = new Coordinate(0, 0); //test mrtve bunky v poli
            Coordinate c7 = new Coordinate(2, 2); //test pravy dolni roh

            Assert.IsTrue(r.IsInGridAndAlive(c1, g));
            Assert.IsFalse(r.IsInGridAndAlive(c2, g));
            Assert.IsTrue(r.IsInGridAndAlive(c7, g));

            //test bunek mimo pole
            Coordinate c3 = new Coordinate(3, 0); //preteceni vpravo
            Coordinate c4 = new Coordinate(-1, 0); //preteceni vlevo
            Coordinate c5 = new Coordinate(0, 3); //preteceni dole
            Coordinate c6 = new Coordinate(0, -1); //preteceni nahore

            Assert.IsFalse(r.IsInGridAndAlive(c3, g));
            Assert.IsFalse(r.IsInGridAndAlive(c4, g));
            Assert.IsFalse(r.IsInGridAndAlive(c5, g));
            Assert.IsFalse(r.IsInGridAndAlive(c6, g));
            
        }
    }
}
