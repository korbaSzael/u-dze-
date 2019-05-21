using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
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
