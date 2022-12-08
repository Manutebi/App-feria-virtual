using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;



namespace maipoGrandeDatos
{
    class Notificación
    {
        static void Main(string[] args)
        {
            try 
            {
                using (MailMessage mailMessage = new MailMessage())
                {

                    //destinatario
                    mailMessage.To.Add("manux518@gmail.com");

                    //asunto
                    mailMessage.Subject = "prueba";

                    //body
                    mailMessage.Body = "Se envio vien lka wea xuxteumare.";
                    mailMessage.IsBodyHtml = false;

                    //remitente
                    mailMessage.From = new MailAddress("manux518@gmail.com", "Manu");

                    using (SmtpClient client = new SmtpClient())
                    {
                        //contrasenas
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("manux518@gmail.com", "manuelesteban");
                        client.Port = 587;
                        client.EnableSsl = true;

                        //host
                        client.Host = "stmp.gmail.com";
                        client.Send(mailMessage);

                    }

                }


            }
            catch (Exception) 
            {
                throw;
            }

        }
    }
}
