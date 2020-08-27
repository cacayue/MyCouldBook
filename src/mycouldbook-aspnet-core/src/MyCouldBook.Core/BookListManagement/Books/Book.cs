using Abp.Domain.Entities.Auditing;
using MyCouldBook.BookListManagement.RelationShipps;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCouldBook.BookListManagement.Books
{
    /// <summary>
    /// 书籍
    /// </summary>
    public class Book:CreationAuditedEntity<long>
    {
        /// <summary>
        /// 书名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 价格Url
        /// </summary>
        public string PriceUrl { get; set; }
        /// <summary>
        /// 图片Url
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Intro { get; set; }

        public virtual ICollection<BookAndBookTag> BookAndBookTags { get; set; }
        public virtual ICollection<BookListAndBook> BookListAndBooks { get; set; }
    }
}
