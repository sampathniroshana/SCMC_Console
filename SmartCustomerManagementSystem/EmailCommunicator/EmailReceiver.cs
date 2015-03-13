using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EAGetMail;

namespace EmailCommunicator
{
    class EmailReceiver
    {
        Dao dataAccess;
        public void ReceiveMails()
        {

            // Create a folder named "inbox" under current directory
            // to save the email retrieved.
            Console.WriteLine("Receiving Started");
            string curpath = "C:\\";
            string mailbox = String.Format("{0}\\inbox", curpath);

           
            if (!Directory.Exists(mailbox))
            {
                Directory.CreateDirectory(mailbox);
            }

            MailServer oServer = new MailServer("pop.gmail.com",
                        "scms.icbt@gmail.com", "Dal%painto13", ServerProtocol.Pop3);
            MailClient oClient = new MailClient("TryIt");

           
           
            oServer.SSLConnection = true;
            oServer.Port = 995;

            try
            {
                oClient.Connect(oServer);
                MailInfo[] infos = oClient.GetMailInfos();
                for (int i = 0; i < infos.Length; i++)
                {
                    MailInfo info = infos[i];
                    Console.WriteLine("Index: {0}; Size: {1}; UIDL: {2}",
                        info.Index, info.Size, info.UIDL);

                    // Receive email from POP3 server
                    Mail oMail = oClient.GetMail(info);

                    Console.WriteLine("From: {0}", oMail.From.Address.ToString());
                    Console.WriteLine("Subject: {0}\r\n", oMail.Subject);

                    //save mail to DB
                     dataAccess = new Dao();
                     dataAccess.SaveMail(oMail.From.Address.ToString(), oMail.Subject.ToString(), oMail.TextBody.ToString());
                     Console.WriteLine("Mail receiving complated and saved to the DB");

                    // Generate an email file name based on date time.
                    System.DateTime d = System.DateTime.Now;
                    System.Globalization.CultureInfo cur = new
                        System.Globalization.CultureInfo("en-US");
                    string sdate = d.ToString("yyyyMMddHHmmss", cur);
                    string fileName = String.Format("{0}\\{1}{2}{3}.eml",
                        mailbox, sdate, d.Millisecond.ToString("d3"), i);

                    // Save email to local disk
                    oMail.SaveAs(fileName, true);

                    // Mark email as deleted from POP3 server.
                    oClient.Delete(info);
                }

                // Quit and pure emails marked as deleted from POP3 server.
                oClient.Quit();
                Console.WriteLine("-----------------------------------");
                
                
            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
            }
        }

        
    
}
}
