using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
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
        private void getRunningDrivers()
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
            table.Columns.Add("BaseName", typeof(string));
            table.Columns.Add("FileName", typeof(string));
            table.Columns.Add("LoadAddress", typeof(cLoadAddress));
            for (int i = 0; i < arraySize; i++)
            {
                StringBuilder sbN = new StringBuilder(1000);
                int result = GetDeviceDriverBaseName(ddAddresses[i], sbN, sbN.Capacity);
                StringBuilder sbF = new StringBuilder(1000);
                result = GetDeviceDriverFileName(ddAddresses[i], sbF, sbF.Capacity);
                table.Rows.Add(sbN.ToString(), sbF.ToString(), new cLoadAddress { LoadAddress = ddAddresses[i] });
            }
            table.DefaultView.Sort = "BaseName";
            dataGridView1.DataSource = table;
        }
        private void getRegistryDrivers()
        {//ErrorControl dword musi być
            DataTable table = new DataTable();
            table.Columns.Add("BaseName", typeof(string));
            table.Columns.Add("FileName", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Start", typeof(string));
            RegistryKey rKey = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\");
            foreach (string subKeyName in rKey.GetSubKeyNames())
            {
                RegistryKey subKey = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\"+subKeyName);
                string fileName="";
                string type = "";
                string start = "";
                foreach (string subKeyValueName in subKey.GetValueNames())
                {
                    if (subKeyValueName== "ImagePath")
                    {
                        fileName=(string)subKey.GetValue(subKeyValueName);
                    }
                    if (subKeyValueName == "Type")
                    {
                        switch ((int)subKey.GetValue(subKeyValueName))
                        {
                            case 1:
                            case 2:
                                type = "ring0";
                                break;
                            case 16:
                            case 32:
                                type = "ring1";
                                break;
                            case 4:
                            default:
                                type = "none";
                                break;
                        }
                    }
                    if (subKeyValueName == "Start")
                    {
                        switch ((int)subKey.GetValue(subKeyValueName))
                        {
                            case 0:
                                start = "boot";
                                break;
                            case 1:
                                start = "kernel";
                                break;
                            case 2:
                                start = "system";
                                break;
                            case 3:
                                start = "manual";
                                break;
                            case 4:
                            default:
                                start = "other";
                                break;
                        }
                    }
                }
                subKey.Close();
                table.Rows.Add(subKeyName,fileName,type,start);
            }
            rKey.Close();
            table.DefaultView.Sort = "BaseName";
            dataGridView2.DataSource = table;
        }
        private void sterowniki_Load(object sender, EventArgs e)
        {
            getRunningDrivers();
            getRegistryDrivers();
        }
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct UNICODE_STRING
        {
            public ushort Length;
            public ushort MaximumLength;
            public IntPtr Buffer;
        }
        [DllImport("NtDll.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern void RtlInitUnicodeString(ref UNICODE_STRING DestinationString, [MarshalAs(UnmanagedType.LPWStr)] string SourceString);
        [DllImport("ntdll.dll")]
        public static extern uint ZwLoadDriver(ref UNICODE_STRING DestinationString);
        [DllImport("ntdll.dll")]
        public static extern uint ZwUnloadDriver(ref UNICODE_STRING DestinationString);
        [DllImport("NtDll.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int RtlNtStatusToDosError(int Status);
        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            UNICODE_STRING unicodeString = new UNICODE_STRING();
            RtlInitUnicodeString(ref unicodeString, "\\Registry\\Machine\\System\\CurrentControlSet\\Services\\" + (string)dataGridView2.SelectedRows[0].Cells["BaseName"].Value);
            privilege driverPrivilege = new privilege("SeLoadDriverPrivilege");
            uint wynik=ZwLoadDriver(ref unicodeString);
            if (wynik == 0)
            {
                getRunningDrivers();
                return;
            }
            wynik = ZwUnloadDriver(ref unicodeString);
            if (wynik == 0)
            {
                getRunningDrivers();
                return;
            }
            if (wynik == 0xC0000061)
            {
                MessageBox.Show("Zostań administratorem");
            }
            else {
                MessageBox.Show(wynik.ToString("X8"));
            }
        }
    }
}
