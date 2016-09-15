using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace equipment_search
{
    class db
    {
        public static SqlConnection Camcon()
        {
            return new SqlConnection("Data Source=wangyin.mynetgear.com,25601;Initial Catalog=test;User ID=sa;Password=118652zz?");
        }
    }
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}
