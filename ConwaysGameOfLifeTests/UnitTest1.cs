using System;
using ConwaysGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLifeTests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void IsInGridAndAliveTest() {
            bool[,] arr = new bool[,] { { false, true, true }, { true, true, false }, { false, true, true } };
            Generation g = new Generation(arr);
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
        [TestMethod]
        public void CountNeighborsAlive() {
            bool[,] arr = new bool[,] { { false, true, true }, { true, true, false }, { false, true, true } };
            Generation g = new Generation(arr);
            Rules r = new Rules();

            //jmena promennych podle numericke klavesnice
            Coordinate c7 = new Coordinate(0, 0); //test pro 7
            Coordinate c8 = new Coordinate(1, 0); //test pro 8
            Coordinate c9 = new Coordinate(2, 0); //test pro 9
            Coordinate c4 = new Coordinate(0, 1); //test pro 4
            Coordinate c6 = new Coordinate(2, 1); //test pro 6
            Coordinate c1 = new Coordinate(0, 2); //test pro 1
            Coordinate c2 = new Coordinate(1, 2); //test pro 2
            Coordinate c3 = new Coordinate(2, 2); //test pro 3
            Assert.AreEqual(3, r.CountNeighborsAlive(c7, g));
            Assert.AreEqual(3, r.CountNeighborsAlive(c8, g));
            Assert.AreEqual(3, r.CountNeighborsAlive(c9, g));
            Assert.AreEqual(3, r.CountNeighborsAlive(c4, g));
            Assert.AreEqual(3, r.CountNeighborsAlive(c6, g));
            Assert.AreEqual(2, r.CountNeighborsAlive(c1, g));
            Assert.AreEqual(5, r.CountNeighborsAlive(c2, g));
            Assert.AreEqual(2, r.CountNeighborsAlive(c3, g));
            
        }
    }
}
