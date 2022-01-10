using AutoMapper;
using Mando.App.Authors;

namespace Mando
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Author, AuthorDto>();
        }
    }
}
