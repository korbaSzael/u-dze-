using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Runtime.InteropServices;
using dll;

namespace gra
{
    public partial class GameNote : Form
    {
        private class noteEntry
        {
            public string fName; //file name
            public string pName; //path name
            public noteEntry() {
            }
            public static List<noteEntry> createList(string[] allNotes)
            {
                List<noteEntry> filePaths = new List<noteEntry>();
                foreach (string note in allNotes) {
                    filePaths.Add(new noteEntry() { pName = note.Substring(common.gamePath.Length, note.LastIndexOf('\\')- common.gamePath.Length+1), fName = note.Substring(note.LastIndexOf('\\')+1,note.Length- note.LastIndexOf('\\')-5) });
                }
                return filePaths;
            }
            public override string ToString() {
                return fName+"    "+pName;
            }
        }
        public GameNote()
        {
            InitializeComponent();
        }

        private void FillListBox() {
            List<noteEntry> zapPaths= noteEntry.createList(common.pathsToFiles(common.gamePath, "*.zap")).Where(entry => Regex.Match(entry.fName, textBox1.Text).Success).ToList();
            zapPaths.Sort(delegate (noteEntry e1, noteEntry e2){return e1.ToString().CompareTo(e2.ToString());});
            listBox1.Items.Clear();
            listBox1.Items.AddRange(zapPaths.ToArray());
        }
        private void GameNote_Load(object sender, EventArgs e)
        {
            FillListBox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FillListBox();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] allLines = File.ReadAllLines(common.gamePath + ((noteEntry)listBox1.SelectedItem).pName + ((noteEntry)listBox1.SelectedItem).fName + ".zap");
            richTextBox1.Text = "";
            for (int i=0;i<allLines.Length;i++) {
                richTextBox1.Text += allLines[i];
                if(i!= allLines.Length-1) richTextBox1.Text += "\n";
            }
            button1.Enabled = false;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void richTextBox1_ModifiedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(common.gamePath + ((noteEntry)listBox1.SelectedItem).pName + ((noteEntry)listBox1.SelectedItem).fName + ".zap", new string[] { richTextBox1.Text });
            button1.Enabled = false;
        }

        private void listBox1_ValueMemberChanged(object sender, EventArgs e)
        {
        }

        private void listBox1_SizeChanged(object sender, EventArgs e)
        {
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void richTextBox1_SizeChanged(object sender, EventArgs e)
        {
        }

        private void richTextBox1_RegionChanged(object sender, EventArgs e)
        {
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            button1.Enabled = true;
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
        }

        private void selectByPath(string path)
        {
            listBox1.SelectedIndex = -1;
            for(int index=0;index<listBox1.Items.Count;index++)
            {
                if (path == common.gamePath + ((noteEntry)listBox1.Items[index]).pName + ((noteEntry)listBox1.Items[index]).fName+".zap")listBox1.SelectedIndex = index;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "zapisy przemyśleń (*.zap)|*.zap|dowolne pliki (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.InitialDirectory = common.gamePath;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(saveFileDialog.FileName, new string[] { richTextBox1.Text });
                FillListBox();
                selectByPath(saveFileDialog.FileName);
            }
        }

    }
}
