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
        DataTable table = null;
        public Biblioteki()
        {
            InitializeComponent();
        }
        private void bExports_Click(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("address", typeof(cAddress));
            table.Columns.Add("size", typeof(cSize));
                IntPtr pHandle = OpenProcess(0x1F0FFF, true, (comboBox2.SelectedItem as cbProcess).id);
                ulong baseOfDll;
                bool status;
                status = SymInitialize(pHandle, null, false);
                baseOfDll = SymLoadModuleEx(pHandle, IntPtr.Zero, (comboBox1.SelectedItem as cbModule).file, null, 0, 0, IntPtr.Zero, 0);
                if (baseOfDll != 0 && SymEnumerateSymbols64(pHandle, baseOfDll, EnumSyms, IntPtr.Zero) != false)
                {
                    dataGridView1.DataSource = table;
                    (dataGridView1.DataSource as DataTable).DefaultView.Sort = "name";
                }
                SymCleanup(pHandle);
                CloseHandle(pHandle);
            }
        public bool EnumSyms(string name, ulong address, uint size, IntPtr context)
        {
            table.Rows.Add(name,new cAddress{address = address}, new cSize { size = address });
            return true;
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
            dataGridView1.DataSource = null;
            if ((comboBox1.SelectedItem as cbModule).name != "odmowa dostępu")
            {
                bExports_Click(null,null);
            }
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
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);
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
            if ((comboBox2.SelectedItem as cbProcess).id== Process.GetCurrentProcess().Id)
            {
                bLoadLibrary.Enabled = true;
                bFreeLibrary.Enabled = true;
            }
            else
            {
                bLoadLibrary.Enabled = false;
                bFreeLibrary.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = common.gamePath;
            openFileDialog1.Filter = "dll files (*.dll)|*.dll";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IntPtr pDll = LoadLibrary(openFileDialog1.SafeFileName);
                comboBox2_SelectedIndexChanged(null,null);
            }

        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeLibrary(IntPtr hModule);
        private void button2_Click(object sender, EventArgs e)
        {
            FreeLibrary((comboBox1.SelectedItem as cbModule).basee);
            comboBox2_SelectedIndexChanged(null, null);
        }

        [DllImport("dbghelp.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SymInitialize(IntPtr hProcess, string UserSearchPath, [MarshalAs(UnmanagedType.Bool)]bool fInvadeProcess);

        [DllImport("dbghelp.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SymCleanup(IntPtr hProcess);

        [DllImport("dbghelp.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern ulong SymLoadModuleEx(IntPtr hProcess, IntPtr hFile,
             string ImageName, string ModuleName, long BaseOfDll, int DllSize, IntPtr Data, int Flags);

        [DllImport("dbghelp.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SymEnumerateSymbols64(IntPtr hProcess,
           ulong BaseOfDll, SymEnumerateSymbolsProc64 EnumSymbolsCallback, IntPtr UserContext);

        public delegate bool SymEnumerateSymbolsProc64(string SymbolName,
              ulong SymbolAddress, uint SymbolSize, IntPtr UserContext);
        class cAddress
        {
            public ulong address;
            public override string ToString()
            {
                return address.ToString("X8");
            }
        }
        class cSize
        {
            public ulong size;
            public override string ToString()
            {
                return size.ToString("X8");
            }
        }
    }
}
