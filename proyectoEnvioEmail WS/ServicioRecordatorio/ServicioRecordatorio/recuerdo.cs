using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;   // 1 día = 86400000 seg
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Timers;
using enviarMail;

namespace ServicioRecordatorio
{
    public partial class recuerdo : ServiceBase
    {
        public recuerdo()
        {
            InitializeComponent();

        }

        protected override void OnStart(string[] args)
        {
            tiempo.Start();
        }

        protected override void OnStop()
        {
            tiempo.Stop();
        }

        public void tiempo_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            string hra = DateTime.Now.ToShortTimeString();
            string comparar = "04:26 p. m.";

            if (hra == comparar)
            {
                logic objLogic = new logic();
                PersonaMgr objPerMgr = new PersonaMgr();

                DataSet Dtt = new DataSet();

                Dtt = objPerMgr.Listar();


                if (Dtt.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow ren in Dtt.Tables[0].Rows)
                    {
                        string fRecuerdo = ren["fRecuerdo"].ToString();

                        if (fRecuerdo == "")
                        {

                        }
                        else
                        {

                            DateTime Recuerdo = DateTime.Parse(fRecuerdo);

                            Recuerdo = Recuerdo.AddDays(-1);

                            string hoy = DateTime.Now.ToShortDateString();

                            if (Recuerdo.ToString("dd/MM/yyyy") == hoy)
                            {
                                string body = @"<style>" +
                                                                "h1{color:dodgerblue;}" +
                                                                "h2{color:darkorange;}" +
                                                                "h3{color: green;}" +
                                                                "</style>" +
                                                                "<h1> Hola :D</h1></br>" +
                                                               "<p> Esto es correo de prueba solamente </p> </br>" +
                                                                "<h2>Se selecciono para averiguar como funciona este servicio</h2>" +
                                                                "<p>Ademas de como funcionan los DataSets</p>" +
                                                                "<h3>Favor de ignorar estos mensajes que son prueba para este sistema</h3>" +
                                                                "<h4>Este mensaje se envia automaticamente, no responder</h4>";

                                objLogic.sendMail(ren["email"].ToString(), "Correo de prueba.", body);



                                //   Console.WriteLine("Fila--->"+i);
                                //  Console.WriteLine(ren["nombre"].ToString());
                                //   Console.WriteLine(ren["apellido"].ToString());
                                //   Console.WriteLine(ren["email"].ToString());
                                //   Console.WriteLine(ren["fCreacion"].ToString());


                            }
                        }






                    }
                }

            }



        } 
       
    }
}
