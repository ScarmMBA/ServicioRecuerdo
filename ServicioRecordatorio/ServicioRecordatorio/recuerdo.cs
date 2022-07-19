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
            string comparar = "12:59 p. m.";
            
            if(hra == comparar)
            {
                logic objLogic = new logic();
                PersonaMgr objPerMgr = new PersonaMgr();

                DataTable Dtt = new DataTable();

                Dtt = objPerMgr.Listar();

                if (Dtt.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow ren in Dtt.Rows)
                    {

                        string x = ren["envioEmail"].ToString();
                        int nuevx = Int16.Parse(x);
                        Console.WriteLine(nuevx);

                        if (nuevx == 0)
                        {
                            string body = @"<style>" +
                                            "h1{color:dodgerblue;}" +
                                            "h2{color:darkorange;}" +
                                            "h3{color: green;}" +
                                            "</style>" +
                                            "<h1> Hola " + ren["nombre"].ToString() + " " + ren["apellido"].ToString() + " :D</h1></br>" +
                                           "<p> Esto es correo de prueba solamente </p> </br>" +
                                            "<h2>Ustedes han sido seleccionados para esta prueba</h2>" +
                                            "<p>Debería revisar mas a fondo el como mejorar esto</p>" +
                                            "<h3>Favor de ignorar estos mensajes que son prueba para este sistema</h3>" +
                                            "<h4>Este mensaje se envia automaticamente, no responder</h4>";

                            objLogic.sendMail(ren["email"].ToString(), "Correo de prueba.", body);



                            //   Console.WriteLine("Fila--->"+i);
                            //  Console.WriteLine(ren["nombre"].ToString());
                            //   Console.WriteLine(ren["apellido"].ToString());
                            //   Console.WriteLine(ren["email"].ToString());
                            //   Console.WriteLine(ren["fCreacion"].ToString());






                            i++;

                        }


                        i++;


                    }
                }

            }
            

            
            
        } 
       
    }
}
