using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows;


namespace EmailCommunicator
{
    class NlpProcessor
    {

        Dao dataAccess;
        Customer custObj =new Customer();
        string[] tokens;
        HashSet<string>
        types;
      
        

        public void processData()
        {
            try
            {

                DataTable dt;
                DataTable custTbl;
                dataAccess = new Dao();
                dt = dataAccess.GetMailDetailsToProcess();
                NlpLogic logic = new NlpLogic();
                Dictionary<string, int> freq_table = new Dictionary<string, int>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        tokens = NlpLogic.ArrangeText(row["Message"].ToString());

                        if (tokens.Length > 0)
                        {
                            // convert array to dictionary
                            Dictionary<string, int> dict = logic.ToDict(tokens);
                            Dictionary<string, int> dict2 = logic.ListWordsByFreq(dict);
                            //Save message Details to DB

                            foreach (KeyValuePair<string, int> data in dict2)
                            {
                                dataAccess.SaveMailDetails(Convert.ToInt32(row["ID"].ToString()), data.Key.ToString(), data.Value.ToString());
                                Console.WriteLine("tokens got saved to DB");
                            }

                            //Search  existing customer for email
                            custObj.EMail =row["Sender"].ToString();
                            if (custObj.SearchCustomer(custObj))
                            {
                                Console.WriteLine("Customer alredy there");
                            }


                            else
                            {
                                //data for create customer
                                custObj.FirstName = "Dummy";
                                custObj.LastName1 = "Dummy";
                                custObj.PhoneNo = "0000";
                                custObj.SaveCustomer(custObj);
                                Console.WriteLine("New Customer saved to DB");

                            }

                               
                        }
                      
                       // MailMessage(row["Sender"].ToString(), "Automatic Reply", "Thank you for contacting ABC costomer care. We will address your matter soon");
                        dataAccess.UpdateStatusOfProcessedMails(Convert.ToInt16(row["ID"].ToString()));
                        foreach (String value in tokens)
                        {
                            Console.WriteLine(value.ToString());
                        }
                       
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            dataAccess = new Dao();

        }


        
    }
}
