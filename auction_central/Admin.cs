using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction_central
{
    public class Admin : Person
    {
        public Admin(UserTypeEnum usertype, int userid, string firstname, string lastname, string email) : base(usertype, userid, firstname, lastname, email)
        {
        }
    }
}
