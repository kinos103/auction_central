using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace auction_central
{
    public class DbWrap
    {
        public DbWrap()
        {
        }

        public Admin AdminObjCreation(int adminEmailID, string emailEntered) ////usertype, int userid, string firstname, string lastname, string phonenumber, string email
        {
            int employeeid = 0;
            string firstname = "";
            string lastname = "";
            string phoneIDNum = "";
            string phonenumber = "";
            string email = emailEntered;

            MySqlConnection connection;
            string connectionString = @"Database=auction_central;Data Source=us-cdbr-azure-west-b.cleardb.com;User Id=b1a4a9b19daca1;Password=d28c0eba";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string adminQueryString = "SELECT(*) FROM admin WHERE emailID = @emailid";
                MySqlCommand adminQueryCommand = new MySqlCommand(adminQueryString, connection);
                adminQueryCommand.Parameters.AddWithValue("@emailID", adminEmailID);
                MySqlDataReader reader = adminQueryCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employeeid = reader.GetInt32(0);
                        firstname = reader.GetString(1);
                        lastname = reader.GetString(2);
                        phoneIDNum = reader.GetInt32(3).ToString();
                       
                    }

                    string phoneNumSearch = "SELECT phoneNumber FROM phonenumbers WHERE phoneID=@phoneid";
                    MySqlCommand phoneNumSearchQuery = new MySqlCommand(phoneNumSearch, connection);
                    phoneNumSearchQuery.Parameters.AddWithValue("@phoneid", phoneIDNum);
                    MySqlDataReader phoneReader = phoneNumSearchQuery.ExecuteReader();
                    if(phoneReader.HasRows)
                        while (phoneReader.Read())
                            phonenumber = reader.GetString(0);
                }

                

            }
            catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            finally { connection.Close(); }
            Admin adminObj = new Admin(Person.UserTypeEnum.Admin, employeeid, firstname, lastname, phonenumber, email );
            return adminObj;
        }

        public NonProfit NonProfitObjCreation(int nonprofitID, string emailEntered)
        {
            int npid = 0;
            string firstname = "";
            string lastname = "";
            string phoneIDNum = "";
            string phonenumber = "";
            string email = emailEntered;
            string org = "";

            MySqlConnection connection;
            string connectionString = @"Database=auction_central;Data Source=us-cdbr-azure-west-b.cleardb.com;User Id=b1a4a9b19daca1;Password=d28c0eba";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string npQueryString = "SELECT(*) FROM nonprofit WHERE nonprofitID = @nonprofitid";
                MySqlCommand npQueryCommand = new MySqlCommand(npQueryString, connection);
                npQueryCommand.Parameters.AddWithValue("@emailID", nonprofitID);
                MySqlDataReader reader = npQueryCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        npid = reader.GetInt32(0);
                        firstname = reader.GetString(1);
                        lastname = reader.GetString(2);
                        phoneIDNum = reader.GetInt32(3).ToString();
                        org = reader.GetString(5);

                    }

                    string phoneNumSearch = "SELECT phoneNumber FROM phonenumbers WHERE phoneID=@phoneid";
                    MySqlCommand phoneNumSearchQuery = new MySqlCommand(phoneNumSearch, connection);
                    phoneNumSearchQuery.Parameters.AddWithValue("@phoneid", phoneIDNum);
                    MySqlDataReader phoneReader = phoneNumSearchQuery.ExecuteReader();
                    if (phoneReader.HasRows)
                        while (phoneReader.Read())
                            phonenumber = reader.GetString(0);
                }
                
            }
            catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            finally { connection.Close(); }
            NonProfit adminObj = new NonProfit(Person.UserTypeEnum.Nonprofit, nonprofitID, firstname, lastname, email, phonenumber, org);
            return adminObj;
        }

        public Bidder BidderObjCreation(int bidderID, string emailEntered)
        {
            int bidderid = 0;
            string firstname = "";
            string lastname = "";
            string phoneIDNum = "";
            string phonenumber = "";
            string email = emailEntered;
            string org = "";

            MySqlConnection connection;
            string connectionString = @"Database=auction_central;Data Source=us-cdbr-azure-west-b.cleardb.com;User Id=b1a4a9b19daca1;Password=d28c0eba";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string npQueryString = "SELECT(*) FROM bidder WHERE contactID = @bidderID";
                MySqlCommand npQueryCommand = new MySqlCommand(npQueryString, connection);
                npQueryCommand.Parameters.AddWithValue("@emailID", bidderID);
                MySqlDataReader reader = npQueryCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bidderid = reader.GetInt32(0);
                        firstname = reader.GetString(1);
                        lastname = reader.GetString(2);
                        phoneIDNum = reader.GetInt32(3).ToString();
                        org = reader.GetString(5);

                    }

                    string phoneNumSearch = "SELECT phoneNumber FROM phonenumbers WHERE phoneID=@phoneid";
                    MySqlCommand phoneNumSearchQuery = new MySqlCommand(phoneNumSearch, connection);
                    phoneNumSearchQuery.Parameters.AddWithValue("@phoneid", phoneIDNum);
                    MySqlDataReader phoneReader = phoneNumSearchQuery.ExecuteReader();
                    if (phoneReader.HasRows)
                        while (phoneReader.Read())
                            phonenumber = reader.GetString(0);
                }

            }
            catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            finally { connection.Close(); }
            Bidder adminObj = new Bidder(Person.UserTypeEnum.Nonprofit, nonprofitID, firstname, lastname, email, phonenumber, org);
            return adminObj;
        }
    }


}

//usertype, int userid, string firstname, string lastname, string email, int cardnumber, string address, int phonenumber
//usertype, int userid, string firstname, string lastname, string email, int phonenumber, string orgname
