using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace otp
{
    public struct Vector2
    {
        public int x;
        public int y;
    }
    public struct MOUSEINFO
    {
        public Vector2 pos;
        public uint data;
        public uint flags;
        public uint time;
        public IntPtr extra;
    }

    public partial class Form1 : Form
    {
        uint pow(uint a, uint b)
        {
            uint ret = 1;

            for (int i = 0; i < b; i++)
            {
                ret *= a;
            }

            return ret;
        }

        bool generating = false;
        bool halt = false;

        int rate = 1;
        uint[] dim = { 0, 0, 0 };
        List<uint> vals = new List<uint>();

        public delegate IntPtr HookCallbackDelegate(int nCode, IntPtr wParam, IntPtr lParam);

        const int MOUSEEVENTF_LEFTDOWN = 0x02;
        const int MOUSEEVENTF_LEFTUP = 0x04;
        const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        const int MOUSEEVENTF_RIGHTUP = 0x10;
        [DllImport("user32.dll", SetLastError = true)]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookCallbackDelegate lpfn, IntPtr wParam, uint lParam);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        const int WH_KEYBOARD_LL = 13;
        const int WH_MOUSE_LL = 14;
        const int WM_KEYDOWN = 0x0100;
        const int WM_KEYUP = 0x0101;
        const int WM_ALTKEYDOWN = 0x0104;
        const int WM_ALTKEYUP = 0x0105;
        const int WM_MOUSEMOVE = 0x0200;
        const int WM_LBUTTONDOWN = 0x0201;
        const int WM_LBUTTONUP = 0x0202;
        const int WM_MOUSEWHEEL = 0x020A;
        const int WM_RBUTTONDOWN = 0x0204;
        const int WM_RBUTTONUP = 0x0205;
        const int WM_LBUTTONDBLCLK = 0x0203;
        const int WM_MBUTTONDOWN = 0x0207;
        const int WM_MBUTTONUP = 0x020;

        HookCallbackDelegate mhcDelegate;
        IntPtr whllmousehook;

        IntPtr mhandler(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (wParam == (IntPtr)WM_MOUSEMOVE && !halt)
            {
                MOUSEINFO info = (MOUSEINFO)Marshal.PtrToStructure(lParam, typeof(MOUSEINFO));

                HashAlgorithm algo = MD5.Create();
                byte[] data = algo.ComputeHash(Encoding.UTF8.GetBytes(
                    info.pos.x.ToString() + info.pos.y.ToString() + DateTime.Now.Ticks.ToString()
                ));

                for (int i = 0; i < rate; i++)
                {
                    vals.Add(BitConverter.ToUInt32(data, i*4) % pow(10, dim[2]));
                }
                start.Text = "Move your mouse\r\n" + (vals.Count * 100 / (dim[0] * dim[1])) + "%";

                if (vals.Count >= dim[0] * dim[1])
                {
                    halt = true;
                    endgen();
                    endListening();
                }
            }

            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        public void startListening()
        {
            mhcDelegate = mhandler;

            string mainModuleName = Process.GetCurrentProcess().MainModule.ModuleName;
            whllmousehook = SetWindowsHookEx(WH_MOUSE_LL, mhcDelegate, GetModuleHandle(mainModuleName), 0);
        }
        public void endListening()
        {
            UnhookWindowsHookEx(whllmousehook);
            mhcDelegate = null;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            if (generating)
                return;
            generating = true;

            start.Text = "Move your mouse";

            dim = dimension.Text.Split('x').Select((x) => uint.Parse(x)).ToArray();
            rate = int.Parse(valuesps.Text.Split(' ')[0]);

            startListening();
        }

        private void endgen()
        {
            start.Text = "Go";

            content.Text = "";
            for (int i = 0; i < dim[1]; i++)
            {
                string build = "";

                for (int j = 0; j < dim[0]; j++)
                {
                    build += vals[i * Convert.ToInt32(dim[0]) + j].ToString("D" + dim[2].ToString());

                    if (j != dim[0] - 1)
                        build += " ";
                }

                if (i != dim[1] - 1)
                    build += "\r\n";

                content.Text += build;
            }

            vals.Clear();

            generating = false;
            halt = false;
        }
    }
}
