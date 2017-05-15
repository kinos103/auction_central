namespace auction_central {
    public class CreditCard {
        public string CardNumber {get; set;}
        public int CVV {get; set;}
        public string NameOnCard{get; set;}
        public string ExpDate{get; set;}

        public CreditCard(string cardNumber, int cvv, string nameOnCard, string expDate) {
            CardNumber = cardNumber;
            CVV = cvv;
            NameOnCard = nameOnCard;
            ExpDate = expDate;
        }
    }
}