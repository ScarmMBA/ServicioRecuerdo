using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ServicioRecordatorio
{
    public class PersonaMgr
    {
        //List<string> bd = new List<string> {"pruebaJob", "pruebas", "prueba2" };
        //string[] bd = new string[] {"pruebaJob", "pruebas", "prueba2" };
        SqlConnection conn = new SqlConnection("Data Source = 148.234.13.218; Initial Catalog = PruebasSoporteDesarrollo; Integrated Security = True ");
        DataTable Dtt;

        public DataTable Listar()
        {
             Dtt = new DataTable();

           // foreach(string item in bd)
            //{   
                //SqlConnection conn = new SqlConnection("Data Source = 148.234.13.218; Initial Catalog = PruebasSoporteDesarrollo; Integrated Security = True ");
                try
                {
                    
                    SqlCommand cmd = new SqlCommand($"SELECT id, nombre, apellido, email, envioEmail FROM pruebaJob", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter();

                    da.SelectCommand = cmd;

                    da.Fill(Dtt);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
                return Dtt;
            //}

            //return Dtt;
        }

    }
}
