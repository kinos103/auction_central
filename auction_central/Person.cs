using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction_central {
	public class Person
    {
		public enum UserType
        {
			Admin,
			Bidder,
			Nonprofit
		}

		protected int UserId { get; set; }
		protected string Email { get; set; }

        public Person(UserType usertype, int userid, string email)
        {
            this.UserId = userid;
            this.Email = email;
        }
    }
}
