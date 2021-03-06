﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    public class GenFileLoader {

        public GenFileLoader() { }

        private void ParseLine (bool[,] arr, int rowNumber, string row){ //zpravocani konkretniho radku ve vybraném poli
            for (int i = 0; i < row.Length; i++) {  //for cyklus pro načtení i-té řádky do pole
                char cell = row.ElementAt(i); //prvek na dane pozici v retezci
                if (cell == '_') {
                    arr[i, rowNumber] = false;
                }
                else if (cell == 'X') {
                    arr[i, rowNumber] = true;
                }
                else {
                    throw new BadFormatException("Spatny znak na pozici: " + "[" + i + "," + rowNumber + "] : " + cell);
                }
            }
        }

        public Generation Load(string obsahSouboru) {   //metoda pro načtení obsahu souboru do programu
            string[] lines = obsahSouboru.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int width;
            int height;

            if (!Int32.TryParse(lines[0], out width))
                throw new BadFormatException("Spatne zadana sirka");

            if (!Int32.TryParse(lines[1], out height))
                throw new BadFormatException("Spatne zadana vyska");

            if (width <= 0 || height <= 0)
                throw new BadFormatException("Vyska nebo sirka nemuze mit nulove rozmery nebo byt zaporna");

            if (lines.Length - 2 != height)
                    throw new BadFormatException("Nespravna delka sloupce");

            bool[,] arr = new bool[width, height];

            for (int i = 0; i < height; i++) {
                if (lines[i + 2].Length != width) {
                    throw new BadFormatException("Nespravna delka radku cislo " + i);
                }
                else {
                    ParseLine(arr, i, lines[i + 2]);
                }
            }

            return new Generation(arr);
        }
    }
}
