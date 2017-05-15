using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction_central {
	public class AuctionItem {
		public enum ItemUnitEnum {
			Meters=1,
			Centimeters=2,
			Milimeters=3,
			Inches=4,
			Feet=5,
			Yards=6
		}

	    public enum ItemConditionEnum
	    {
	        New=1,
            Used=2
	    }

		public string Name { get; set; }
		public int Quantity { get; set; }
		public double StartingBid { get; set; }
        public double CurrentBid { get; set; }
		public string Donor { get; set; }
		public int AuctionItemId { get; set; }

		// nameof(ItemUnit) may have to be replaced with Enum.GetName(typeof(ItemUnitEnum))
		public string Size {
			get { return Height + "x" + Length + "x" + Width + Enum.GetName(typeof(ItemUnitEnum), ItemUnit) + "(HxLxW)" ; }
			set { _size= value; }
		}

		private string _size;

		public double Height { get; set; }
		public double Width { get; set; }
		public double Length { get; set; }
		public ItemUnitEnum ItemUnit { get; set; }
        public ItemConditionEnum ItemCondition { get; set; }

		public string StorageLocation { get; set; }
		//public int Condition { get; set; }
		public string Comments { get; set; }
		public string ImageUrl { get; set; }
		public bool IsSmall { get; set; }
        public bool IsSold { get; set; }


		public AuctionItem(string name, int quantity, double startingBid, double currentBid, string donor, int auctionItemId, double height, double width, double length, ItemUnitEnum itemUnit, string storageLocation, ItemConditionEnum condition, string comments, string imageUrl, bool isSmall, bool isSold) {
			Name = name;
			Quantity = quantity;
			StartingBid = startingBid;
		    CurrentBid = currentBid;
			Donor = donor;
			AuctionItemId = auctionItemId;
			Height = height;
			Width = width;
			Length = length;
			ItemUnit = itemUnit;
			StorageLocation = storageLocation;
			ItemCondition = condition;
			Comments = comments;
			ImageUrl = imageUrl;
			IsSmall = isSmall;
		    IsSold = isSold;
		}

		public AuctionItem() {
			Name = "Unset Name";
			Quantity = -1;
			StartingBid = -1;
			Donor = "Unset Donor";
			AuctionItemId = -1;
			Height = -1;
			Width = -1;
			Length = -1;
			ItemUnit = ItemUnitEnum.Feet;
			StorageLocation = "Unset Location";
			ItemCondition = ItemConditionEnum.New;
			Comments = "This is an unset additional comments string you should really set it";
			ImageUrl = "";
			IsSmall = false;
		    IsSold = false;
		}
	}
}
