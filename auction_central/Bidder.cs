using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction_central
{
    public class Bidder : Person
    {
        public string CardNumber { get; set; }
        public string Address { get; set; }
        public Bidder(UserTypeEnum usertype, int userid, string firstname, string lastname, string email, string cardnumber, string address, string phonenumber) : base(usertype, userid, firstname, lastname, phonenumber, email)
        {
            this.CardNumber = cardnumber;
            this.Address = address;
        }
    }
}
