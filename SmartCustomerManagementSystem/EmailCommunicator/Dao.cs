using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
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
                string NewBody = body.Replace("'", "");
                sql = "INSERT INTO Email_MessageReceived  (Sender, Subject, Message, Status)  VALUES     ('" + sender + "', '" + subject + "', '" + NewBody + "' ,1)";


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


       // Get email message details to process
       public DataTable GetMailDetailsForIntractions(Int16 ID)
       {

           try
           {

               try
               {
                   string sql = "";
                   DataSet dt;
                   sql = "SELECT   Email_MessageReceived.ID, Email_MessageReceived.Sender,  Email_MessageReceived.Message, Email_MessageReceived_Details.MessageParts, " + 
                            " Email_MessageReceived_Details.Count " +
                            " FROM   Email_MessageReceived INNER JOIN " +
                            " Email_MessageReceived_Details ON Email_MessageReceived.ID = Email_MessageReceived_Details.ID where IsAssigned =0 and Email_MessageReceived.ID ='" + ID + "' order by Email_MessageReceived_Details.Count desc ";
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

       public DataTable GetMailDetails()
       {

           try
           {

               try
               {
                   string sql = "";
                   DataSet dt;
                   sql = "SELECT     ID, Sender, Subject, Message, IsAssigned FROM    Email_MessageReceived WHERE (IsAssigned = 0) ";
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

       //Update DB after processing
       public void UpdateStatusOfAssignIntractionMails(int id)
       {

           try
           {
               string sql = "";
               sql = "UPDATE     Email_MessageReceived SET  IsAssigned   =1 where iD ='" + id + "' ";
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


       public DataTable GetCategoryAndGroupDetaile()
       {

           try
           {

               try
               {
                   string sql = "";
                   DataSet dt;
                     sql = " SELECT     CIA_InteractionType.InteractionType, CIA_InteractionType.InteractionTypeID, CIA_Type.TypeID, CIA_Type.Type, CIA_Category.CatID, CIA_Category.Category, CIA_SubCategory.SubCatID, " +
                      " CIA_SubCategory.SubCategory, CIA_SubCategory.AssignedGroup, CIA_SubCategory.IsActive "+
                       " FROM         CIA_Type INNER JOIN " +
                      " CIA_InteractionType ON CIA_Type.InteractionTypeID = CIA_InteractionType.InteractionTypeID INNER JOIN " +
                      " CIA_Category ON CIA_Type.TypeID = CIA_Category.TypeID INNER JOIN " +
                      " CIA_SubCategory ON CIA_Category.CatID = CIA_SubCategory.CatID " +
                      " WHERE     (CIA_SubCategory.IsActive = 1)";
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


       public Boolean InserIntraction(Int32 intractionID, int cusType, int cusID, int type, int mainCat,int cat , int subCat,String remarks ,String phoneNum ,int cUser ,int status , int modifiedUser ,int assignGrp ,int assignUser ,String email)
       {
           try
           {
               SqlParameter[] param = new SqlParameter[15];
               param[0] = new SqlParameter("@IntractionID", intractionID);
               param[1] = new SqlParameter("@CCustype", cusType);
               param[2] = new SqlParameter("@CusID", cusID);
               param[3] = new SqlParameter("@Type", type);
               param[4] = new SqlParameter("@MainCat", mainCat);
               param[5] = new SqlParameter("@Cat", cat);
               param[6] = new SqlParameter("@SubCat", subCat);
               param[7] = new SqlParameter("@Remarks", remarks);
               param[8] = new SqlParameter("@phoneNumber", phoneNum);
               param[9] = new SqlParameter("@CreateUser", cUser);
               param[10] = new SqlParameter("@Status", status);
               param[11] = new SqlParameter("@ModifiedUser", modifiedUser);
               param[12] = new SqlParameter("@AssignedGroup", assignGrp);
               param[13] = new SqlParameter("@AssignUser", assignUser);
               param[14] = new SqlParameter("@Email", email);
               callSp("Sp_InsertIntraction", param);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }


       
    }
}
