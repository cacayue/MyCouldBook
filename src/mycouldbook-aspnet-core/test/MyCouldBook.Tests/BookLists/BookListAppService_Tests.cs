
using MyCouldBook.BookListManagement.BookList;
using MyCouldBook.BookListManagement.BookList.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MyCouldBook.Tests.BookLists
{
    public class BookListAppService_Tests : MyCouldBookTestBase
    {
        private readonly IBookListAppService _bookListAppService;

        public BookListAppService_Tests()
        {
            _bookListAppService = Resolve<IBookListAppService>();
        }

        [Fact]
        public async Task CreateBookList_Test()
        {
            await _bookListAppService.CreateOrUpdate(new CreateOrUpdateBookListInput
            {
                 BookList = new BookListEditDto    
                {
						   

                            ListName = "test",
                            Intro = "test",


                }
            });

            await UsingDbContextAsync(async context =>
            {
                var dystopiaBookList = await context.BookLists.FirstOrDefaultAsync();
                dystopiaBookList.ShouldNotBeNull();
            }
            );
        }

        [Fact]
        public async Task GetBookLists_Test()
        {
            // Act
            var output = await _bookListAppService.GetPaged(new GetBookListsInput
            {
                MaxResultCount = 20,
                SkipCount = 0
            });

            // Assert
            output.Items.Count.ShouldBeGreaterThanOrEqualTo(0);
        }

		
							//// custom codes
									
							

							//// custom codes end


    }
}