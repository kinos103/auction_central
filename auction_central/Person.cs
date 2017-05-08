using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction_central {
	public class Person {
		public enum UserType {
			Admin,
			Bidder,
			Nonprofit
		}

		public int UserId { get; set; }
		public string Email { get; set; }
		

	}
}
