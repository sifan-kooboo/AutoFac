using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace ConsoleAppStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DatabaseManager>();

            builder.RegisterType<SqlDatabase>().As<IDatabase>();
            //builder.RegisterType<OracleDatabase>().As<IDatabase>();
            var  _container = builder.Build();


            var dm = _container.Resolve<DatabaseManager>();
          
            Console.WriteLine(dm.Add("insert into ……"));
        }
    }
}
