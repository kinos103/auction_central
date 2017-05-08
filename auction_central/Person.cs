﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction_central {
	public class Person
    {
		public enum UserTypeEnum
        {
			Admin,
			Bidder,
			Nonprofit
		}

        protected UserTypeEnum UserType { get; set; }
		protected int UserId { get; set; }
		protected string Email { get; set; }

        public Person(UserTypeEnum usertype, int userid, string email)
        {
            this.UserType = usertype;
            this.UserId = userid;
            this.Email = email;
        }
    }
}
