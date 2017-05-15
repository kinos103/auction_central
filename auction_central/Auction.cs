using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction_central {
	public class Auction {
		public int AuctionId { get; set; }
		public string CharityName { get; set; }
		public DateTime EventDate { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string Contact { get; set; }
		public string PhoneNumber { get; set; }
		public string Location {get; set; }

		public Auction(string charityName, DateTime startTime, DateTime endTime, string contact, string phoneNumber) {
			CharityName = charityName;
			EventDate = startTime.Date;
			StartTime = startTime;
			EndTime = endTime;
			Contact = contact;
			PhoneNumber = phoneNumber;
		}

        //current
		public Auction(int auctionId, string charityName, DateTime startTime, DateTime endTime, string contact, string phoneNumber, string location) {
			AuctionId = auctionId;
			CharityName = charityName;
			EventDate = startTime.Date;
			StartTime = startTime;
			EndTime = endTime;
			Contact = contact;
			PhoneNumber = phoneNumber;
			Location = location;
		}

		public Auction() {
			AuctionId = 0;
			CharityName = "Auction ";
			StartTime = DateTime.Now;
			EventDate = StartTime.Date;
			EndTime = DateTime.Now.AddHours(3);
			Contact = "Mr. Smith";
			PhoneNumber = "123-354-6577";
		}


		public override string ToString() {
			return String.Join(",", AuctionId, CharityName, StartTime.Date.ToLongDateString(), StartTime.ToString("h:mm:ss tt zz"), EndTime.ToString("h:mm:ss tt zz"), Contact, PhoneNumber);
		}
	}
}
