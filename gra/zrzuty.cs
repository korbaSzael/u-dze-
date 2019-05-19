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
        private void zrzuty_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.AddRange(getTreeNodes(dll.dll.allWindows()).ToArray());
            dirListBox1.Path = common.gamePath.Remove(common.gamePath.ToString().LastIndexOf("\\"), 1);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBox1.Text = (treeView1.SelectedNode.Tag as window).className;
            textBox2.Text = (treeView1.SelectedNode.Tag as window).handle.ToString("X8");
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            string where="";
            if (fileListBox1.SelectedIndex == -1) where = dirListBox1.Path + "\\windowShot.bmp";
            if (fileListBox1.SelectedIndex != -1) where = dirListBox1.Path + "\\"+fileListBox1.SelectedItem;
            common.WNDtoBMP((treeView1.SelectedNode.Tag as window).handle,where);
            fileListBox1.Refresh();
            Process.Start(where);
        }
        private void driveListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string oldDir = dirListBox1.Path;
            try
            {
                dirListBox1.Path = driveListBox1.Drive;
            }catch(Exception ex)
            {
                dirListBox1.Path = oldDir;
            }
        }

        private void dirListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            fileListBox1.Path = dirListBox1.Path;
        }

        private void dirListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
