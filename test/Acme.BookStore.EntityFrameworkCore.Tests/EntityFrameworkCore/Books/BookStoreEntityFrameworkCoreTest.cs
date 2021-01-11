using Acme.BookStore.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;
using Shouldly;

namespace Acme.BookStore.EntityFrameworkCore.Books
{
  public class BookStoreEntityFrameworkCoreTest : BookStoreEntityFrameworkCoreTestBase
  {

    private readonly IRepository<Book, Guid> _bookRespository;


    public BookStoreEntityFrameworkCoreTest()
    {
      _bookRespository = GetRequiredService<IRepository<Book, Guid>>();

 
    }

    const string BookName = "1984";

    [Fact]
    public async Task Should_GetAll_Name_Eques_CSharp()
    {
      await WithUnitOfWorkAsync(async () =>
      {
        var result = await _bookRespository.Where(b => b.Name == BookName).ToListAsync();
        Console.WriteLine(result);
        result.Count.ShouldBeGreaterThanOrEqualTo(0);
        result.ShouldContain(r => r.Name == BookName);
      });

    }

    [Fact]
    public async Task Should_CreateBook_Name_Is_CSharp()
    {
      var data = new Book() { Name = "哦多克", Type = (BookType)8, Price = 12, PublishDate = DateTime.Now };
      var result = await _bookRespository.InsertAsync(data);

      result.Id.ShouldNotBe(Guid.Empty);
      result.Name.ShouldBe("哦多克");
    }

    [Fact]
    public async Task Should_UpdateBook_CSharp_To_Go()
    {
      
      await WithUnitOfWorkAsync(async () =>
      {
        var data3 = await _bookRespository.GetListAsync();
        var result = await _bookRespository.InsertAsync(entity: new Book() { Name = "时间简史", Type = (BookType)8, Price = 12, PublishDate = DateTime.Now },true);
          var id = result.Id;
        var data = await _bookRespository.FirstOrDefaultAsync(s => s.Id == id);
        if (data!=null)
        {
          data.Name = "12";
          await _bookRespository.UpdateAsync(data, true);
        }
          var list = await _bookRespository.Where(s => s.Name == "12").ToListAsync();
          list.Count.ShouldBeGreaterThanOrEqualTo(1);
          list.ShouldContain(r => r.Name == "12");
                
      });
    }

    [Fact]
    public async Task Should_Remove_CSharpBook()
    {
     // await Should_CreateBook_Name_Is_CSharp();
      await WithUnitOfWorkAsync(async ()=>
      {
       
      var data = await _bookRespository.InsertAsync(new Book() { Name = "哦多克", Type = (BookType)8, Price = 12, PublishDate = DateTime.Now },true);
        await _bookRespository.DeleteAsync(s => s.Name == "哦多克", true);
        var result = await _bookRespository.FindAsync(b => b.Name == "哦多克");
        //result.Count.ShouldBeGreaterThanOrEqualTo(0);
        result.ShouldBeNull();
      });
      }

    [Fact]
    public async Task Should_CreateBook_With_Auth_YXX()
    {
      await WithUnitOfWorkAsync(async () =>
      {
        var data = await _bookRespository.InsertAsync(new Book { Name = "YXX", PublishDate = DateTime.Now, Type = (BookType)8, Price = 99 },true);

        var list = await _bookRespository.Where(s => s.Name == "YXX").ToListAsync();
            
           list.Count.ShouldBeGreaterThanOrEqualTo(1);
        list.ShouldContain(r => r.Name =="YXX");

      
        Assert.Equal(1, list.Count());

       });
    }

    [Fact]
    public async Task Should_GetBook_By_Auth_Is_YXX()
    {

    await   Should_CreateBook_With_Auth_YXX();
          await WithUnitOfWorkAsync(async () =>
      {
        var list = await _bookRespository.Where(s => s.Name == "YXX").ToListAsync();

        list.Count.ShouldBeGreaterThanOrEqualTo(0);
        list.ShouldContain(r => r.Name == "YXX");

      });

      }
  }
}

