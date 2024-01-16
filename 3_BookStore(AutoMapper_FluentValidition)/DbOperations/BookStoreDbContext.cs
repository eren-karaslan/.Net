using _3_Bookstore_AutoMapper_FluentValidition_.Entities;
using Microsoft.EntityFrameworkCore;

namespace _3_Bookstore_AutoMapper_FluentValidition_.DbOperations;

public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

    public DbSet<Book> Books {  get; set; }

}
