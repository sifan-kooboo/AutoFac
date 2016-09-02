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
    public partial class baseForm : Form
    {
        public Test test;
        public baseForm()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Test>();
            _container = builder.Build();

            injectSomething();
            InitializeComponent();
        }

        public Autofac.IContainer _container;

        public virtual void injectSomething()
        {
            test = _container.Resolve<Test>();
        }
    }
}
