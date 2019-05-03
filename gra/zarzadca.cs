using System;
using System.Windows.Forms;

namespace gra
{
    public partial class zarzadca : Form
    {
        public zarzadca()
        {
            InitializeComponent();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Clipboard.ContainsImage()) { (sender as PictureBox).Image = Clipboard.GetImage(); }
            }
            if (e.Button == MouseButtons.Right)
            {
                if ((sender as PictureBox).Image != null) { Clipboard.SetImage((sender as PictureBox).Image); }
            }
        }
        class wybor
        {
            public int ile;
            public override string ToString()
            {
                return "zrzut"+(ile+1).ToString();
            }
        }
        private void zarzadca_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                tabControl1.TabPages[i].Text = "zrzut"+(i+1).ToString();
                domainUpDown1.Items.Add(new wybor { ile = i });
            }
            domainUpDown1.SelectedIndex = 0;
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            if (domainUpDown1.SelectedIndex!=-1)
            {
                tabControl1.SelectedIndex = domainUpDown1.SelectedIndex;
                trackBar1.Value = domainUpDown1.SelectedIndex + 1;
                toolTip1.SetToolTip(domainUpDown1, ((PictureBox)tabControl1.SelectedTab.Controls[0]).Image == null ? "brak rysunku" : "włożono rysunek");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            domainUpDown1.SelectedIndex= tabControl1.SelectedIndex;
            trackBar1.Value = tabControl1.SelectedIndex + 1;
            toolTip1.SetToolTip(tabControl1, ((PictureBox)tabControl1.SelectedTab.Controls[0]).Image == null ? "brak rysunku" : "włożono rysunek");
        }

        private void domainUpDown1_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (wybor Wybor in domainUpDown1.Items)
            {
                if (domainUpDown1.Text == Wybor.ToString())
                {
                    domainUpDown1.SelectedIndex = Wybor.ile;
                    tabControl1.SelectedIndex = domainUpDown1.SelectedIndex;
                    trackBar1.Value = domainUpDown1.SelectedIndex + 1;
                    toolTip1.SetToolTip(domainUpDown1, ((PictureBox)tabControl1.SelectedTab.Controls[0]).Image == null ? "brak rysunku" : "włożono rysunek");
                }
            }

        }

        private void trackBar1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            domainUpDown1.SelectedIndex = trackBar1.Value-1;
            tabControl1.SelectedIndex = trackBar1.Value - 1;
            toolTip1.SetToolTip(trackBar1, trackBar1.Value.ToString());
        }
    }
}
