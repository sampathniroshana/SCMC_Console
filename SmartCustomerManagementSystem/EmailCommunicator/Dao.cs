using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EmailCommunicator
{
    class Dao : Dal
    {
        // Save email message Details to the DB
       public void SaveMail(String sender , String subject , String body)
       {

           try
            {
                string sql="";
                sql = "INSERT INTO Email_MessageReceived  (Sender, Subject, Message, Status)  VALUES     ('" + sender + "', '" + subject + "', '" + body + "' ,1)";
                exeNonQury(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



       // Get email message Details to the DB
       public DataTable GetMailDetailsToReply()
       {

           try
           {

               try
               {
                   string sql = "";
                   DataSet dt;
                   sql = "SELECT     ID, Sender, Subject, Message, ReceivedDate, RepliedDate, Status, IsReplied, IsProcessed, IsResolved FROM Email_MessageReceived where IsReplied =0";
                   dt = getDataset(sql);
                   return dt.Tables[0];
               }
               catch (Exception ex)
               {
                   throw ex;
               }

           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
        //Update DB after responding to the mail
       public void UpdateStatusOfInitialMail(int id)
       {

           try
           {
               string sql = "";
               sql = "UPDATE     Email_MessageReceived SET  IsReplied  =1 where iD ='" + id + "' ";
               exeNonQury(sql);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       // Get email message details to process
       public DataTable GetMailDetailsToProcess()
       {

           try
           {

               try
               {
                   string sql = "";
                   DataSet dt;
                   sql = "SELECT     ID, Sender, Subject, Message, ReceivedDate, RepliedDate, Status, IsReplied, IsProcessed, IsResolved FROM Email_MessageReceived where IsProcessed =0";
                   dt = getDataset(sql);
                   return dt.Tables[0];
               }
               catch (Exception ex)
               {
                   throw ex;
               }

           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


       //Update DB after processing
       public void UpdateStatusOfProcessedMails(int id)
       {

           try
           {
               string sql = "";
               sql = "UPDATE     Email_MessageReceived SET  IsProcessed  =1 where iD ='" + id + "' ";
               exeNonQury(sql);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


       // Save email message Details to the DB
       public void SaveMailDetails(int ID, String messageParts, String count)
       {

           try
           {
               string sql = "";
               sql = "INSERT INTO Email_MessageReceived_Details  (ID, MessageParts, Count)  VALUES     ('" + ID + "', '" + messageParts + "', '" + count + "' )";
               exeNonQury(sql);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }




       
    }
}
