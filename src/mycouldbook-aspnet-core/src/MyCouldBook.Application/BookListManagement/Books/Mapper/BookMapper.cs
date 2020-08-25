using AutoMapper;
using MyCouldBook.BookListManagement.Books.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCouldBook.BookListManagement.Books.Mapper
{
    internal class BookMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<Book, BookListDto>();
            mapper.CreateMap<BookEditInput, Book>();
        }
    }
}
