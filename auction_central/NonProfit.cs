using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction_central
{
    public class NonProfit : Person
    {
        protected int PhoneNumber { get; set; }
        protected string OrgName { get; set; }
        public NonProfit(UserTypeEnum usertype, int userid, string firstname, string lastname, string email, string phonenumber, string orgname) : base(usertype, userid, firstname, lastname, phonenumber, email)
        {
            
            this.OrgName = orgname;
        }
    }
}
