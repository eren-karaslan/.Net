using _3_Bookstore_AutoMapper_FluentValidition_.Common;
using _3_Bookstore_AutoMapper_FluentValidition_.DbOperations;
using _3_Bookstore_AutoMapper_FluentValidition_.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace _3_BookStore_AutoMapper_FluentValidition_.BookOperations.CreateBook;

public class CreateBookCommand
{
    private readonly BookStoreDbContext _dbContext;

    private readonly IMapper _mapper;

    public CreateBookModel Model { get; set; }

    public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
        if (book != null)
        {
            throw new InvalidOperationException("Kitap zaten mevcut");
        }

        book = _mapper.Map<Book>(Model);

        /*Mapper'dan önce
        book = new Book();
        book.Title = Model.Title;
        book.PublishDate = Model.PublishDate;
        book.GenreId = Model.GenreId;
        book.PageCount = Model.PageCount;
        */

        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();

    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int GenreId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
