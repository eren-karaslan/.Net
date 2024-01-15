using _2_BookStore_EF_.Common;
using _2_BookStore_EF_.DbOperations;
using _2_BookStore_EF_.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace _2_BookStore_EF_.BookOperations;

public class CreateBookCommand
{
    private readonly BookStoreDbContext _dbContext;

    private readonly IMapper _mapper;

    public CreateBookModel Model { get; set; }

    public CreateBookCommand(BookStoreDbContext dbContext,IMapper mapper)
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

        book=_mapper.Map<Book>(Model);

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
