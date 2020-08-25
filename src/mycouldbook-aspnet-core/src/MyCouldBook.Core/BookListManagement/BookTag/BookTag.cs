
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCouldBook.BookListManagement.BookTag
{
    /// <summary>
    /// 标签
    /// </summary>
    public class BookTag: CreationAuditedEntity<long>
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        public string TagName { get; set; }
    }
}
