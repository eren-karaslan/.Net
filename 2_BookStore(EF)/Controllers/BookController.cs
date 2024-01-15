//EntityFrameworkCore & EntityFrameworkCore.InMemory
//Automapper ve Automapper.Extensions.Microsoft.DependencyInjection
using _2_BookStore_EF_.BookOperations;
using _2_BookStore_EF_.DbOperations;
using _2_BookStore_EF_.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static _2_BookStore_EF_.BookOperations.CreateBookCommand;
using static _2_BookStore_EF_.BookOperations.GetBookIdQuery;
using static _2_BookStore_EF_.BookOperations.UpdateBookCommand;

namespace _1_BookStore_Tüm_endpointler_.Controllers;

[ApiController]
[Route("[controller]s")]    

public class BookController : ControllerBase
{
    private readonly BookStoreDbContext _context;

    private readonly IMapper _mapper;


    public BookController(BookStoreDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        GetBooksQuery query = new GetBooksQuery(_context,_mapper);
        var result = query.Handle();
        return Ok(result);
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id)                                                              
    {
        BookIdViewModel result;
        GetBookIdQuery query = new GetBookIdQuery(_context,_mapper);
        try
        {
            query.BookId = id;
            result=query.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok(result);
    }


    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookModel model)
    {
        CreateBookCommand commands = new CreateBookCommand(_context,_mapper);
        try
        {
            commands.Model = model;
            commands.Handle();
        }
        catch (Exception ex) 
        {
            return BadRequest(ex.Message);
        }
        
        return Ok();
    }


    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, UpdateBookModel updatedBook)
    {
        UpdateBookCommand command = new UpdateBookCommand(_context);
        try
        {
            command.BookId = id;
            command.Model = updatedBook;
            command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        DeleteBookCommand command = new DeleteBookCommand(_context);

        try
        {
            command.BookId = id;
            command.Handle();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }
}