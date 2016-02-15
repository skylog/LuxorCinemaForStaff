using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Random _rnd = new Random();
        private string GetRandomNumber(int i)
        {
            return string.Format("{0}:{1}", i, _rnd.Next(100));
        }

        private async Task DoStuff(SynchronizationContext _sync, ListBox box)
        {
            await Task.Factory.StartNew((b) =>
            {
                for (int i = 0; i < 100; i++)
                {
                    _sync.Send((a) =>
                    {
                        (b as ListBox).Items.Add(a);
                    }, GetRandomNumber(i));

                    Thread.Sleep(100);
                }
            }, box);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            try
            {
                await DoStuff(SynchronizationContext.Current, listBox1);
            }
            finally
            {
                button1.Enabled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
