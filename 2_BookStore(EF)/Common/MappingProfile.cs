using _2_BookStore_EF_.BookOperations;
using _2_BookStore_EF_.Entities;
using AutoMapper;
using static _2_BookStore_EF_.BookOperations.CreateBookCommand;
using static _2_BookStore_EF_.BookOperations.GetBookIdQuery;

namespace _2_BookStore_EF_.Common
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
