using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction_central {
	public class Auction {
		public int AuctionId { get; set; }
		public string CharityName { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string Contact { get; set; }
		public string PhoneNumber { get; set; }

		public Auction(string charityName, DateTime startTime, DateTime endTime, string contact, string phoneNumber) {
			CharityName = charityName;
			StartTime = startTime;
			EndTime = endTime;
			Contact = contact;
			PhoneNumber = phoneNumber;
		}

		public Auction() {
			AuctionId = 0;
			CharityName = "Auction ";
			StartTime = DateTime.Now;
			EndTime = DateTime.Now.AddHours(3);
			Contact = "Mr. Smith";
			PhoneNumber = "123-354-6577";
		}
	}
}
