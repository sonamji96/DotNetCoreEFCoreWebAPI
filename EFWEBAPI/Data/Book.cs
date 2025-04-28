namespace EFWEBAPI.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desription { get; set; }
        public int NoOfPages { get; set; }
        public bool IsActive { get; set; }
       
        public DateTime CreatedON { get; set; }

        public int LanguageId { get; set; } 
            
        public Language? Language { get; set; }
    }
}
