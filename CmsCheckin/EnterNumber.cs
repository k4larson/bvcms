using System;
using System.Windows.Forms;

namespace CmsCheckin
{
    public partial class EnterNumber : UserControl
    {
        public event EventHandler GoNext;
        public event EventHandler GoBack;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Tab:
                        Program.TimerStop();
                        GoNext(this, new EventArgs());
                        return true;
                    case Keys.Shift | Keys.Tab:
                        Program.TimerStop();
                        GoBack(this, new EventArgs());
                        return true;
                    case Keys.S | Keys.Alt:
                        Program.TimerReset();
                        Program.CursorShow();
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public EnterNumber(string title)
        {
            InitializeComponent();
            label2.Text = title;
        }
        public void SetBackNext(UserControl c1, UserControl c2)
        {
            this.c1 = c1;
            this.c2 = c2;
            if (c1 != null)
                GoBack += new EventHandler(EnterPhone_GoBack);
            if (c2 != null)
                GoNext += new EventHandler(EnterPhone_GoNext);
        }
        private UserControl c1, c2;
        void EnterPhone_GoBack(object sender, EventArgs e)
        {
            this.Swap(c1);
        }
        void EnterPhone_GoNext(object sender, EventArgs e)
        {
            this.Swap(c2);
        }
        void buttonclick(object sender, EventArgs e)
        {
            Program.TimerStop();
            var b = sender as Button;
            var d = b.Name[6];
            KeyStroke(d);
        }

        private void Date_Load(object sender, EventArgs e)
        {
            button1.Click += new EventHandler(buttonclick);
            button2.Click += new EventHandler(buttonclick);
            button3.Click += new EventHandler(buttonclick);
            button4.Click += new EventHandler(buttonclick);
            button5.Click += new EventHandler(buttonclick);
            button6.Click += new EventHandler(buttonclick);
            button7.Click += new EventHandler(buttonclick);
            button8.Click += new EventHandler(buttonclick);
            button9.Click += new EventHandler(buttonclick);
            button0.Click += new EventHandler(buttonclick);
            textBox1.Focus();
            textBox1.Select(textBox1.Text.Length, 0);
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            Program.TimerStop();
            Util.UnLockFamily();
            Program.ClearFields();
            this.GoHome("");
        }

        private void buttongo_Click(object sender, EventArgs e)
        {
            GoNext(sender, e);
        }

        private void buttonbs_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            BackSpace();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                Program.TimerStop();
                GoBack(sender, e);
            }
            else if (e.KeyChar == '\b')
                BackSpace();
            else if(e.KeyChar == '\r')
            {
                Program.TimerStop();
                GoNext(sender, e);
            }
            else 
                KeyStroke(e.KeyChar);
            Program.TimerReset();
            e.Handled = true;
        }
        private void KeyStroke(char d)
        {
            var t = textBox1.Text;
            t += d;
            textBox1.Text = t;
            textBox1.Focus();
            textBox1.Select(textBox1.Text.Length, 0);
        }
        private void BackSpace()
        {
            var t = textBox1.Text;
            var len = t.Length - 1;
            if (len < 0)
                len = 0;
            textBox1.Text = t.Substring(0, len);
            textBox1.Focus();
            textBox1.Select(textBox1.Text.Length, 0);
        }

        private void button_goback_Click(object sender, EventArgs e)
        {
            Program.TimerStop();
            GoBack(sender, e);
        }
        private void EnterText_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible == true)
            {
                Program.TimerStart(timer1_Tick);
                textBox1.Focus();
                textBox1.Select(textBox1.Text.Length, 0);
            }
        }

        private void bminus_Click(object sender, EventArgs e)
        {
            Program.TimerStop();
            KeyStroke('-');
        }

        private void bdot_Click(object sender, EventArgs e)
        {
            Program.TimerStop();
            KeyStroke('.');
        }

    }
}
