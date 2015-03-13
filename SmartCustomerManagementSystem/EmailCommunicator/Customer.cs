using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EmailCommunicator
{
    class Customer
    {
        CustomerDal dal = new CustomerDal();
            private String firstName;

            public String FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }
            private String LastName;

            public String LastName1
            {
                get { return LastName; }
                set { LastName = value; }
            }
            private String phoneNo;

            public String PhoneNo
            {
                get { return phoneNo; }
                set { phoneNo = value; }
            }
            private String eMail;

            public String EMail
            {
                get { return eMail; }
                set { eMail = value; }
            }

            private String createuser;
     
            public String Createuser
            {
                get { return Createuser; }
                set { Createuser = value; }
            }
            private DateTime createDate;

            public DateTime CreateDate
            {
                get { return createDate; }
                set { createDate = value; }
            }



        //Serch Customer from the DB
            public Boolean SearchCustomer(Customer obj)
            {
                DataTable Dt = dal.SerchCustomer(obj.eMail);
                if (Dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }



        //Save newcustomer
            public void SaveCustomer(Customer obj)
            {
                 dal.SaveCustomerDetails(obj.eMail,obj.firstName,obj.LastName,obj.phoneNo);
                 
            }

            //Get Customer from the DB
            public DataTable SearchCustomerbymail(String mail)
            {
                DataTable Dt = dal.SerchCustomer(mail);
                if (Dt.Rows.Count > 0)
                    return Dt;
                else
                    return Dt;
            }

    }
}
