using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.IService;

namespace WebApplication1.Service
{
    public class Test:ICommon
    {
        public List<string> GetName()
        {
            return "aa|bb|cc|dd|ee".Split('|').ToList();
        }
    }
}