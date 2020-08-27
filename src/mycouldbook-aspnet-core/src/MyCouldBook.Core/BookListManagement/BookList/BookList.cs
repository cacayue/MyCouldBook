using Abp.Domain.Entities.Auditing;
using MyCouldBook.BookListManagement.RelationShipps;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCouldBook.BookListManagement.BookList
{
    /// <summary>
    /// 书单
    /// </summary>
    public class BookList:CreationAuditedEntity<long>
    {
        /// <summary>
        /// 书单名称
        /// </summary>
        public string ListName { get; set; }
        /// <summary>
        /// 书单简介
        /// </summary>
        public string Intro { get; set; }

        public virtual ICollection<BookListAndBook> BookListAndBooks { get; set; }
    }
}
