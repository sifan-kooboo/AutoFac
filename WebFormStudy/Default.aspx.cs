using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormStudy
{
    public partial class _Default : Page
    {

        public DatabaseManager dm { get; set; }
        public Test test { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(dm.Search("select * from Test"+test.Name));
        }
    }
}