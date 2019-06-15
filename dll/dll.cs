using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;

namespace dll
{

    public class window
    {
        public IntPtr handle;
        public String name;
        public String className;
        public List<window> childWindows = null;
        void sth() { }
    }
    public static class dll
    {
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
        [DllImport("User32.Dll")]
        private static extern void GetClassName(int hWnd, StringBuilder s, int nMaxCount);
        private static string _GetClassName(IntPtr hWnd)
        {
            StringBuilder sbClass = new StringBuilder(256);
            GetClassName((int)hWnd, sbClass, sbClass.Capacity);
            return sbClass.ToString();
        }
        private static bool EnumTheWindows(IntPtr hWnd, IntPtr listHandle)
        {
            List<window> windows = GCHandle.FromIntPtr(listHandle).Target as List<window>;
            int size = GetWindowTextLength(hWnd);
            if (size++ > 0 && IsWindowVisible(hWnd))
            {
                StringBuilder sb = new StringBuilder(size);
                GetWindowText(hWnd, sb, size);
                window Window = new window { handle = hWnd, name = sb.ToString(), className = _GetClassName(hWnd) };
                windows.Add(Window);
                IntPtr childWindow = GetWindow(hWnd, 5);//GW_CHILD = 5
                if (childWindow != null && IsWindowVisible(childWindow))
                {
                    Window.childWindows = new List<window>();
                    EnumChildWindows(hWnd, EnumTheWindows, GCHandle.ToIntPtr(GCHandle.Alloc(Window.childWindows)));
                };
            }
            return true;
        }
        private static bool EnumTheWindowsHiddenNoName(IntPtr hWnd, IntPtr listHandle)
        {
            List<window> windows = GCHandle.FromIntPtr(listHandle).Target as List<window>;
            int size = GetWindowTextLength(hWnd);
            if (size > 0 && IsWindowVisible(hWnd))
            {
                size++;
                StringBuilder sb = new StringBuilder(size);
                GetWindowText(hWnd, sb, size);
                window Window = new window { handle = hWnd, name = sb.ToString(), className = _GetClassName(hWnd) };
                windows.Add(Window);
                IntPtr childWindow = GetWindow(hWnd, 5);//GW_CHILD = 5
                if (childWindow != null && IsWindowVisible(childWindow))
                {
                    Window.childWindows = new List<window>();
                    EnumChildWindows(hWnd, EnumTheWindows, GCHandle.ToIntPtr(GCHandle.Alloc(Window.childWindows)));
                };
            }
            else
            {
                string windowName = "";
                if (!IsWindowVisible(hWnd)) windowName += "?";
                if (size == 0)
                {
                    windowName += "!";
                }
                else
                {
                    size++;
                    StringBuilder sb = new StringBuilder(size);
                    GetWindowText(hWnd, sb, size);
                    windowName += sb.ToString();
                }
                window Window = new window { handle = hWnd, name = windowName, className = _GetClassName(hWnd) };
                windows.Add(Window);
                IntPtr childWindow = GetWindow(hWnd, 5);//GW_CHILD = 5
                if (childWindow != null && IsWindowVisible(childWindow))
                {
                    Window.childWindows = new List<window>();
                    EnumChildWindows(hWnd, EnumTheWindows, GCHandle.ToIntPtr(GCHandle.Alloc(Window.childWindows)));
                };
            }
            return true;
        }
        public static List<window> allWindows()
        {
            List<window> windows = new List<window>();
            EnumWindows(EnumTheWindows, GCHandle.ToIntPtr(GCHandle.Alloc(windows)));
            return windows;
        }
        public static List<window> allWindowsHiddenNoName()
        {
            List<window> windows = new List<window>();
            EnumWindows(EnumTheWindowsHiddenNoName, GCHandle.ToIntPtr(GCHandle.Alloc(windows)));
            return windows;
        }
        public static string windowsToString(List<window> windows, int progress)
        {
            string allWindows = "";
            foreach (window Window in windows)
            {
                for (int i = 0; i < progress; i++) allWindows += "  ";
                allWindows += Window.name + "     " + Window.className + "\n";
                if (Window.childWindows != null) allWindows += windowsToString(Window.childWindows, progress + 1);
            }
            return allWindows;
        }
        public static void destroyAllWindows(List<window> windows)
        {
            foreach (window Window in windows)
            {
                if (Window.childWindows != null)
                {
                    destroyAllWindows(Window.childWindows);
                };
            }
            windows.Clear();
        }
        public static bool IsWindowAlreadyOpened(string wName)
        {
            bool answer = false;
            List<window> windows = dll.allWindows();
            foreach (window Window in windows)
            {
                if (Window.name == wName)
                {
                    answer = true;
                    break;
                };
            }
            destroyAllWindows(windows);
            return answer;
        }
    }
}
