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


		public string Name { get; set; }
		public int Quantity { get; set; }
		public double StartingBid { get; set; }
		public string Donor { get; set; }

		// nameof(ItemUnit) may have to be replaced with Enum.GetName(typeof(ItemUnitEnum)
		public string Size {
			get { return Height + "x" + Length + "x" + Width + nameof(ItemUnit) + "(HxLxW)" ; }
			set { _size= value; }
		}

		private string _size;

		public double Height { get; set; }
		public double Width { get; set; }
		public double Length { get; set; }
		public ItemUnitEnum ItemUnit { get; set; }

		public string StorageLocation { get; set; }
		public int Condition { get; set; }
		public string Comments { get; set; }
		public string ImageUrl { get; set; }
		public bool IsSmall { get; set; }
	}
}
