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
using System.Diagnostics;
using dll;

namespace gra{
    public partial class Form1 : Form
    {
        Bitmap gameView = null;
        string bgImgPath;
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
            Bitmap leaf = new Bitmap(common.gamePath + "liść.jpg");
            Point center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            DrawBMP(frog1, new Point((center.X - frog1.Width / 2), (center.Y - frog1.Height)));
            DrawBMP(leaf, new Point((center.X - leaf.Width / 2), center.Y));
        }
        public void DrawSky(string fName) {
            Bitmap sky = new Bitmap(fName);
            Point tmp = new Point(0,0);
            while (tmp.Y < pictureBox1.Image.Height)
            {
                while (tmp.X < pictureBox1.Image.Width) {
                    DrawBMP(sky, tmp);
                    tmp.X += sky.Width;
                }
                tmp.X = 0;
                tmp.Y += sky.Height;
            }
        }
        public Form1()
        {
            if (common.isAlreadyOpened()) System.Environment.Exit(0);
            InitializeComponent();
            common.gamePath = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf('\\', Directory.GetCurrentDirectory().LastIndexOf('\\', Directory.GetCurrentDirectory().LastIndexOf('\\') - 1) - 1) + 1);
            pictureBox1.Image = gameView = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bgImgPath = common.gamePath + "staw.jpg";
            DrawSky(bgImgPath);
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
            System.Environment.Exit(0);
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
            toolStripStatusLabel1.Text = "Wyświetlono zapisy o grze...";
            GameNote gameNote = new GameNote();
            gameNote.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            common.WNDtoBMP(tableLayoutPanel1.Handle,common.gamePath+"windowShot.bmp");
            toolStripStatusLabel1.Text = "Zapisano zdjęcie okna w bieżącej teczce w pliku windowShot.bmp...";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            common.DesktopBMP(common.gamePath + "desktopShot.bmp");
            toolStripStatusLabel1.Text = "Zapisano zrzut ekranu w bieżącej teczce w pliku desktopShot.bmp...";
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

        private void barwyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = menuStrip1.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                menuStrip1.BackColor = colorDialog.Color;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "wszystkie (*.*)|*.*|jpeg (*.gif)|*.gif|png (*.png)|*.png|bmp (*.bmp)|*.bmp|jpeg (*.jpeg)|*.jpeg|jpg (*.jpg)|*.jpg";
            openFileDialog.FilterIndex = 1;
            openFileDialog.InitialDirectory = common.gamePath;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bgImgPath = openFileDialog.FileName;
                toolStripStatusLabel1.Text = "Udało ci się graczu zmienić tło gry...";
                DrawSky(bgImgPath);
                DrawBegin();
                pictureBox1.Refresh();
            }
        }

        private void nowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tym przyciskiem możesz wykonać zdjęcie widoku gry...";
            toolTip1.SetToolTip(button1, File.Exists(common.gamePath + "windowShot.bmp")?"Nadpiszesz plik "+ common.gamePath+"windowShot.bmp": "Wciśnij aby wykonać nowy plik windowShot.bmp w "+ common.gamePath.Remove(common.gamePath.ToString().LastIndexOf("\\"), 1));
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tym przyciskiem możesz wykonać zdjęcie całego ekranu...";
            toolTip1.SetToolTip(button2, File.Exists(common.gamePath + "desktopShot.bmp") ? "Nadpiszesz plik " + common.gamePath + "desktopShot.bmp" : "Wciśnij aby wykonać nowy plik desktopShot.bmp w " + common.gamePath.Remove(common.gamePath.ToString().LastIndexOf("\\"), 1));
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tym przyciskiem pobierzesz obecny czas...";
            toolTip1.SetToolTip(button3, "Będzie pobranie czasu ze strony https://www.timeanddate.com/worldclock/poland");
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tym przyciskiem zmienisz tło planszy...";
            toolTip1.SetToolTip(button4, "Zmienisz tło z obecnego "+ bgImgPath);
        }
        private void notifyIconMenuItem1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ContextMenu contextMenu1 = new ContextMenu();
            notifyIcon1.ContextMenu = contextMenu1;
            MenuItem menuItem1 = new MenuItem();
            menuItem1.Text = "W&yjdź";
            menuItem1.Click += new System.EventHandler(notifyIconMenuItem1_Click);
            contextMenu1.MenuItems.AddRange(new MenuItem[] { menuItem1 });
            notifyIcon1.ShowBalloonTip(1000);
        }

        private void bibliotekiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Wyświetlono załadowane biblioteki...";
            Biblioteki biblioteki = new Biblioteki();
            biblioteki.Show();
        }

        private void przemyśleniaToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tu redagujesz swoje myśli...";
        }

        private void bibliotekiToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tu wejrzysz w załadowane biblioteki...";
        }

        private void oGrzeToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tu dowiesz się więcej o grze...";
        }

        private void barwyToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tu zmienisz barwę menu...";
        }

        private void inneToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tu zmienisz tą czcionkę...";
        }

        private void wyświetlToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tu zajrzysz w pomoc...";
        }

        private void zakonczToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tu zakończysz grę...";
        }

        private void wczytajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void nowaToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tu rozpoczniesz wtórną rozgrywkę...";
        }

        private void zapiszToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tu zachowasz rozgrywkę...";
        }

        private void wczytajToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tu wczytasz rozgrywkę...";
        }

        private void pomocToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Wciśnij by uzyskać pomoc...";
        }

        private void ustawieniaToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Wciśnij by nastroić swojstwa...";
        }

        private void graToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Wciśnij by przełączyć grę...";
        }

        private void toolStripSplitButton1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Czekaj lub puść dążenia...";
        }

        private void odtwarzajToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Chcesz dalej się zabawiać...";
        }

        private void wstzrymajToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Chcesz przerwać zabawę...";
        }

        private void zrzutyToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tu zrobisz inny zrzut wciskając dwa razy w wybrane potem okno...";
        }

        private void zrzutyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Proszę robić sobie inny zrzut wciskając podwójnie wybrane okno...";
            zrzuty zrzutyOkno = new zrzuty();
            zrzutyOkno.Show();
        }

        private void sterownikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Wyświetlono dostępne sterowniki...";
            sterowniki sterownikiOkno = new sterowniki();
            sterownikiOkno.Show();
        }

        private void sterownikiToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tu podjerzysz obecne sterowniki...";
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
                System.Environment.Exit(0);
        }

        private void nieeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage()) { pictureBox1.Image = Clipboard.GetImage(); }
        }
        private void taakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(gameView);
        }

        private void minimalizujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void zarządcaZdjęćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zarzadca zarzadcaOkno = new zarzadca();
            zarzadcaOkno.Show();
        }

        private void minimalizujToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Zmniejsz okno na pasek zadań...";
        }

        private void toolStripProgressBar1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tak daleko zaszła gra...";
        }

        private void toolStripStatusLabel1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tu dostajesz powiadomienia...";
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Życzymy udanej i przyjemnej zabawy...";
        }

        private void flowLayoutPanel1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "W tej częsci są zgromadzone szybkie wywołania...";
        }

        private void zarządcaZdjęćToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Zachowaj prawym przyciskiem myszy zdjęcie z obszaru gry by tu je zachować...";
        }
    }

    public class common
    {
        public static string gamePath = "";
        public static string[] pathsToFiles(string rootPath, string fileName)
        {
            string[] filePaths = Directory.GetFiles(rootPath, fileName, SearchOption.AllDirectories);
            return filePaths;
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
            myImage.Save(fName, ImageFormat.Bmp);
        }
        [DllImport("user32.dll", SetLastError = false)]
        static extern IntPtr GetDesktopWindow();
        public static void DesktopBMP(string fName)
        {
            WNDtoBMP(GetDesktopWindow(), fName);
        }
        public static string getWebPage(string from)
        {
            var request = (HttpWebRequest)WebRequest.Create(from);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }
        public static bool isAlreadyOpened()
        {
            Process[] processTable = Process.GetProcesses();
            Process current = Process.GetCurrentProcess();
            bool alreadyOpened = false;
            foreach (Process pr in processTable)
            {
                try
                {
                    if (pr.MainModule.FileName == current.MainModule.FileName && pr.Id != current.Id) alreadyOpened = true;
                }
                catch (Exception ex)
                {
                }
            }
            return alreadyOpened;
        }
    }
}
