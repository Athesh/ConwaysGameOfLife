using System;
using ConwaysGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace ConwaysGameOfLifeTests {
    [TestClass]
    public class UnitTest1 {

        protected string GetTestDirectory() {
            string exeFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return exeFolder + @"\..\..\TestFiles\";
        }
        // + @"\..\..\Library\";
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
            Coordinate c5 = new Coordinate(1, 1); //test pro 5
            Coordinate c6 = new Coordinate(2, 1); //test pro 6
            Coordinate c1 = new Coordinate(0, 2); //test pro 1
            Coordinate c2 = new Coordinate(1, 2); //test pro 2
            Coordinate c3 = new Coordinate(2, 2); //test pro 3
            Assert.AreEqual(3, r.CountNeighborsAlive(c7, g));
            Assert.AreEqual(3, r.CountNeighborsAlive(c8, g));
            Assert.AreEqual(3, r.CountNeighborsAlive(c9, g));
            Assert.AreEqual(3, r.CountNeighborsAlive(c4, g));
            Assert.AreEqual(5, r.CountNeighborsAlive(c5, g));
            Assert.AreEqual(3, r.CountNeighborsAlive(c6, g));
            Assert.AreEqual(2, r.CountNeighborsAlive(c1, g));
            Assert.AreEqual(5, r.CountNeighborsAlive(c2, g));
            Assert.AreEqual(2, r.CountNeighborsAlive(c3, g));           
        }

        [TestMethod]
        public void IsAliveInNextGeneration() {
            bool[,] arr = new bool[,] { { false, true, true }, { true, true, false }, { false, true, true } };
            Generation g = new Generation(arr);
            Rules r = new Rules();

            Coordinate c7 = new Coordinate(0, 0); //test pro 7
            Coordinate c8 = new Coordinate(1, 0); //test pro 8
            Coordinate c9 = new Coordinate(2, 0); //test pro 9
            Coordinate c4 = new Coordinate(0, 1); //test pro 4
            Coordinate c5 = new Coordinate(1, 1); //test pro 5
            Coordinate c6 = new Coordinate(2, 1); //test pro 6
            Coordinate c1 = new Coordinate(0, 2); //test pro 1
            Coordinate c2 = new Coordinate(1, 2); //test pro 2
            Coordinate c3 = new Coordinate(2, 2); //test pro 3
            Assert.IsTrue(r.IsAliveInNextGeneration(r.IsInGridAndAlive(c7, g), r.CountNeighborsAlive(c7, g)));
            Assert.IsTrue(r.IsAliveInNextGeneration(r.IsInGridAndAlive(c8, g), r.CountNeighborsAlive(c8, g)));
            Assert.IsTrue(r.IsAliveInNextGeneration(r.IsInGridAndAlive(c9, g), r.CountNeighborsAlive(c9, g)));
            Assert.IsTrue(r.IsAliveInNextGeneration(r.IsInGridAndAlive(c4, g), r.CountNeighborsAlive(c4, g)));
            Assert.IsFalse(r.IsAliveInNextGeneration(r.IsInGridAndAlive(c5, g), r.CountNeighborsAlive(c5, g)));
            Assert.IsTrue(r.IsAliveInNextGeneration(r.IsInGridAndAlive(c6, g), r.CountNeighborsAlive(c6, g)));
            Assert.IsTrue(r.IsAliveInNextGeneration(r.IsInGridAndAlive(c1, g), r.CountNeighborsAlive(c1, g)));
            Assert.IsFalse(r.IsAliveInNextGeneration(r.IsInGridAndAlive(c2, g), r.CountNeighborsAlive(c2, g)));
            Assert.IsTrue(r.IsAliveInNextGeneration(r.IsInGridAndAlive(c3, g), r.CountNeighborsAlive(c3, g)));

        }

        [TestMethod]
        public void NextGen() {
            bool[,] arr = new bool[,] { { false, true, true }, { true, true, false }, { false, true, true } };
            Generation g = new Generation(arr);
            Rules r = new Rules();

            Coordinate c7 = new Coordinate(0, 0); //test pro 7
            Coordinate c8 = new Coordinate(1, 0); //test pro 8
            Coordinate c9 = new Coordinate(2, 0); //test pro 9
            Coordinate c4 = new Coordinate(0, 1); //test pro 4
            Coordinate c5 = new Coordinate(1, 1); //test pro 5
            Coordinate c6 = new Coordinate(2, 1); //test pro 6
            Coordinate c1 = new Coordinate(0, 2); //test pro 1
            Coordinate c2 = new Coordinate(1, 2); //test pro 2
            Coordinate c3 = new Coordinate(2, 2); //test pro 3

            Assert.IsFalse(r.IsInGridAndAlive(c5, r.NextGen(g)));
            Assert.IsFalse(r.IsInGridAndAlive(c2, r.NextGen(g)));
            Assert.IsTrue(r.IsInGridAndAlive(c1, r.NextGen(g)));
            Assert.IsTrue(r.IsInGridAndAlive(c3, r.NextGen(g)));
            Assert.IsTrue(r.IsInGridAndAlive(c4, r.NextGen(g)));
            Assert.IsTrue(r.IsInGridAndAlive(c6, r.NextGen(g)));
            Assert.IsTrue(r.IsInGridAndAlive(c7, r.NextGen(g)));
            Assert.IsTrue(r.IsInGridAndAlive(c8, r.NextGen(g)));
            Assert.IsTrue(r.IsInGridAndAlive(c9, r.NextGen(g)));
        }

        [TestMethod]
        public void LoaderTest() {
            string file = @"
3
3
_X_
XXX
X_X";
            bool[,] arr = new bool[,] { { false, true, true }, { true, true, false }, { false, true, true } };
            GenFileLoader loader = new GenFileLoader();
            //GenFileLoader loader = new GenFileLoader(GetTestDirectory() + "Test1.txt");
            Generation loaded = loader.Load(file);
            Generation expected = new Generation(arr);

            Assert.IsTrue(loaded.Equals(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(BadFormatException))]
        public void LoaderBadCharacterTest() {
            string file = @"
3
3
_C_
___
___";
            GenFileLoader loader = new GenFileLoader();
            Generation loaded = loader.Load(file);
        }

        [TestMethod]
        [ExpectedException(typeof(BadFormatException))]
        public void LoaderBadRowTest() {
            string file = @"
3
3
__
___
___";
            GenFileLoader loader = new GenFileLoader();
            Generation loaded = loader.Load(file);
        }

        [TestMethod]
        [ExpectedException(typeof(BadFormatException))]
        public void LoaderMissingRowTest() {
            string file = @"
3
3
___
___";
            GenFileLoader loader = new GenFileLoader();
            Generation loaded = loader.Load(file);
        }

        [TestMethod]
        [ExpectedException(typeof(BadFormatException))]
        public void LoaderBadNumberTest() {
            string file = @"
2.14
3
_X_
___
___";
            GenFileLoader loader = new GenFileLoader();
            Generation loaded = loader.Load(file);
        }

        [TestMethod]
        [ExpectedException(typeof(BadFormatException))]
        public void LoaderNotANumberTest() {
            string file = @"
Dude
?
_X_
___
___";
            GenFileLoader loader = new GenFileLoader();
            Generation loaded = loader.Load(file);
        }

        [TestMethod]
        [ExpectedException(typeof(BadFormatException))]
        public void LoaderNumberZeroTest() {
            string file = @"
0
2
_X_
_X_
___";
            GenFileLoader loader = new GenFileLoader();
            Generation loaded = loader.Load(file);
        }

        [TestMethod]
        [ExpectedException(typeof(BadFormatException))]
        public void LoaderNegativeNumberTest() {
            string file = @"
3
-3
_XX
___
___";
            GenFileLoader loader = new GenFileLoader();
            Generation loaded = loader.Load(file);
        }
    }
}
