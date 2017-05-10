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

        public Person LoginExists(string emailAddress, string password, Person.UserTypeEnum userType) {
            Person toReturn = null;

            // get email id
            int emailId = GetEmailId(emailAddress, password, userType);

            Console.WriteLine(emailId);
            if (emailId == -1)
            {
                return null;
            }
            switch (userType)
            {
                    case Person.UserTypeEnum.Admin:
                        toReturn = AdminObjCreation(emailId);
                        break;
                    case Person.UserTypeEnum.Bidder:
                        toReturn = BidderObjCreation(emailId);
                        break;
                    case Person.UserTypeEnum.Nonprofit:
                        toReturn = NonProfitObjCreation(emailId);
                        break;

            }

            return toReturn;
        }

        public int GetEmailId(string emailAddress, string password, Person.UserTypeEnum userTypeEnum) {
            int toReturn = -1;
            string connectionString = @"Database=auction_central;Data Source=us-cdbr-azure-west-b.cleardb.com;User Id=b1a4a9b19daca1;Password=d28c0eba";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string emailQueryString = @"SELECT emailID
                                            FROM login
                                            WHERE emailAddress=@emailAddress AND password=@password AND type=@userType;";
                MySqlCommand emailQueryCommand = new MySqlCommand(emailQueryString, connection);
                emailQueryCommand.Parameters.AddWithValue("@emailAddress", emailAddress);
                emailQueryCommand.Parameters.AddWithValue("@password", password);
                emailQueryCommand.Parameters.AddWithValue("@userType", (int) userTypeEnum);
                MySqlDataReader reader = emailQueryCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    toReturn = reader.GetInt32(0);
                }

            }
            catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            finally { connection.Close(); }

            return toReturn;
        }

        private Admin AdminObjCreation(int adminEmailID) ////usertype, int userid, string firstname, string lastname, string phonenumber, string email
        {
            int employeeid = 0;
            string firstname = "";
            string lastname = "";
            string phonenumber = "";
            string email = "";

            MySqlConnection connection;
            string connectionString = @"Database=auction_central;Data Source=us-cdbr-azure-west-b.cleardb.com;User Id=b1a4a9b19daca1;Password=d28c0eba";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string adminQueryString = @"SELECT
                                              employeeID,
                                              firstName,
                                              lastName,
                                              emailAddress,
                                              phoneNumber
                                            FROM admin
                                              JOIN phonenumbers ON admin.phoneID = phonenumbers.phoneID
                                              JOIN login ON admin.emailID = login.emailID
                                            WHERE admin.emailID = @adminEmailId";
                MySqlCommand adminQueryCommand = new MySqlCommand(adminQueryString, connection);
                adminQueryCommand.Parameters.AddWithValue("@adminEmailId", adminEmailID);
                MySqlDataReader reader = adminQueryCommand.ExecuteReader(); 
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employeeid = reader.GetInt32(0);
                        firstname = reader.GetString(1);
                        lastname = reader.GetString(2);
                        email = reader.GetString(3);
                        phonenumber = reader.GetString(4);
                    }
                }
                else
                {
                    return null;
                }

                

            }
            catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            finally { connection.Close(); }
            Admin adminObj = new Admin(Person.UserTypeEnum.Admin, employeeid, firstname, lastname, phonenumber, email );
            return adminObj;
        }

        private NonProfit NonProfitObjCreation(int nonprofitEmailID)
        {
            int npid = 0;
            string firstname = "";
            string lastname = "";
            string phonenumber = "";
            string email = "";
            string org = "";

            MySqlConnection connection;
            string connectionString = @"Database=auction_central;Data Source=us-cdbr-azure-west-b.cleardb.com;User Id=b1a4a9b19daca1;Password=d28c0eba";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string npQueryString = @"SELECT
                                          nonprofitID,
                                          firstname,
                                          lastName,
                                          phoneNumber,
                                          orgName,
                                          emailAddress
                                        FROM nonprofit
                                          JOIN phonenumbers ON nonprofit.phoneID = phonenumbers.phoneID
                                          JOIN login ON nonprofit.emailID = login.emailID
                                        WHERE nonprofit.emailID = @nonprofitEmailId;";
                MySqlCommand npQueryCommand = new MySqlCommand(npQueryString, connection);
                npQueryCommand.Parameters.AddWithValue("@nonprofitEmailId", nonprofitEmailID);
                MySqlDataReader reader = npQueryCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        npid = reader.GetInt32(0);
                        firstname = reader.GetString(1);
                        lastname = reader.GetString(2);
                        phonenumber = reader.GetString(3);
                        org = reader.GetString(4);
                        email = reader.GetString(5);
                    }

                }
                else
                {
                    return null;
                }
                
            }
            catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            finally { connection.Close(); }
            NonProfit nonProfitObj = new NonProfit(Person.UserTypeEnum.Nonprofit, npid, firstname, lastname, email, phonenumber, org);
            return nonProfitObj;
        }

        private Bidder BidderObjCreation(int bidderEmailId)
        {
            int bidderid = 0;
            string firstname = "";
            string lastname = "";
            string phonenumber = "";
            string email = "";
            string cardNumber = "";
            string address = "";
            string city = "";
            string state = "";
            int zipCode = 0;


            MySqlConnection connection;
            string connectionString = @"Database=auction_central;Data Source=us-cdbr-azure-west-b.cleardb.com;User Id=b1a4a9b19daca1;Password=d28c0eba";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string bidderQueryString = @"SELECT
                                              contactID,
                                              firstname,
                                              lastname,
                                              phoneNumber,
                                              cardnumber,
                                              homeaddress,
                                              city,
                                              state,
                                              zipcode,
                                              emailAddress
                                            FROM bidder
                                              JOIN creditcards ON bidder.cardID = creditcards.creditID
                                              JOIN address ON bidder.addressID = address.homeID
                                              JOIN phonenumbers ON bidder.phoneID = phonenumbers.phoneID
                                              JOIN login ON bidder.emailID = login.emailID
                                            WHERE bidder.emailID = @bidderEmailId;";
                MySqlCommand npQueryCommand = new MySqlCommand(bidderQueryString, connection);
                npQueryCommand.Parameters.AddWithValue("@bidderEmailId", bidderEmailId);
                MySqlDataReader reader = npQueryCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bidderid = reader.GetInt32(0);
                        firstname = reader.GetString(1);
                        lastname = reader.GetString(2);
                        phonenumber = reader.GetString(3);
                        cardNumber = reader.GetString(4);
                        address = reader.GetString(5);
                        city = reader.GetString(6);
                        state = reader.GetString(7);
                        zipCode = reader.GetInt32(8);
                        email = reader.GetString(9);

                    }

                }
                else
                {
                    return null;
                }

            }
            catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            finally { connection.Close(); }
            string concatAddress = address + " " + city + " " + state + " " + zipCode;
            Bidder bidderObj = new Bidder(Person.UserTypeEnum.Bidder, bidderid, firstname, lastname, email, cardNumber, concatAddress, phonenumber);
            return bidderObj;
        }
    }


}

//usertype, int userid, string firstname, string lastname, string email, int cardnumber, string address, int phonenumber
//usertype, int userid, string firstname, string lastname, string email, int phonenumber, string orgname
