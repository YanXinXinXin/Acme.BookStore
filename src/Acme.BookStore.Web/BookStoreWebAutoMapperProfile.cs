using AutoMapper;

namespace Acme.BookStore.Web
{
    public class BookStoreWebAutoMapperProfile : Profile
    {
        public BookStoreWebAutoMapperProfile()
        {
      //Define your AutoMapper configuration here for the Web project.在这里定义Web项目的自动映射器配置。

      //注意，由于我们仅在该层中需要映射定义，因此我们将其作为在Web层中的最佳实践进行。
      CreateMap<BookDto, CreateUpdateBookDto>();
        }
    }
}
