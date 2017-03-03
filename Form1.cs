using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace basichack
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        Boolean fatigue = false;
        Boolean recoil = false;
        Boolean grass = false;
        Boolean nvg = false;
        Boolean thermal = false;

        Manager manager = new Manager();

        private enum KeyStates
        {
            None = 0,
            Down = 1,
            Toggled = 2
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int keyCode);

        private static KeyStates GetKeyState(Keys key)
        {
            KeyStates state = KeyStates.None;

            short retVal = GetKeyState((int)key);

            if ((retVal & 0x8000) == 0x8000)
                state |= KeyStates.Down;
            if ((retVal & 1) == 1)
                state |= KeyStates.Toggled;

            return state;
        }

        public static bool IsKeyDown(Keys key)
        {
            return KeyStates.Down == (GetKeyState(key) & KeyStates.Down);
        }

        public Form1()
        {
            InitializeComponent();
            manager.managerStartProcess();
            this.Paint += new PaintEventHandler(mapData.refreshMap);

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 100;
            _timer.Tick += new EventHandler(timer_Tick);
            _timer.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //change title
            this.Text = RandomString(random.Next(20) + 20);

            Thread t = new Thread(new ThreadStart(_keyR));
            t.IsBackground = true;
            t.Start();
        }


        //just random strings
        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }


        //Triggers
        private void checkUstalost_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUstalost.Checked)
            {
                fatigue = true;
                Thread t = new Thread(new ThreadStart(_fatigue));
                t.IsBackground = true;
                t.Start();
            }
            else
            {
                fatigue = false;
            }
        }

        private void checkNvg_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNvg.Checked)
            {
                nvg = true;
                Thread t = new Thread(new ThreadStart(_nvg));
                t.IsBackground = true;
                t.Start();
            }
            else
            {
                nvg = false;
            }
        }

        private void checkThermal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkThermal.Checked)
            {
                thermal = true;
                Thread t = new Thread(new ThreadStart(_thermal));
                t.IsBackground = true;
                t.Start();
            }
            else
            {
                thermal = false;
            }
        }

        private void checkOtdacha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkOtdacha.Checked)
            {
                recoil = true;
                Thread t = new Thread(new ThreadStart(_recoil));
                t.IsBackground = true;
                t.Start();
            }
            else
            {
                recoil = false;
            }
        }

        private void checkTrava_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTrava.Checked)
            {
                grass = true;
                Thread t = new Thread(new ThreadStart(_grass));
                t.IsBackground = true;
                t.Start();
            }
            else
            {
                grass = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manager.setRepair();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            manager.setRefuel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            manager.setVision(Convert.ToInt32(viewDist.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            manager.setAmmo();
        }

        //Threads
        private void _keyR()
        {
            while (true)
            {
                if (IsKeyDown(Keys.R))
                {
                    manager.setAmmo();
                }
                Thread.Sleep(500);
            }
        }

        private void _fatigue()
        {
            while (fatigue)
            {
                manager.setFatigue();
                Thread.Sleep(500);
            }
        }        
        private void _recoil()
        {
            while (recoil)
            {
                manager.setRecoil();
                Thread.Sleep(500);
            }
        }
        private void _nvg()
        {
            while (nvg)
            {
                manager.setNvg();
                Thread.Sleep(500);
            }
        }
        private void _grass()
        {
            while (grass)
            {
                manager.setGrass();
                Thread.Sleep(500);
            }
        }
        private void _thermal()
        {
            while (thermal)
            {
                manager.setThermal();
                Thread.Sleep(500);
            }
        }
        Manager mapData = new Manager();
        private int _countDown = 100; //ms
        private System.Windows.Forms.Timer _timer;

        /*public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(mapData.refreshMap);
            
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 100;
            _timer.Tick += new EventHandler(timer_Tick);
            _timer.Stop();
        }*/

        private void refTick_CheckedChanged(object sender, EventArgs e)
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
            }
            else
            {
                _timer.Start();
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            _countDown -= 100;
            if (_countDown < 0)
            {
                _countDown = Convert.ToInt32(refTimer.Text);
                mapTimer();
            }
        }

        private void mapTimer()
        {
            this.Invalidate();
        }
       
    }
}