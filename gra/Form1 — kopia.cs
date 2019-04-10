using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace gra{
    public partial class Form1 : Form
    {
        Bitmap gameView = null;
        public void DrawBMP(Bitmap BMP,Point where) {
            Point tmp = new Point(0, 0);
            while ((tmp.Y < BMP.Height)&&(where.Y + tmp.Y < gameView.Height))
            {
                while ((tmp.X < BMP.Width)&&(where.X+tmp.X<gameView.Width))
                {
                    Color pixel = BMP.GetPixel(tmp.X, tmp.Y);
                    if (pixel.R == 255 && pixel.G == 255 && pixel.B == 255) {
                    }else
                    {
                        gameView.SetPixel(where.X + tmp.X, where.Y + tmp.Y, pixel);
                    }
                    tmp.X++;
                }
                tmp.X = 0;
                tmp.Y++;
            }
        }
        public void DrawBegin() {
            Bitmap frog1 = new Bitmap(common.gamePath + "żaba1.jpg");
            Bitmap brick1 = new Bitmap(common.gamePath + "cegła1.jpg");
            Point center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            DrawBMP(frog1, new Point((center.X - frog1.Width / 2), (center.Y - frog1.Height)));
            DrawBMP(brick1, new Point((center.X - brick1.Width / 2), center.Y));
        }
        public void DrawSky(string fName) {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Bitmap sky = new Bitmap(common.gamePath + fName);
            Point tmp = new Point(0,0);
            while (tmp.Y < pictureBox1.Image.Height)
            {
                while (tmp.X < pictureBox1.Image.Width) {
                    DrawBMP(sky, new Point(tmp.X, tmp.Y));
                    tmp.X += sky.Width;
                }
                tmp.X = 0;
                tmp.Y += sky.Height;
            }
        }
        public Form1()
        {
            InitializeComponent();
            
            common.gamePath = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf('\\', Directory.GetCurrentDirectory().LastIndexOf('\\', Directory.GetCurrentDirectory().LastIndexOf('\\') - 1) - 1) + 1);
            pictureBox1.Image = gameView = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            DrawSky("niebo.jpg");
            DrawBegin();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rozpoczęcieToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void zakonczToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void wstzrymajToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void oGrzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Wyświetlono więści o grze...";
            AboutBox1 aboutGame = new AboutBox1();
            aboutGame.Show();
        }

        private void wyświetlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStripProgressBar1.Value = 950;
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void graToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ustawieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void przemyśleniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Wyświetlono zapiski o grze...";
            GameNote gameNote = new GameNote();
            gameNote.Show();
        }
    }
    public class window
    {
        public IntPtr handle;
        public String name;
        public String className;
        public List<window> childWindows = null;
    }
    public class common
    {
        public static string gamePath = "";
        public static string[] pathsToFiles(string rootPath, string fileName)
        {
            string[] filePaths = Directory.GetFiles(rootPath, fileName, SearchOption.AllDirectories);
            return filePaths;
        }
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
        public static List<window> allWindows()
        {
            List<window> windows = new List<window>();
            EnumWindows(EnumTheWindows, GCHandle.ToIntPtr(GCHandle.Alloc(windows)));
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
        [DllImport("User32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("gdi32.dll", EntryPoint = "BitBlt", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BitBlt([In] IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, [In] IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hwnd, out Rectangle lpRect);
        public static void WNDtoBMP(IntPtr hwnd, string fName)
        {
            IntPtr wndDC = GetDC(hwnd);
            Graphics g1 = Graphics.FromHdc(wndDC);
            Rectangle rect;
            GetWindowRect(hwnd, out rect);
            int x = rect.Width - rect.X, y = rect.Height - rect.Y;
            Image myImage = new Bitmap(x, y, g1);
            Graphics g2 = Graphics.FromImage(myImage);
            IntPtr dc1 = g1.GetHdc();
            IntPtr dc2 = g2.GetHdc();
            BitBlt(dc2, 0, 0, x, y, dc1, 0, 0, 13369376);
            g1.ReleaseHdc(dc1);
            g2.ReleaseHdc(dc2);
            myImage.Save(fName + ".bmp", ImageFormat.Bmp);
        }
        [DllImport("user32.dll", SetLastError = false)]
        static extern IntPtr GetDesktopWindow();
        public static void DesktopBMP(string fName)
        {
            WNDtoBMP(GetDesktopWindow(), fName);
        }
        public static bool IsAlreadyOpened(string wName)
        {

        }
    }
}
