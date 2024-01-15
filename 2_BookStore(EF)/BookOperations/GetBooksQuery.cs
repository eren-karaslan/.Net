using _2_BookStore_EF_.Common;
using _2_BookStore_EF_.DbOperations;
using _2_BookStore_EF_.Entities;
using AutoMapper;

namespace _2_BookStore_EF_.BookOperations
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BookViewModel> Handle()
        {
            var booklist = _dbContext.Books.ToList();
            List<BookViewModel> vm = _mapper.Map<List<BookViewModel>>(booklist); 
            /*
            List<BookViewModel> vm = new List<BookViewModel>();
            foreach (var item in booklist)
            {
                vm.Add(new BookViewModel()
                {
                    Title = item.Title,
                    PageCount = item.PageCount,
                    PublishDate = item.PublishDate.Date,
                    Genre = ((GenreEnum)item.GenreId).ToString()
                });
            }*/

            return vm;
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
