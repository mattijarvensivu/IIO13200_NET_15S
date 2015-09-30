using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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

         public static DataTable GetDataReal(string nimi)
        {
            

            
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            try
            {

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();
                
                    using (SqlCommand command = new SqlCommand(
                    "SELECT asioid, lastname, firstname, date FROM lasnaolot WHERE firstname = @nimi", connection))
                    {
                       
                        command.Parameters.AddWithValue("@nimi", nimi);
                       
                        SqlDataAdapter da = new SqlDataAdapter(command);
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
