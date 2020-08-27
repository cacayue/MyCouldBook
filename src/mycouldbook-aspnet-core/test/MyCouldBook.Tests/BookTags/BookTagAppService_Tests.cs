
using MyCouldBook.BookListManagement.BookTag;
using MyCouldBook.BookListManagement.BookTag.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MyCouldBook.Tests.BookTags
{
    public class BookTagAppService_Tests : MyCouldBookTestBase
    {
        private readonly IBookTagAppService _bookTagAppService;

        public BookTagAppService_Tests()
        {
            _bookTagAppService = Resolve<IBookTagAppService>();
        }

        [Fact]
        public async Task CreateBookTag_Test()
        {
            await _bookTagAppService.CreateOrUpdate(new CreateOrUpdateBookTagInput
            {
                 BookTag = new BookTagEditDto    
                {
						   

                            TagName = "test",


                }
            });

            await UsingDbContextAsync(async context =>
            {
                var dystopiaBookTag = await context.BookTags.FirstOrDefaultAsync();
                dystopiaBookTag.ShouldNotBeNull();
            }
            );
        }

        [Fact]
        public async Task GetBookTags_Test()
        {
            // Act
            var output = await _bookTagAppService.GetPaged(new GetBookTagsInput
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