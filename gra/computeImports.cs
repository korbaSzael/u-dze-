using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Security;

namespace gra
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct IMAGE_IMPORT_BY_NAME{
        [FieldOffset(0)]
        public ushort Hint;
        [FieldOffset(2)]
        public fixed char Name[1];
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_IMPORT_DESCRIPTOR{
        [FieldOffset(0)]
        public uint OriginalFirstThunk;
        [FieldOffset(4)]
        public uint TimeDateStamp;
        [FieldOffset(8)]
        public uint ForwarderChain;
        [FieldOffset(12)]
        public uint Name;
        [FieldOffset(16)]
        public uint FirstThunk;
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct THUNK_DATA{
        [FieldOffset(0)]
        public uint ForwarderString;
        [FieldOffset(0)]
        public uint Function;
        [FieldOffset(0)]
        public uint Ordinal;
        [FieldOffset(0)]
        public uint AddressOfData;
    }
    public unsafe class computeImports{
        [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, EntryPoint = "GetModuleHandleA"), SuppressUnmanagedCodeSecurity]
        public static extern void* GetModuleHandleA(char* moduleName);
        [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, EntryPoint = "GetModuleHandleW"), SuppressUnmanagedCodeSecurity]
        public static extern void* GetModuleHandleW(char* moduleName);
        [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, EntryPoint = "IsBadReadPtr"), SuppressUnmanagedCodeSecurity]
        public static extern bool IsBadReadPtr(void* ptrAddress, uint someUINT);
        [DllImport("Dbghelp", CallingConvention = CallingConvention.Winapi, EntryPoint = "ImageDirectoryEntryToData"), SuppressUnmanagedCodeSecurity]
        public static extern void* ImageDirectoryEntryToData(void* address, bool someBool, ushort DirectoryEntry, out uint givenSize);
        [DllImport("kernel32.dll"), SuppressUnmanagedCodeSecurity]
        static extern uint LoadLibraryEx(string fileName, uint alwaysZero, uint alsoZero);
        public computeImports(string path,DataTable table)
        {
            uint hLib = LoadLibraryEx(path, 0,0);
            uint size = 0;
            IMAGE_IMPORT_DESCRIPTOR* pIID = (IMAGE_IMPORT_DESCRIPTOR*)ImageDirectoryEntryToData((void*)hLib, true, 1, out size);
            if (hLib != 0 && pIID != null)
            {
                table.Columns.Add("import function", typeof(string));
                table.Columns.Add("address", typeof(string));
                table.Columns.Add("dll", typeof(string));
                table.Columns.Add("ordinal", typeof(string));
                while (pIID->OriginalFirstThunk != 0)
                {
                    char* szName = (char*)(hLib + pIID->Name);
                    string name = Marshal.PtrToStringAnsi((IntPtr)szName);
                    THUNK_DATA* pThunkOrg = (THUNK_DATA*)(hLib + pIID->OriginalFirstThunk);
                    while (pThunkOrg->AddressOfData != 0)
                    {
                        char* szImportName;
                        uint Ord;
                        if ((pThunkOrg->Ordinal & 0x80000000) > 0)
                        {
                            Ord = pThunkOrg->Ordinal & 0xffff;
                            table.Rows.Add("", pThunkOrg->Function.ToString("X8"), name, Ord.ToString());
                        }
                        else
                        {
                            IMAGE_IMPORT_BY_NAME* pIBN = (IMAGE_IMPORT_BY_NAME*)(hLib + pThunkOrg->AddressOfData);
                            if (!IsBadReadPtr((void*)pIBN, (uint)sizeof(IMAGE_IMPORT_BY_NAME)))
                            {
                                Ord = pIBN->Hint;
                                szImportName = (char*)pIBN->Name;
                                string sImportName = Marshal.PtrToStringAnsi((IntPtr)szImportName);
                                table.Rows.Add(sImportName, pThunkOrg->Function.ToString("X8"), name, Ord.ToString());
                            }
                            else
                            {
                                break;
                            }
                        }
                        pThunkOrg++;
                    }
                    pIID++;
                }
                table.DefaultView.Sort = "import function";
            }
        }
    }
}