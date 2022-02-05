using AutoMapper;
using Mando.App.Store;

namespace Mando
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Author, AuthorDto>().MapExtraProperties();

            CreateMap<Book, BookDto>();

            CreateMap<Author, AuthorLookupDto>();
        }
    }
}
