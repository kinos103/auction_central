using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction_central {
	public class Person
    {
		public enum UserTypeEnum
        {
	        Bidder = 1,
	        Admin = 2,
	        Nonprofit = 3
		}

        public UserTypeEnum UserType { get; set; }
		public int UserId { get; set; }
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Person()
        {
        }

        public Person(UserTypeEnum usertype, int userid, string firstname, string lastname, string phonenumber, string email)
        {
            this.UserType = usertype;
            this.UserId = userid;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.PhoneNumber = phonenumber;
            this.Email = email;
        }
    }
}
