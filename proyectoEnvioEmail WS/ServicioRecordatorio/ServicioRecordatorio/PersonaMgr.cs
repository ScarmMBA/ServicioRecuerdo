using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace enviarMail
{

    public class PersonaMgr
    {

        public DataSet Listar()
        {
            obtenerTablas objExt = new obtenerTablas();
            DataSet Dtt;
            DataSet dt;

            Dtt = new DataSet();
            dt = objExt.Bases();
            string msge;


            foreach (DataRow ren in dt.Tables[0].Rows)
            {
                //SqlConnection cnn = new SqlConnection($"Data Source=148.234.13.218; Initial Catalog=CapacitacionVer3; Integrated Security=false; user id=usr_app_capv3; password=2UEzM*kVk9pHqA");
                SqlConnection cnn = new SqlConnection($"Data Source = 148.234.13.218; Initial Catalog = {ren["TABLE_CATALOG"]}; Integrated Security = True ");
                try
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM {ren["TABLE_NAME"]}", cnn);
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    SqlDataAdapter da = new SqlDataAdapter();

                    da.SelectCommand = cmd;

                    da.Fill(Dtt);

                }
                catch (Exception ex)
                {
                    msge = $"La tabla {ren["TABLE_NAME"]} es la responsable del fallo" + ex.Message;

                }
                finally
                {
                    cnn.Close();
                }


            }

            return Dtt;
        }

    }


}
