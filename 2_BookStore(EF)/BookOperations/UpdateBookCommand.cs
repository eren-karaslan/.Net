using _2_BookStore_EF_.Common;
using _2_BookStore_EF_.DbOperations;

namespace _2_BookStore_EF_.BookOperations
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;

        public int BookId;

        public UpdateBookModel Model;

        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var sorgu=_dbContext.Books.Where(x=> x.Id == BookId).FirstOrDefault();

            if (sorgu == null)
                throw new InvalidOperationException("Böyle bir kitap bulunamadı");

            sorgu.Title=Model.Title;
            sorgu.GenreId = Model.GenreId;

            _dbContext.SaveChanges();

        }

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
        }
    }
}
