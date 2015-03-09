using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EmailCommunicator
{
    class DataProcessor
    {
        Boolean isRunning;
        public void ThreadMethod()
        {
            Thread thread = null;
            ThreadStart job = new ThreadStart(RunCaller);
            thread = new Thread(job);
            isRunning = true;
            thread.Start();

        }


        private void RunCaller()
        {
            while (isRunning)
            {

                try
                {
                    EmailReceiver email = new EmailReceiver();
                    EmailSender sendMail = new EmailSender();
                    NlpProcessor mailProcess = new NlpProcessor();
                    email.ReceiveMails();
                    sendMail.ComposeDefaultEmail();
                    mailProcess.processData();
                    Thread.Sleep(5000);
                }
                catch (Exception ex)
                {

                }
            }
            

        }

    }
}
