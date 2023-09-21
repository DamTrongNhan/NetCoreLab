using AutoMapper;
using NetCore5Api.Data;
using NetCore5Api.Models;

namespace NetCore5Api.Helpers
{
    public class ApplicationMapper : Profile
    { 
        public ApplicationMapper()
        {
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}
