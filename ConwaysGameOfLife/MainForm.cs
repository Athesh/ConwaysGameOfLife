﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ConwaysGameOfLife {
    public partial class MainForm : Form {  ///hlavní formulář pro vykreslování hry
        GameEngine engine_;
        public MainForm(GameEngine engine) {
            DoubleBuffered = true;  //zapnutí flagu pro dvojitě bufferovaný form
            ResizeRedraw = true;    //překreslení formuláře při jeho změně velikosti
            this.MouseClick += new MouseEventHandler(FormMouseClick);   //přidání nového handleru pro mouse click
            this.BackColor = Color.FromArgb(49, 47, 49);    //barva pozadí formuláře
            engine_ = engine;
            InitializeComponent();  //inicializace komponenty
            //this.speedTrackBar.BackColor = Color.FromArgb(49, 47, 49);
        }

        private const int RIGHT_BUTTON_MARGIN = 100;    //konstanta pro odsazení hracího pole od tlačítek
        OpenFileDialog ofd = new OpenFileDialog();  //instance nového Open file dialogu

        public int MinGridScale() {    //počítání velikosti mřížky podle velikosti formuláře
            Generation gen = engine_.CurrentGen;
            int formHeight = this.ClientSize.Height - 1; //fix mizení dolní čáry při změně velikosti formuláře
            int formWidth = this.ClientSize.Width - RIGHT_BUTTON_MARGIN; //odsazení formuláře od tlačítek
            int a = formWidth / gen.Width;
            int b = formHeight / gen.Height;
            return Math.Min(a, b);
        }

        protected override void OnPaint(PaintEventArgs e) { //vykreslování hry samotné
            Graphics gfx = e.Graphics;
            int squareSize = MinGridScale();
            Generation gen = engine_.CurrentGen;
            Pen myPen = new Pen(Color.Gray);
            SolidBrush aliveCellBrush = new SolidBrush(Color.White);
            SolidBrush deadCellBrush = new SolidBrush(Color.FromArgb(49, 47, 49));
            Rules r = new Rules();

            for (int x = 0; x <= gen.Height; x++) { //vykreslování mřížky svisle
                gfx.DrawLine(myPen, 0, x * squareSize, gen.Width * squareSize, x * squareSize);
            }
            //squareSize -> vykreslování mřížky na základě velikosti čtverečku
            for (int y = 0; y <= gen.Width; y++) { //vykreslování mřížky vodorovně
                gfx.DrawLine(myPen, y * squareSize, 0, y * squareSize, gen.Height * squareSize);
            }

            for (int i = 0; i < gen.Width; i++) { //reprezentace buňek pomocí čtverečků
                for (int j = 0; j < gen.Height; j++) {
                    Coordinate coor = new Coordinate(i, j);
                    if (r.IsInGridAndAlive(coor, gen))
                        gfx.FillRectangle(aliveCellBrush, (i * squareSize) + 1, (j * squareSize) + 1, squareSize - 1, squareSize - 1);
                    else
                        gfx.FillRectangle(deadCellBrush, (i * squareSize) + 1, (j * squareSize) + 1, squareSize - 1, squareSize - 1);
                }
            }
            label2.Text = engine_.Number.ToString();
        }

        private void FormMouseClick(object sender, MouseEventArgs e) {
            Generation gen = engine_.CurrentGen;
            int cellSize = MinGridScale();
            int x = e.X / cellSize;
            int y = e.Y / cellSize;
            Coordinate coor = new Coordinate(x, y);

            if ((x < gen.Width) && (x >= 0)) {
                if ((y < gen.Height) && (y >= 0)) { //kliknutí uživatele na mřížku
                    engine_.InvertAt(coor);
                }
            }
        }

        private void step_Click(object sender, EventArgs e) {
            engine_.Step();
        }

        private void start_Click(object sender, EventArgs e) {
            engine_.Start();
        }

        private void stop_Click(object sender, EventArgs e) {
            engine_.Stop();
        }

        private void Load_Click(object sender, EventArgs e) {
            ofd.Filter = "TXT|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK) {
                GenFileLoader loader = new GenFileLoader();
                Generation g = loader.Load(System.IO.File.ReadAllText(ofd.FileName));
                engine_.CurrentGen = g;
                engine_.Refresh();
            }
        }

        private void Save_Click(object sender, EventArgs e) {
            Generation g = engine_.CurrentGen;
            GenFileSaver saver = new GenFileSaver();
            saver.Save(g, "Testing.txt");
        }

        private void speedTrackBar_Scroll(object sender, EventArgs e) {
            numericSpeed.Text = speedTrackBar.Value.ToString();
            engine_.Speed = speedTrackBar.Value;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = engine_.Number.ToString();
            label2.Refresh();
        } 
    }
}
