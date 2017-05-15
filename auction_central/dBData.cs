
using System;

namespace auction_central
{
    public class dBData
    {
        private DbWrap dbWrap;

        public dBData()
        {
            dbWrap = new DbWrap();
        }
        /*
        public void AdminData()
        {
            for (int i = 0; i < 5; i++)
            {
                string first = NameFaker.FirstName();
                string last = NameFaker.LastName();
                string email = first + last + "@" + InternetFaker.Domain();
                string password = StringFaker.AlphaNumeric(GetRandInt(5, 14));
                string phone = StringFaker.Numeric(10);
                Int64 phonenum = Convert.ToInt64(phone);
                dbWrap.InsertAdmin(first, last, email, password, phonenum, Person.UserTypeEnum.Admin);
            }
        }

        public int GetRandInt(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        //(Bidder bidder, Person.UserTypeEnum type, string password, CreditCard creditcard, Address bidderaddress)
        public void BidderData()
        {
            for (int i = 0; i < 5; i++)
            {
                string first = NameFaker.FirstName();
                string last = NameFaker.LastName();
                string email = first + last + "@" + InternetFaker.Domain();
                string password = StringFaker.AlphaNumeric(GetRandInt(5, 14));
                string phone = StringFaker.Numeric(10);
                Int64 phonenum = Convert.ToInt64(phone);
                string card = StringFaker.Numeric(16);
                int cvv = GetRandInt(100, 999);

                int housenum = GetRandInt(300, 700);
                string house = Convert.ToString(housenum);
                string street = LocationFaker.Street();
                string streetAddress = house + " " + street;

                string city = LocationFaker.City();
                string zip = LocationFaker.ZipCode();
                int zipcode = Convert.ToInt32(zip);

                Address address = new Address(streetAddress, city, "NY", zipcode);
                CreditCard creditCard = new CreditCard(card, cvv, first + " " + last, "05/22");

                Bidder bidder = new Bidder(Person.UserTypeEnum.Bidder, 0, first, last, email, card, streetAddress,
                    phone);
                dbWrap.InsertBidder(bidder, Person.UserTypeEnum.Bidder, password, creditCard, address);

            }
        }
        //dbWrap.InsertNonprofit(firstName, lastName, email, password, phone, Person.UserTypeEnum.Nonprofit, OrgNames.SelectionBoxItem.ToString());
        public void NonProfitData()
        {
            for (int i = 0; i < 5; i++)
            {
                string first = NameFaker.FirstName();
                string last = NameFaker.LastName();
                string email = first + last + "@" + InternetFaker.Domain();
                string password = StringFaker.AlphaNumeric(GetRandInt(5, 14));
                string phone = StringFaker.Numeric(10);
                Int64 phonenum = Convert.ToInt64(phone);
                string org = CompanyFaker.Name();
                dbWrap.InsertNonprofit(first, last, email, password, phonenum, Person.UserTypeEnum.Nonprofit, org);
            }
        }

        public void AuctionData()
        {
            string first = NameFaker.FirstName();
            string last = NameFaker.LastName();
            string email = first + last + "@" + InternetFaker.Domain();
            string password = StringFaker.AlphaNumeric(GetRandInt(5, 14));
            string phone = StringFaker.Numeric(10);
            Int64 phonenum = Convert.ToInt64(phone);
            string org = CompanyFaker.Name();
            string location = LocationFaker.City();
            DateTime start = new DateTime(2017, 3, 25, 10, 30, 50);
            DateTime end = new DateTime(2017, 2, 25, 10, 30, 50);
            //public void InsertAuction(Auction auction, NonProfit nonprofit, long phonenum)
            Auction auction = new Auction(-1, org, start, end, first + " " + last, phone, location);
            NonProfit nonprofit = new NonProfit(Person.UserTypeEnum.Nonprofit, 121, first, last, email, phone, org);
            dbWrap.InsertAuction(auction, nonprofit, phonenum);
        }
        */
    }
}

//public void InsertAdmin(string firstname, string lastname, string email, string password, Int64 phonenumber, Person.UserTypeEnum type

   
  