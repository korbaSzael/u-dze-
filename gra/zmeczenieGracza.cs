using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace gra
{
    public partial class zmeczenieGracza : Form
    {
        public zmeczenieGracza()
        {
            InitializeComponent();
        }

        private void zmeczenieGracza_Load(object sender, EventArgs e)
        {
            klikanie zmeczenie = new klikanie();
            zmeczenie.orThis = new klikanie.willOrThis(ileSieZmeczyl);
        }
        int kolejnosc = 0;
        public void ileSieZmeczyl(string co)
        {
            chart1.Series[0].Points.Add(new DataPoint(kolejnosc,co.Length));
            kolejnosc++;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void zmeczenieGracza_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
