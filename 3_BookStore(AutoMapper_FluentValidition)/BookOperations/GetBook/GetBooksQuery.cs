using _3_Bookstore_AutoMapper_FluentValidition_.Common;
using _3_Bookstore_AutoMapper_FluentValidition_.DbOperations;
using _3_Bookstore_AutoMapper_FluentValidition_.Entities;
using AutoMapper;

namespace _3_BookStore_AutoMapper_FluentValidition_.BookOperations.GetBook
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
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
