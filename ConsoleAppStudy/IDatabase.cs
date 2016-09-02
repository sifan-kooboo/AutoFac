using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleAppStudy
{
    public interface IDatabase
    {
        string Name { get; }

        string Select(string commandText);

        string Insert(string commandText);

        string Update(string commandText);

        string Delete(string commandText);
    }


}