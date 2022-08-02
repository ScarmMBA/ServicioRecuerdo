using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;


namespace enviarMail
{
    public class obtenerTablas
    {
        public DataSet Bases()
        {

            DataSet ds;
            ds = new DataSet();
            List<string> BD = new List<string> { "PruebasSoporteDesarrollo", "CapacitacionVer2", "CapacitacionVer3" };
            foreach (var item in BD)
            {

                //SqlConnection conn = new SqlConnection($"Data Source = 148.234.13.218; Initial Catalog=CapacitacionVer3; Integrated Security=false; user id=usr_app_capv3; password=2UEzM*kVk9pHqA");
                SqlConnection conn = new SqlConnection($"Data Source = 148.234.13.218; Initial Catalog = {item}; Integrated Security = true");

                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter();

                    da.SelectCommand = cmd;

                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {

                    conn.Close();
                }


            }

            return ds;
        }


    }
}
