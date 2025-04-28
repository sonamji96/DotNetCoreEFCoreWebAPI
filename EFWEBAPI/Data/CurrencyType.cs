namespace EFWEBAPI.Data
{
    public class CurrencyType
    {
        public int id { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }

        public ICollection<BookPrice>  BookPrices { get; set; }
    }
}
