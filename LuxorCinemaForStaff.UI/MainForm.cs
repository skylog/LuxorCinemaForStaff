using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuxorCinemaForStaff.UI
{
    public interface IMainForm
    {
        string Content { get; set; }
        event EventHandler StartClick;
    }

    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
           // butStart_Click.Click += new EventHandler(StartClick);
        }

        private void butStart_Click(object sender, EventArgs e)
        {
            if (StartClick != null) StartClick(this, EventArgs.Empty);
        }

        public string Content
        {
            get { return dataGridView1.Rows.ToString(); }
            set { dataGridView1.Rows.Add(value); }
        }

        public event EventHandler StartClick;
       
    }
}
