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
    public partial class MainForm : Form {
        GameEngine engine_;
        public MainForm(GameEngine engine) {
            engine_ = engine;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e) {
            Graphics gfx = e.Graphics;
            //int height = this.ClientSize.Height;
            //int width = this.ClientSize.Width;
            int squareSize = 10;
            Generation gen = engine_.CurrentGen;
            Pen myPen = new Pen(Color.Black);
            SolidBrush aliveCellBrush = new SolidBrush(Color.Black);
            Rules r = new Rules();

            for (int x = 0; x <= gen.Height; x++) { //vykreslování mřížky svisle
                gfx.DrawLine(myPen, 0, x * 9, gen.Width * 9, x * 9);
            }

            for (int y = 0; y <= gen.Width; y++) { //vykreslování mřížky vodorovně
                gfx.DrawLine(myPen, y * 9, 0, y * 9, gen.Height * 9);
            }

            for (int i = 0; i < gen.Width; i++) { //reprezentace buňek pomocí čtverečků
                for (int j = 0; j < gen.Height; j++) {
                    Coordinate coor = new Coordinate(i, j);
                    if (r.IsInGridAndAlive(coor, gen))
                        gfx.FillRectangle(aliveCellBrush, i * 9, j * 9, squareSize, squareSize);
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
