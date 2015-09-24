using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOdatareader
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetData_DataReader();
            GetData_Datatable();
           
        }

        static void GetData_Datatable()
        {
            //Ui kerron datan esittämistä varter
            try
            {

                //haetaan datatablen avulla
                DataTable dt = GetDataReal();
                string rivi = "";
                //Loopitetaan datatablen rivit läpi
                foreach(DataRow dr in dt.Rows)
                {
                    rivi = "";
                    foreach (DataColumn dc in dt.Columns)
                    {
                        rivi += dr[dc].ToString(); 

                    }
                    Console.WriteLine(rivi);
                }
                
           
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }


        static DataTable GetDataSimple()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Firstname", typeof(string));
            dt.Columns.Add("Lastname", typeof(string));
            dt.Rows.Add("Kalle", " Isokalliio");
            dt.Rows.Add("Pekka", " Kuusisto");

            return dt;
        }

        static DataTable GetDataReal()
        {
            string sql = "";
            sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot WHERE asioid= 'H4102'";
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
        static void GetData_DataReader()
                {

            

            try {
                string sql ="";
                sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot WHERE asioid= 'H4102'";
                string connStr = @"Data source=eight.labranet.jamk.fi;initial catalog=DemoxOy; user=koodari;password=koodari13";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    //avataan Yhteys
                    conn.Open();
                    //luodaan komento = command-olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetDateTime(3));
                                }
                            }
                            else
                          {
                                Console.WriteLine("Tietueita ei ole olemassa");
                          }
                            //suljetaan reader
                            rdr.Close();
                        }

                    }
                    //Suljetaan tietokantayhteys
                    conn.Close();
                    Console.WriteLine("Tietokantayhteys Suljettu onnistuneesti");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
    }
}
