using Acme.BookStore.Books;
using Acme.BookStore.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
  public class BookAppService : CrudAppService<Book, BookDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto>, IBookAppService
  {
    public BookAppService(IRepository<Book, Guid> repository) : base(repository)
    {
      GetPolicyName = BookStorePermissions.Books.Default;
      GetListPolicyName = BookStorePermissions.Books.Default;
      CreatePolicyName = BookStorePermissions.Books.Create;
      UpdatePolicyName = BookStorePermissions.Books.Edit;
      DeletePolicyName = BookStorePermissions.Books.Delete;

    }

  }
}
