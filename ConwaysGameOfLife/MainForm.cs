using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLife {
    public partial class MainForm : Form {  ///hlavní formulář pro vykreslování hry
        GameEngine engine_;
        public MainForm(GameEngine engine) {
            DoubleBuffered = true; //zapnutí flagu pro dvojitě bufferovaný form
            this.BackColor = Color.FromArgb(49, 47, 49);
            engine_ = engine;
            InitializeComponent();
        }

        public int MinGridScale(int formHeight, int formWidth) {    //počítání velikosti mřížky podle velikosti formuláře
            Generation gen = engine_.CurrentGen;
            double a = formWidth / gen.Width;
            double b = formHeight / gen.Height;
            Math.Round(a, MidpointRounding.AwayFromZero);
            Math.Round(b, MidpointRounding.AwayFromZero);
            if (a <= b)
                return (int)a;
            else
                return (int)b;
        }

        protected override void OnPaint(PaintEventArgs e) { //vykreslování hry samotné
            Graphics gfx = e.Graphics;
            int height = this.ClientSize.Height;
            int width = this.ClientSize.Width;

            int squareSize = MinGridScale(height, width);
            Generation gen = engine_.CurrentGen;
            Pen myPen = new Pen(Color.Gray);
            SolidBrush aliveCellBrush = new SolidBrush(Color.White);
            Rules r = new Rules();

            for (int x = 0; x <= gen.Height; x++) { //vykreslování mřížky svisle
                gfx.DrawLine(myPen, 0, x * (squareSize - 1), gen.Width * (squareSize - 1), x * (squareSize - 1));
            }
            //(squareSize - 1) -> vykreslování mřížky na základě velikosti čtverečku
            for (int y = 0; y <= gen.Width; y++) { //vykreslování mřížky vodorovně
                gfx.DrawLine(myPen, y * (squareSize - 1), 0, y * (squareSize - 1), gen.Height * (squareSize - 1));
            }

            for (int i = 0; i < gen.Width; i++) { //reprezentace buňek pomocí čtverečků
                for (int j = 0; j < gen.Height; j++) {
                    Coordinate coor = new Coordinate(i, j);
                    if (r.IsInGridAndAlive(coor, gen))
                        gfx.FillRectangle(aliveCellBrush, i * (squareSize - 1), j * (squareSize - 1), squareSize, squareSize);
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
    }
}
