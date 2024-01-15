using _2_BookStore_EF_.DbOperations;

namespace _2_BookStore_EF_.BookOperations
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;

        public int BookId { get; set; } 

        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var sorgu=_dbContext.Books.Where(x => x.Id == BookId).FirstOrDefault();

            if (sorgu == null)
                throw new InvalidOperationException("Böyle bir kitap bulunamdı");

            _dbContext.Books.Remove(sorgu);
            _dbContext.SaveChanges();
        }
    }
}
