using Abp.Domain.Entities;
using MyCouldBook.BookListManagement.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCouldBook.BookListManagement.RelationShipps
{
    public class BookAndBookTag:Entity<long>
    {
        public long BookId { get; set; }

        public virtual Book Book { get; set; }

        public long TagId { get; set; }
        public virtual BookTag.BookTag BookTag { get; set; }
    }
}
