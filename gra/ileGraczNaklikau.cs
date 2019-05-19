using System;
using System.Windows.Forms;

namespace gra
{
    public partial class ileGraczNaklikau : Form
    {
        public ileGraczNaklikau()
        {
            InitializeComponent();
        }
        private void ileGraczNaklikau_Load(object sender, EventArgs e)
        {
            klikanie wykryj = new klikanie();
            wykryj.orThis = new klikanie.willOrThis(napis);
        }
        public void keyDown(Keys klawisz)
        {
            if (klawisz != Keys.LButton)
            {
                textBox1.Text += klawisz.ToString();
            }
            else
            {
                textBox1.Text += "\r\n";
            }
        }
        public void napis(string co)
        {
            textBox1.Text += co + "\r\n";
        }
    }
}
