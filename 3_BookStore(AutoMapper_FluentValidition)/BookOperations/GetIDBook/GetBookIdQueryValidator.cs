using FluentValidation;

namespace _3_BookStore_AutoMapper_FluentValidition_.BookOperations.GetIDBook
{
    public class GetBookIdQueryValidator:AbstractValidator<GetBookIdQuery>
    {
        public GetBookIdQueryValidator()
        {
            RuleFor(query => query.BookId).GreaterThan(0);
        }
    }
}
