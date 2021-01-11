using System;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc;

namespace Acme.BookStore.Web.Pages.Books
{
  public class EditModalModel : BookStorePageModel
  {
    //[HiddenInput]和[BindProperty]是标准的ASP.NET Core MVC的属性。
    //SupportsGet用于能够从请求的查询字符串参数获取Id值。
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateUpdateBookDto Book { get; set; }

    private readonly IBookAppService _bookAppService;

    public EditModalModel(IBookAppService bookAppService)
    {
      _bookAppService = bookAppService;
    }

    public async Task OnGetAsync()
    {
      var bookDto = await _bookAppService.GetAsync(Id);
      Book = ObjectMapper.Map<BookDto, CreateUpdateBookDto>(bookDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
      await _bookAppService.UpdateAsync(Id, Book);
      return NoContent();
    }
  }
}
