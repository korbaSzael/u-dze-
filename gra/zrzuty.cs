using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dll;
using System.Diagnostics;

namespace gra
{
    public partial class zrzuty : Form
    {
        public zrzuty()
        {
            InitializeComponent();
        }
        List<TreeNode> getTreeNodes(List<window> allWindows)
        {
            List<TreeNode> ltn = new List<TreeNode>();
            if(allWindows==null) return ltn;
            foreach (window wnd in allWindows) {
                    TreeNode tn = new TreeNode();
                    tn.Text = wnd.name;
                    tn.Tag = wnd;
                    tn.Nodes.AddRange(getTreeNodes(wnd.childWindows).ToArray());
                    ltn.Add(tn);
            }
            
            return ltn;
        }
        string choosenFolder = common.gamePath.Remove(common.gamePath.ToString().LastIndexOf("\\"), 1);
        private void zrzuty_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.AddRange(getTreeNodes(dll.dll.allWindows()).ToArray());
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBox1.Text = (treeView1.SelectedNode.Tag as window).className;
            textBox2.Text = (treeView1.SelectedNode.Tag as window).handle.ToString("X8");
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            common.WNDtoBMP((treeView1.SelectedNode.Tag as window).handle, choosenFolder +"\\"+ textBox3.Text);
            Process.Start(choosenFolder+"\\" + textBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description="Wybierz folder w jaki będziesz zapisywać zrzuty...";
            folderBrowserDialog1.SelectedPath = choosenFolder;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                choosenFolder=folderBrowserDialog1.SelectedPath;
            }
        }
        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.SelectionStart = 0;
            textBox3.SelectionLength = textBox3.Text.Length-4;
        }
    }
}
