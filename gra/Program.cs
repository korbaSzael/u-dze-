using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gra
{
    static class Program
    {
        public static bool shouldStartAgain = true;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while (shouldStartAgain)
            {
                shouldStartAgain = false;
                Application.Run(new Form1());
            }
        }
    }
}
