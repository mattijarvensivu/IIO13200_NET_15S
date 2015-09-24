using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
     public static class DBDemoxOy
    {
      public  static DataTable GetDataSimple()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Firstname", typeof(string));
            dt.Columns.Add("Lastname", typeof(string));
            dt.Rows.Add("Kalle", " Isokalliio");
            dt.Rows.Add("Pekka", " Kuusisto");

            return dt;
        }

         public static DataTable GetDataReal()
        {
            string sql = "";
            sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot";
            string connStr = @"Data source=eight.labranet.jamk.fi;initial catalog=DemoxOy; user=koodari;password=koodari13";
            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    //avataan Yhteys
                    conn.Open();
                    //luodaan komento = command-olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "lasnaolot");

                        return ds.Tables["lasnaolot"];

                    }



                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
