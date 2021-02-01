
namespace BankLibrary
{
    public class BankCard
    {
        private static int cardNumberSeed = 111;
        public int CardNumber { get; set; }
        private int CardPinCode { get; set; }

        public int Tries = 1;
        public int MaxTries = 4;
        public bool IsLocked { get; set; }

        public BankCard(int cardPinCode, bool isLocked)
        {
            this.CardNumber = cardNumberSeed;
            this.CardPinCode = cardPinCode;
            this.IsLocked = isLocked;

            cardNumberSeed++;
        }

        public int GetPincode()
        {
            return this.CardPinCode;
        }

        public int GetCardnumber()
        {
            return this.CardNumber;
        }
    }
}