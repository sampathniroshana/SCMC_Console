using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.IO;
using System.Net.Configuration;
using System.Net;
using System.Data;



namespace EmailCommunicator
{
    class EmailSender
    {
        //Referance for data access
        Dao dataAccess;
        public void ComposeDefaultEmail()
        {

            try
                {
                    
                     DataTable dt;
                     dataAccess = new Dao();
                     dt = dataAccess.GetMailDetailsToReply();

                if (dt.Rows.Count >0)
                {
                   foreach(DataRow row in dt.Rows)
                        {
                            Console.WriteLine(row["Sender"].ToString());
                            MailMessage(row["Sender"].ToString(), "Automatic Reply", "Thank you for contacting ABC costomer care. We will address your matter soon");
                            dataAccess.UpdateStatusOfInitialMail(Convert.ToInt16(row["ID"].ToString()));
                            Console.WriteLine("Mail receiving complated and saved to the DB");
                        }
                }
                     
                     
               
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
        }

        
        //To create mail meaasge 
        public void MailMessage( String toAddr,String subject,string body)
        {
            try
            {
                Console.WriteLine("Mail sending started.......... ");
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("scms.icbt@gmail.com");
                msg.To.Add(toAddr);
                msg.Subject = "subject";
                msg.IsBodyHtml = true;
                msg.BodyEncoding = Encoding.ASCII;
                msg.Body = body;
                sendMail(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
           
            
            
        }


        // TO send email message via SMTP protocol
        public static void  sendMail(MailMessage msg)
        {
            string username = "scms.icbt@gmail.com";  
            string password = "Dal%painto13";  //password
            SmtpClient mClient = new SmtpClient();
            mClient.Host = "smtp.gmail.com";
            mClient.Port = 587;
            mClient.EnableSsl = true;
            mClient.Credentials = new NetworkCredential(username, password);
            mClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            mClient.Timeout = 100000;
            mClient.Send(msg);
            Console.WriteLine("mail message sent ");
        }
    }
}
