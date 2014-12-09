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
            int height = this.ClientSize.Height - 10;
            int width = this.ClientSize.Width - 100;
            Random random = new Random();
            int randomNumber = random.Next(0, Math.Min(height, width));
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            gfx.FillRectangle(blackBrush, randomNumber, randomNumber, 10, 10);
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
