namespace auction_central {
    public class Address {
        public string HouseNumber {get; set;}
        public string City {get; set;}
        public string State {get; set;}
        public int Zipcode {get; set;}

        public Address(string houseNumber, string city, string state, int zipcode) {
            HouseNumber = houseNumber;
            City = city;
            State = state;
            Zipcode = zipcode;
        }
    }
}