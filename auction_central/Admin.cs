using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction_central
{
    public class Admin : Person
    {
        public Admin(UserTypeEnum usertype, int userid, string email) : base(usertype, userid, email)
        {
        }
    }
}
