using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLife {
    public class GUI : UserInterface{   ///Grafické prostředí hry

        MainForm form_;

        private delegate void RefreshDelegate();
        //http://visualstudiomagazine.com/Articles/2010/11/18/Multithreading-in-WinForms.aspx?Page=1

        public void Refresh (){
            form_.Refresh();
        }

        public void Update() {
            //Když uživatel zavře aplikaci, tak form_ přestane být platnou referencí na objekt formuláře
            try {
                form_.Invoke(new RefreshDelegate(Refresh));
            }
            catch (Exception) {
            }
        }

        public void Run(GameEngine engine) {
            form_ = new MainForm(engine);
            Application.Run(form_);
            
        }

    }
}
