//EntityFrameworkCore & EntityFrameworkCore.InMemory
//Automapper ve Automapper.Extensions.Microsoft.DependencyInjection
using _3_Bookstore_AutoMapper_FluentValidition_.DbOperations;
using _3_Bookstore_AutoMapper_FluentValidition_.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static _3_BookStore_AutoMapper_FluentValidition_.BookOperations.CreateBook.CreateBookCommand;
using static _3_BookStore_AutoMapper_FluentValidition_.BookOperations.GetIDBook.GetBookIdQuery;
using static _3_BookStore_AutoMapper_FluentValidition_.BookOperations.UpdateBook.UpdateBookCommand;
using _3_BookStore_AutoMapper_FluentValidition_.BookOperations.DeleteBook;
using _3_BookStore_AutoMapper_FluentValidition_.BookOperations.GetBook;
using _3_BookStore_AutoMapper_FluentValidition_.BookOperations.UpdateBook;
using _3_BookStore_AutoMapper_FluentValidition_.BookOperations.GetIDBook;
using _3_BookStore_AutoMapper_FluentValidition_.BookOperations.CreateBook;
using FluentValidation.Results;
using FluentValidation;

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
            GetBookIdQueryValidator validator = new GetBookIdQueryValidator();
            validator.ValidateAndThrow(query);
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

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(commands);

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
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);
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
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }
}