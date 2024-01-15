using _2_BookStore_EF_.Entities;
using Microsoft.EntityFrameworkCore;

namespace _2_BookStore_EF_.DbOperations;

public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

    public DbSet<Book> Books {  get; set; }

}
