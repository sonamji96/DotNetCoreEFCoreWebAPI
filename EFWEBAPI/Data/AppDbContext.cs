using Microsoft.EntityFrameworkCore;

namespace EFWEBAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CurrencyType>().HasData(
                new CurrencyType() {id=1 , Currency="INR" , Description="Indian Rupee" },
                new CurrencyType() {id=2 , Currency="Dollar" , Description="Dollar" },
                new CurrencyType() {id=3 , Currency="Euro" , Description="Euro" },
                new CurrencyType() {id=4 , Currency="Dinar" , Description="Dinar" }

                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id=1 , Title = "Hindi" , Description = "Hindi"},
                new Language() { Id=2 , Title = "English" , Description = "English"},
                new Language() { Id=3 , Title = "Urdu" , Description = "Urdu"},
                new Language() { Id=4 , Title = "Punjabi" , Description = "Punjabi"}
                
                );
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<BookPrice> BookPrice { get; set; }
    }
}
