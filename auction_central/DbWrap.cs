using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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

        private void AddItems()
        {
        }

        public List<Auction> AuctionObjList()
        {
            CultureInfo enUS = new CultureInfo("en-US");
            //string charityName, DateTime startTime, DateTime endTime, string contact, string phoneNumber
            List<Auction> auctions = new List<Auction>();
            //string charityName = "";
            string firstName = "";
            string lastName = "";
            //DateTime startTime;
            //DateTime endTime;
            string startTime_str;
            string endTime_str;
            string contact = ""; // full name
            string phoneNumber = "";

            MySqlConnection connection;
            string connectionString = @"Database=auction_central;Data Source=us-cdbr-azure-west-b.cleardb.com;User Id=b1a4a9b19daca1;Password=d28c0eba";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string auctionQueryString = @"SELECT N.orgName, N.firstname, N.lastName,
                                    A.enddate, A.starttime, A.enddate, P.phoneNumber
                                    FROM nonprofit N
                                    LEFT JOIN auctioninfo A
                                    ON N.nonprofitID = A.nonprofitID
                                    LEFT JOIN phonenumbers P
                                    ON N.phoneID = P.phoneID;";
                MySqlCommand auctionQueryCommand = new MySqlCommand(auctionQueryString, connection);
                MySqlDataReader reader = auctionQueryCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string charityName = reader.GetString(0);
                        firstName = reader.GetString(1);
                        lastName = reader.GetString(2);
                        contact = firstName + " " + lastName; // full name 
                        startTime_str = reader.GetString(3);
                        endTime_str = reader.GetString(4);
                        phoneNumber = reader.GetString(5);
                        DateTime startTime;
                        DateTime endTime;
                        // Parse date with no style flags.
                        if (DateTime.TryParse(startTime_str, out startTime))
                            Console.WriteLine("Converted '{0}' to {1} ({2}).", startTime_str, startTime,
                                startTime.Kind);
                        // Parse date with no style flags.
                        if (DateTime.TryParse(endTime_str, out endTime))
                            Console.WriteLine("Converted '{0}' to {1} ({2}).", endTime_str, endTime,
                                endTime.Kind);
                        Auction curAuction = new Auction(charityName, startTime, endTime, contact, phoneNumber);
                       auctions.Add(curAuction);
                    }

                }
                else
                {
                    return null;
                }

            }
            catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            finally { connection.Close(); }
            return auctions;
        }

        public List<AuctionItem> AuctionItemsObjList(int auctionid)
        {
            List<AuctionItem> auctionItems = new List<AuctionItem>();
            string name; //
            int quantity; //
            double startingBid; //
            double currentBid;
            string donor; //
            int auctionItemId; //
            double height; //
            double width; //
            double length; //
            AuctionItem.ItemUnitEnum itemUnit; //
            string storageLocation; //
            AuctionItem.ItemConditionEnum itemCondition; //
            string comments; //
            string imageUrl; //
            bool isSmall; // 

            MySqlConnection connection;
            string connectionString = @"Database=auction_central;Data Source=us-cdbr-azure-west-b.cleardb.com;User Id=b1a4a9b19daca1;Password=d28c0eba";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string auctionQueryString = @"SELECT A.itemName, A.AuctionItemID,
                                              A.location, N.orgName, A.conditionRate, A.isSmall, A.comments, A.quantity,
                                              A.originalprice,A.currentprice, I.height, I.width, I.length, I.itemunit
                                            FROM auctionitem A
                                            LEFT JOIN itemdimensions I
                                            ON A.itemdimensions = I.dimensionID
                                            LEFT JOIN nonprofit N
                                            ON A.donorID = N.nonprofitID
                                            WHERE A.auctionID=@aucttionid;";
                MySqlCommand auctionQueryCommand = new MySqlCommand(auctionQueryString, connection);
                auctionQueryCommand.Parameters.AddWithValue("@auctionid", auctionid);
                MySqlDataReader reader = auctionQueryCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        name = reader.GetString(0);
                        auctionItemId = reader.GetInt32(1);
                        storageLocation = reader.GetString(2);
                        donor = reader.GetString(3);
                        int itemCondition_int = reader.GetInt32(4);
                        itemCondition = (AuctionItem.ItemConditionEnum) Enum.ToObject(typeof(AuctionItem.ItemConditionEnum),
                                itemCondition_int);
                        isSmall = reader.GetBoolean(5);
                        comments = reader.GetString(6);
                        quantity = reader.GetInt32(7);
                        startingBid = reader.GetInt32(8);
                        currentBid = reader.GetInt32(9);
                        height = reader.GetInt32(10);
                        width = reader.GetInt32(11);
                        length = reader.GetInt32(12);
                        int itemUnit_int = reader.GetInt32(13);
                        itemUnit = (AuctionItem.ItemUnitEnum) Enum.ToObject(typeof(AuctionItem.ItemUnitEnum), itemUnit_int);
                        //string name, int quantity, double startingBid, double currentBid, string donor, int auctionItemId, double height, double width, double length,
                        //ItemUnitEnum itemUnit, string storageLocation, ItemConditionEnum condition, string comments, string imageUrl, bool isSmall
                        AuctionItem curAuctionItem = new AuctionItem(name, quantity, startingBid, currentBid, donor,
                            auctionItemId, height, width, length, itemUnit, storageLocation, itemCondition, comments,
                            "", isSmall);
                        auctionItems.Add(curAuctionItem);
                    }

                }
                else
                {
                    return null;
                }

            }
            catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            finally { connection.Close(); }
            return auctionItems;
        }


        /*  @"SELECT
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
                */

        public Admin PersonObjCreation_InsertPerson(string firstname, string lastname, string email, string password,
            Person.UserTypeEnum type)
        {
            MySqlConnection connection;
            string connectionString = @"Database=auction_central;Data Source=us-cdbr-azure-west-b.cleardb.com;User Id=b1a4a9b19daca1;Password=d28c0eba";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string loginQueryString = @"SELECT * FROM login WHERE login.emailAddress=@emailaddress;";
                MySqlCommand loginQueryCommand = new MySqlCommand(loginQueryString, connection);
                loginQueryCommand.Parameters.AddWithValue("@emailaddress", email);
                MySqlDataReader reader = loginQueryCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    return null; //error message here
                }
                else
                {   //TODO FINISH --------------------------------
                    string loginInsertString = @"";
                    MySqlCommand loginInsertCommand = new MySqlCommand(loginInsertString, connection);
                    loginInsertCommand.Parameters.AddWithValue("@", );
                }

            }
            catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            finally { connection.Close(); }
            //return ....;
        }

    }
}




//usertype, int userid, string firstname, string lastname, string email, int cardnumber, string address, int phonenumber
//usertype, int userid, string firstname, string lastname, string email, int phonenumber, string orgname
