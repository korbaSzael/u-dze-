using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gra
{
    public partial class sterowniki : Form
    {
        public sterowniki()
        {
            InitializeComponent();
        }
        [DllImport("psapi")]
        private static extern bool EnumDeviceDrivers(
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4)] [In][Out] UInt32[] ddAddresses,
            UInt32 arraySizeBytes,
            [MarshalAs(UnmanagedType.U4)] out UInt32 bytesNeeded
        );

        [DllImport("psapi")]
        private static extern int GetDeviceDriverBaseName(
            UInt32 ddAddress,
            StringBuilder ddBaseName,
            int baseNameStringSizeChars
        );
        [DllImport("psapi")]
        private static extern int GetDeviceDriverFileName(
        UInt32 ddAddress,
        StringBuilder ddBaseName,
        int baseNameStringSizeChars
        );
        class cLoadAddress
        {
            public uint LoadAddress;
            public override string ToString()
            {
                return LoadAddress.ToString("X8");
            }
        }
        private void sterowniki_Load(object sender, EventArgs e)
        {
            UInt32 arraySize;
            UInt32 arraySizeBytes;
            UInt32[] ddAddresses;
            UInt32 bytesNeeded;
            bool success;
            success = EnumDeviceDrivers(null, 0, out bytesNeeded);
            arraySize = bytesNeeded / 4;
            arraySizeBytes = bytesNeeded;
            ddAddresses = new UInt32[arraySize];
            success = EnumDeviceDrivers(ddAddresses, arraySizeBytes, out bytesNeeded);
            DataTable table = new DataTable();
            table.Columns.Add("LoadAddress", typeof(cLoadAddress));
            table.Columns.Add("BaseName", typeof(string));
            table.Columns.Add("FileName", typeof(string));
            for (int i = 0; i < arraySize; i++)
            {
                StringBuilder sbN = new StringBuilder(1000);
                int result = GetDeviceDriverBaseName(ddAddresses[i], sbN, sbN.Capacity);
                StringBuilder sbF = new StringBuilder(1000);
                result = GetDeviceDriverFileName(ddAddresses[i], sbF, sbF.Capacity);
                table.Rows.Add(new cLoadAddress { LoadAddress = ddAddresses[i] }, sbN.ToString(), sbF.ToString());
           }
            dataGridView1.DataSource = table;
            comboBox1.Items.Add("LoadAddress");
            comboBox1.Items.Add("BaseName");
            comboBox1.Items.Add("FileName");
            comboBox1.SelectedIndex = 1;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.Sort = comboBox1.Items[comboBox1.SelectedIndex] as string;
        }
        [DllImport("ntdll.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);
        private void button1_Click(object sender, EventArgs e)
        {
            String unicodeString = "\u005CRegistry\\Machine\\System\\CurrentControlSet\\Services\\";
            UnicodeEncoding unicode = new UnicodeEncoding();
            Byte[] encodedBytes = unicode.GetBytes(unicodeString);
            textBox1.Text = "";
            foreach (Byte b in encodedBytes)
            {
                textBox1.Text += b.ToString()+" ";
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = common.gamePath;
                openFileDialog1.Filter = "sys files (*.sys)|*.sys";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //IntPtr pDll = LoadLibrary(openFileDialog1.SafeFileName);
                    //odświerz
                }
        }
    }
}
