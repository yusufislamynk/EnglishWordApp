using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishProject
{
    public class Connect
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=YUSUFISLAMYANıK\SQLEXPRESS;Initial Catalog=EnglishProject;Integrated Security=True;Connect Timeout=30;");
    }
}
