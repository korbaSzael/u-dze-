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
using System.IO;

namespace gra
{
    public partial class Biblioteki : Form
    {
        DataTable tableExports = null;
        DataTable tableImports = null;
        public Biblioteki()
        {
            InitializeComponent();
        }
        private void bExports_Click(object sender, EventArgs e)
        {
            tableExports = new DataTable();
            tableExports.Columns.Add("export name", typeof(string));
            tableExports.Columns.Add("address", typeof(cAddress));
            tableExports.Columns.Add("size", typeof(cSize));
                IntPtr pHandle = OpenProcess(0x1F0FFF, true, (comboBox2.SelectedItem as cbProcess).id);
                ulong baseOfDll;
                bool status;
                status = SymInitialize(pHandle, null, false);
                baseOfDll = SymLoadModuleEx(pHandle, IntPtr.Zero, (comboBox1.SelectedItem as cbModule).file, null, 0, 0, IntPtr.Zero, 0);
                if (baseOfDll != 0 && SymEnumerateSymbols64(pHandle, baseOfDll, EnumSyms, IntPtr.Zero) != false)
                {
                    dataGridView1.DataSource = tableExports;
                    (dataGridView1.DataSource as DataTable).DefaultView.Sort = "export name";
                }
                SymCleanup(pHandle);
                CloseHandle(pHandle);
            }
        public bool EnumSyms(string name, ulong address, uint givenSize, IntPtr context)
        {
            tableExports.Rows.Add(name,new cAddress{address = address}, new cSize { size = givenSize });
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
            comboBox1.Font = new Font(comboBox1.Font, FontStyle.Regular);
            textBox1.Text = (comboBox1.SelectedItem as cbModule).name;
            textBox3.Text = (comboBox1.SelectedItem as cbModule).basee.ToString("X8");
            textBox4.Text = (comboBox1.SelectedItem as cbModule).entry.ToString("X8");
            textBox5.Text = (comboBox1.SelectedItem as cbModule).file;
            textBox9.Text = (comboBox1.SelectedItem as cbModule).mSize.ToString("X8");
            dataGridView1.DataSource = null;
            if ((comboBox1.SelectedItem as cbModule).name != "odmowa dostępu")
            {
                bExports_Click(null,null);
                computeDLLimports();
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
            comboBox2.Font = new Font(comboBox2.Font, FontStyle.Regular);
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
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = common.gamePath;
            openFileDialog1.Filter = "dll files (*.dll)|*.dll|exe files (*.exe)|*.exe";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IntPtr pDll = LoadLibrary(openFileDialog1.FileName);
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
        [DllImport("kernel32")]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess,IntPtr lpThreadAttributes,uint dwStackSize,IntPtr lpStartAddress,IntPtr lpParameter,uint dwCreationFlags,out uint lpThreadId);
        private void button1_Click_1(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedItem as cbModule).name != "odmowa dostępu")
            {
                IntPtr pHandle = OpenProcess(0x1F0FFF, true, (comboBox2.SelectedItem as cbProcess).id);
                uint dwThreadId;
                IntPtr hThread = CreateRemoteThread(pHandle, IntPtr.Zero, 0, new IntPtr(int.Parse(textBox12.Text, System.Globalization.NumberStyles.HexNumber)), new IntPtr(0), 0, out dwThreadId);
                textBox1.Text += dwThreadId.ToString();
                CloseHandle(pHandle);
            }
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess,IntPtr lpBaseAddress,byte[] lpBuffer,Int32 nSize,out IntPtr lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((comboBox1.SelectedItem as cbModule).name != "odmowa dostępu" && e.KeyCode == Keys.Right)
            {
                string DIR = common.gamePath + DateTime.Today.ToString("yyyyMMdd");
                if (!Directory.Exists(DIR)) Directory.CreateDirectory(DIR);
                DIR += "\\" + (comboBox2.SelectedItem as cbProcess).name;
                if (!Directory.Exists(DIR)) Directory.CreateDirectory(DIR);
                DIR += "\\" + (comboBox1.SelectedItem as cbModule).name;
                bool vp, rpm;
                using (FileStream fs = File.Create(DIR))
                {
                    IntPtr pHandle = OpenProcess(0x1F0FFF, true, (comboBox2.SelectedItem as cbProcess).id);
                    byte[] contents = new byte[(comboBox1.SelectedItem as cbModule).mSize];
                    uint lpflOldProtect;
                    vp = VirtualProtectEx(pHandle, (comboBox1.SelectedItem as cbModule).basee, (comboBox1.SelectedItem as cbModule).mSize, 0x40, out lpflOldProtect);
                    IntPtr lpNumberOfBytesRead;
                    rpm = ReadProcessMemory(pHandle, (comboBox1.SelectedItem as cbModule).basee, contents, (comboBox1.SelectedItem as cbModule).mSize, out lpNumberOfBytesRead);
                    CloseHandle(pHandle);
                    fs.Write(contents, 0, contents.Length);
                }
                if (vp == false || rpm == false)
                {
                    File.Delete(DIR);
                    comboBox1.Font = new Font(comboBox1.Font, FontStyle.Strikeout);
                    e.Handled = true;
                }
            }
            if ((comboBox1.SelectedItem as cbModule).name != "odmowa dostępu" && e.KeyCode == Keys.Left && Directory.Exists(common.gamePath + DateTime.Today.ToString("yyyyMMdd")) && Directory.Exists(common.gamePath + DateTime.Today.ToString("yyyyMMdd")+"\\" + (comboBox2.SelectedItem as cbProcess).name)&& File.Exists(common.gamePath + DateTime.Today.ToString("yyyyMMdd") + "\\" + (comboBox2.SelectedItem as cbProcess).name+ "\\" + (comboBox1.SelectedItem as cbModule).name))
            {
                byte[] contents=File.ReadAllBytes(common.gamePath + DateTime.Today.ToString("yyyyMMdd") + "\\" + (comboBox2.SelectedItem as cbProcess).name + "\\" + (comboBox1.SelectedItem as cbModule).name);
                bool vp=false, rpm=false;
                if (contents.Length== (comboBox1.SelectedItem as cbModule).mSize)
                {
                    IntPtr pHandle = OpenProcess(0x1F0FFF, true, (comboBox2.SelectedItem as cbProcess).id);
                    uint lpflOldProtect;
                    vp = VirtualProtectEx(pHandle, (comboBox1.SelectedItem as cbModule).basee, (comboBox1.SelectedItem as cbModule).mSize, 0x40, out lpflOldProtect);
                    IntPtr lpNumberOfBytesWrite;
                    rpm = WriteProcessMemory(pHandle, (comboBox1.SelectedItem as cbModule).basee, contents, (comboBox1.SelectedItem as cbModule).mSize, out lpNumberOfBytesWrite);
                    CloseHandle(pHandle);
                }
                if (vp == false || rpm == false)
                {
                    comboBox1.Font = new Font(comboBox1.Font, FontStyle.Strikeout);
                    e.Handled = true;
                }
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((comboBox1.SelectedItem as cbModule).name != "odmowa dostępu" && e.KeyCode == Keys.Right)
            {
                cbModule lastModule = comboBox1.SelectedItem as cbModule;
                foreach (cbModule currentModule in comboBox1.Items)
                {
                    comboBox1.SelectedItem = currentModule;
                    comboBox1_KeyDown(null, new KeyEventArgs(Keys.Right));
                }
                comboBox1.SelectedItem = lastModule;
            }
            if ((comboBox1.SelectedItem as cbModule).name != "odmowa dostępu" && e.KeyCode == Keys.Left)
            {
                cbModule lastModule = comboBox1.SelectedItem as cbModule;
                foreach (cbModule currentModule in comboBox1.Items)
                {
                    comboBox1.SelectedItem = currentModule;
                    comboBox1_KeyDown(null, new KeyEventArgs(Keys.Left));
                }
                comboBox1.SelectedItem = lastModule;
            }
        }
        void computeDLLimports()
        {
            tableImports = new DataTable();
            computeImports ci = new computeImports((comboBox1.SelectedItem as cbModule).file, tableImports);
            dataGridView2.DataSource = tableImports;
        }
    }

}

