using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;


namespace EmailCommunicator
{
   static  class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataProcessor processor = new DataProcessor();
            processor.ThreadMethod();
            
           
           
        }

           
        
    }
}
