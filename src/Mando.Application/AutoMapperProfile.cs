using AutoMapper;
using Mando.App.Authors;
using Mando.App.Books;

namespace Mando
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Author, AuthorDto>();

            CreateMap<Book, BookDto>();

            CreateMap<Author, AuthorLookupDto>();
        }
    }
}
