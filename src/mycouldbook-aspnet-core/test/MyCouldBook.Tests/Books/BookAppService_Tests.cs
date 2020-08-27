
using MyCouldBook.BookListManagement.Books;
using MyCouldBook.BookListManagement.Books.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;

namespace MyCouldBook.Tests.Books
{
    public class BookAppService_Tests : MyCouldBookTestBase
    {
        private readonly IBookAppService _bookAppService;

        public BookAppService_Tests()
        {
            _bookAppService = Resolve<IBookAppService>();
        }

        [Fact]
        public async Task CreateBook_Test()
        {
            await _bookAppService.CreateOrUpdate(new CreateOrUpdateBookInput
            {
                 Book = new BookEditDto    
                {
						   

                            Name = "test",
                            Author = "test",
                            PriceUrl = "test",
                            ImgUrl = "test",
                            Intro = "test",


                }
            });

            await UsingDbContextAsync(async context =>
            {
                var dystopiaBook = await context.Books.FirstOrDefaultAsync();
                dystopiaBook.ShouldNotBeNull();
            }
            );
        }

        [Fact]
        public async Task GetBooks_Test()
        {
            // Act
            var output = await _bookAppService.GetPaged(new GetBooksInput
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