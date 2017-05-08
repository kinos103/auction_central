using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction_central
{
    class Bidder : Person
    {
        protected int CardNumber { get; set; }
        protected string Address { get; set; }
        protected int PhoneNumber { get; set; }
        public Bidder(UserTypeEnum usertype, int userid, string firstname, string lastname, string email, int cardnumber, string address, int phonenumber) : base(usertype, userid, firstname, lastname, email)
        {
            this.CardNumber = cardnumber;
            this.Address = address;
            this.PhoneNumber = phonenumber;
        }
    }
}
