using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net.Http.Headers;

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

        private void button1_Click(object sender, EventArgs e)
        {
            common.WNDtoBMP(tableLayoutPanel1.Handle,"windowShot");
            toolStripStatusLabel1.Text = "Zapisano zdjęcie okna w bieżącej teczce w pliku windowShot.bmp...";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "zrzuty ekranu (*.bmp)|*.bmp|dowolne pliki (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                common.DesktopBMP(saveFileDialog.FileName);
                toolStripStatusLabel1.Text = "Zapisano zrzut ekranu w pliku "+saveFileDialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string result = common.getWebPage("https://www.timeanddate.com/worldclock/poland");
            Match matchTime = Regex.Match(result, @"\s+id=ct(\s+)*(\w|=)*>(?<time>[^<]+)");
            Match matchDate = Regex.Match(result, @"\s+id=ctdat(\s+)*(\w|=)*>(?<date>[^<]+)");
            if (matchTime.Success && matchDate.Success)toolStripStatusLabel1.Text = "Dzisiaj mamy godzinę "+ matchTime.Groups["time"].Value+" w dniu "+ matchDate.Groups["date"].Value;
        }

        private void inneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            fontDialog.Color= toolStripStatusLabel1.ForeColor;
            fontDialog.Font = toolStripStatusLabel1.Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                toolStripStatusLabel1.Font= fontDialog.Font;
                toolStripStatusLabel1.ForeColor=fontDialog.Color;
                toolStripStatusLabel1.Text = "Zmiana czcionki tego paska powiadomień przebiegła pomyślnie...";
            }
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
            List<window> windows = common.allWindows();
            foreach (window Window in windows)
            {
                if (Window.name == wName) {
                    answer = true;
                    break;
                };
            }
            destroyAllWindows(windows);
            return answer;
        }
        public static string getWebPage(string from)
        {
            var request = (HttpWebRequest)WebRequest.Create(from);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }
    }
}
