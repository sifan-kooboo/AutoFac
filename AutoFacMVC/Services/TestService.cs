using AutoFacMVC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFacMVC.Services
{
    public class TestService : ITestService
    {

        public virtual List<string> GetNames()
        {
            List<string> retValue = new List<string>();
            return   retValue = new List<string>("aaaa|bbbb|cccc|dddd|asdfasdf|etgar|ewer".Split('|'));   
        }
    }
}