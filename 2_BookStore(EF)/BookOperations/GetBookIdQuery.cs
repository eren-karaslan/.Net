using _1_BookStore_Tüm_endpointler_.Controllers;
using _2_BookStore_EF_.Common;
using _2_BookStore_EF_.DbOperations;
using AutoMapper;

namespace _2_BookStore_EF_.BookOperations;

public class GetBookIdQuery
{
    private readonly BookStoreDbContext _context;

    private readonly IMapper _mapper

    public int BookId { get; set; }

    public GetBookIdQuery(BookStoreDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public BookIdViewModel Handle()
    {
        var sorgu=_context.Books.Where(x=> x.Id == BookId).SingleOrDefault();
        if (sorgu == null)
            throw new InvalidOperationException("Böyle bir Id'e sahip kitap yok");

        BookIdViewModel vm= _mapper.Map<BookIdViewModel>(sorgu);

        /*
        BookIdViewModel vm=new BookIdViewModel();
        vm.Title = sorgu.Title;
        vm.PageCount = sorgu.PageCount;
        vm.PublishDate = sorgu.PublishDate.Date;
        vm.Genre = ((GenreEnum)sorgu.GenreId).ToString();
        */

        return vm;
    }

    public class BookIdViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }



}
