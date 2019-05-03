using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace gra
{
    public partial class Biblioteki : Form
    {
        public Biblioteki()
        {
            InitializeComponent();
        }

        class cbModule
        {
            public string name;
            public IntPtr basee;
            public IntPtr entry;
            public string file;
            public int mSize;
            public override string ToString()
            {
                return name;
            }
        }
        class cbProcess
        {
            public string name;
            public int id;
            public override string ToString()
            {
                return name;
            }
        }

        private void Biblioteki_Load(object sender, EventArgs e)
        {
            loadProcesses();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = (comboBox1.SelectedItem as cbModule).name;
            textBox3.Text = (comboBox1.SelectedItem as cbModule).basee.ToString("X8");
            textBox4.Text = (comboBox1.SelectedItem as cbModule).entry.ToString("X8");
            textBox5.Text = (comboBox1.SelectedItem as cbModule).file;
            textBox9.Text = (comboBox1.SelectedItem as cbModule).mSize.ToString("X8");
        }

        private void loadProcesses()
        {
            comboBox2.Items.Clear();
            Process[] processTable = Process.GetProcesses();
            cbProcess[] processes = new cbProcess[processTable.Length];
            for (int i = 0; i < processTable.Length; i++) processes[i] = new cbProcess { id=processTable[i].Id,name=processTable[i].ProcessName};
            comboBox2.Items.AddRange(processes);
            Process current = Process.GetCurrentProcess();
            foreach (cbProcess pr in processes) if(pr.id==current.Id)comboBox2.SelectedItem=pr;
            comboBox1.Items.Clear();
            cbModule[] modules = new cbModule[current.Modules.Count];
            for (int i = 0; i < current.Modules.Count; i++) modules[i] = new cbModule { name = current.Modules[i].ModuleName, basee = current.Modules[i].BaseAddress, entry = current.Modules[i].EntryPointAddress, file = current.Modules[i].FileName,mSize= current.Modules[i].ModuleMemorySize };
            comboBox1.Items.AddRange(modules);
            foreach (cbModule module in modules) if (module.basee==current.MainModule.BaseAddress) comboBox1.SelectedItem = module;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Process current = Process.GetProcessById((comboBox2.SelectedItem as cbProcess).id);
            comboBox1.Items.Clear();
            try
            {
                cbModule[] modules = new cbModule[current.Modules.Count];
                for (int i = 0; i < current.Modules.Count; i++) modules[i] = new cbModule { name = current.Modules[i].ModuleName, basee = current.Modules[i].BaseAddress, entry = current.Modules[i].EntryPointAddress, file = current.Modules[i].FileName, mSize = current.Modules[i].ModuleMemorySize };
                comboBox1.Items.AddRange(modules);
                foreach (cbModule module in modules) if (module.basee == current.MainModule.BaseAddress) comboBox1.SelectedItem = module;
            }
            catch (Exception ex)
            {
                cbModule module = new cbModule { name = "odmowa dostępu", basee = IntPtr.Zero, entry = IntPtr.Zero, file = "odmowa dostępu" };
                comboBox1.Items.Add(module);
                comboBox1.SelectedItem = module;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);//out IntPtr lpNumberOfBytesRead);//int lpNumberOfBytesRead
        [DllImport("kernel32.dll")]
        static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress,int dwSize, uint flNewProtect, out uint lpflOldProtect);
        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedItem as cbModule).name != "odmowa dostępu") {
                IntPtr pHandle = OpenProcess(0x1F0FFF, true, (comboBox2.SelectedItem as cbProcess).id);
                byte[] contents = new byte[(comboBox1.SelectedItem as cbModule).mSize];
                uint lpflOldProtect;
                textBox1.Text = VirtualProtectEx(pHandle, (comboBox1.SelectedItem as cbModule).basee, (comboBox1.SelectedItem as cbModule).mSize, 0x40, out lpflOldProtect).ToString();
                IntPtr lpNumberOfBytesRead;//null??
                textBox1.Text += ReadProcessMemory(pHandle, (comboBox1.SelectedItem as cbModule).basee,contents, (comboBox1.SelectedItem as cbModule).mSize, out lpNumberOfBytesRead).ToString();
                CloseHandle(pHandle);
            }
        }
    }
}
