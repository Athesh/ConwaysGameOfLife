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
            //SolidBrush aliveBrush = new SolidBrush(Color.Black);
            //SolidBrush deadBrush = new SolidBrush(Color.White);
            //Rules r = new Rules();
            gfx.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 0, Width, Height));
            //gfx.DrawLine(myPen, X, Y, X1, Y1);

            for (int x = 0; x < gen.Height; x++) {
                gfx.DrawLine(myPen, 0, x * 9, gen.Width * 9 - 9, x * 9);
            }

            for (int y = 0; y < gen.Width; y++) {
                gfx.DrawLine(myPen, y * 9, 0, y * 9, gen.Height * 9 - 9);
            }

            //TODO Nakreslit bunky reprezentujici pole

            /*SolidBrush blackBrush = new SolidBrush(Color.Black);
            gfx.FillRectangle(blackBrush, randomNumber, randomNumber, 10, 10);*/
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
