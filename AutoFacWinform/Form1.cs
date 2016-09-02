using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;

namespace AutoFacWinform
{
    public partial class Form1 : baseForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        public override void injectSomething()
        {
            base.injectSomething();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = test.Name;
        }
    }
}
