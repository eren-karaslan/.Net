using _3_Bookstore_AutoMapper_FluentValidition_.Entities;
using _3_BookStore_AutoMapper_FluentValidition_.BookOperations.GetBook;
using AutoMapper;
using static _3_BookStore_AutoMapper_FluentValidition_.BookOperations.CreateBook.CreateBookCommand;
using static _3_BookStore_AutoMapper_FluentValidition_.BookOperations.GetIDBook.GetBookIdQuery;

namespace _3_Bookstore_AutoMapper_FluentValidition_.Common
{
    public class MappingProfile:Profile
    { 
        public MappingProfile() 
        {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book, BookIdViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
