using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction_central {
	class AuctionItem {
		public string Name { get; set; }
		public int Quantity { get; set; }
		public double StartingBid { get; set; }
		public string Donor { get; set; }
		public string Size { get; set; }
		public string StorageLocation { get; set; }
		public string Condition { get; set; }
		public string Comments { get; set; }
	}
}
