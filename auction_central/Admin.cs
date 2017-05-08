using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction_central
{
    public class Admin : Person
    {
        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        protected int PhoneNumber { get; set; }
       
        public Admin(UserTypeEnum usertype, int userid, string email, string firstname, string lastname, int phonenumber) : base(usertype, userid, email)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.PhoneNumber = phonenumber;
        }
    }
}
