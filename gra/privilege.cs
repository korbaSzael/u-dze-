using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.ComponentModel;

namespace gra
{
    public class privilege
    {
        public privilege(string privilegeName) //"SeLoadDriverPrivilege"
        { 
            IntPtr tokenHandle = IntPtr.Zero;
            try
            {
                if (!OpenProcessToken(Process.GetCurrentProcess().Handle,TOKEN_QUERY | TOKEN_ADJUST_PRIVILEGES,out tokenHandle))throw new Win32Exception(Marshal.GetLastWin32Error(),"Failed to open process token handle");
                TOKEN_PRIVILEGES tokenPrivs = new TOKEN_PRIVILEGES();
                tokenPrivs.PrivilegeCount = 1;
                tokenPrivs.Privileges = new LUID_AND_ATTRIBUTES[1];
                tokenPrivs.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;
                if (!LookupPrivilegeValue(null,privilegeName,out tokenPrivs.Privileges[0].Luid))throw new Win32Exception(Marshal.GetLastWin32Error(),"Failed to open lookup shutdown privilege");
                if (!AdjustTokenPrivileges(tokenHandle,false,ref tokenPrivs,0,IntPtr.Zero,IntPtr.Zero))throw new Win32Exception(Marshal.GetLastWin32Error(),"Failed to adjust process token privileges");
            }
            finally
            {
                if (tokenHandle != IntPtr.Zero)CloseHandle(tokenHandle);
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct LUID
        {
            public uint LowPart;
            public int HighPart;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct LUID_AND_ATTRIBUTES
        {
            public LUID Luid;
            public UInt32 Attributes;
        }
        private struct TOKEN_PRIVILEGES
        {
            public UInt32 PrivilegeCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public LUID_AND_ATTRIBUTES[] Privileges;
        }
        private const UInt32 TOKEN_QUERY = 0x0008;
        private const UInt32 TOKEN_ADJUST_PRIVILEGES = 0x0020;
        private const UInt32 SE_PRIVILEGE_ENABLED = 0x00000002;
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool OpenProcessToken(IntPtr ProcessHandle,UInt32 DesiredAccess,out IntPtr TokenHandle);
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool LookupPrivilegeValue(string lpSystemName,string lpName,out LUID lpLuid);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AdjustTokenPrivileges(IntPtr TokenHandle,[MarshalAs(UnmanagedType.Bool)]bool DisableAllPrivileges,ref TOKEN_PRIVILEGES NewState,UInt32 Zero,IntPtr Null1,IntPtr Null2);
     }
}