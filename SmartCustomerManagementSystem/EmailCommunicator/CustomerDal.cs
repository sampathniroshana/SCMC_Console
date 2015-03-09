using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EmailCommunicator
{
    class CustomerDal : Dal
    {
        //Serch Customer
    
        public DataTable SerchCustomer(String emailAddress)
        {
            try
            {
                string sql = "";
                DataSet dt;
                sql = "SELECT   *   FROM  CIA_Customer where Email= '" + emailAddress + "'";
                dt = getDataset(sql);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       

        // Save Dummy customer
        public void SaveCustomerDetails(String eMail,String fNAme, String LName,String phomeNo )
        {

            try
            {
                string sql = "";
                sql = "INSERT INTO CIA_Customer ( FirstName, LastName, PhoneNo, Email, CreatedUser, CreatedDate)"+
                    "VALUES     ('" + fNAme + "', '" + LName + "','"+phomeNo+"' ,'" + eMail + "','System',getdate() )";
                exeNonQury(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
