using Abp.Domain.Entities.Auditing;
using MyCouldBook.BookListManagement.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCouldBook.BookListManagement.RelationShipps
{
    public class BookListAndBook:CreationAuditedEntity<long>
    {
        public long BookListId { get; set; }

        public BookList.BookList BookList { get; set; }

        public long BookId { get; set; }

        public Book Book { get; set; }
    }
}
