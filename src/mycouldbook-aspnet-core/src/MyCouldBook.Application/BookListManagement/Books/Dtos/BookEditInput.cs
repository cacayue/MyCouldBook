using System;
using System.Collections.Generic;
using System.Text;

namespace MyCouldBook.BookListManagement.Books.Dtos
{
    public class BookEditInput
    {
        public long? Id { get; set; }
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
    }
}
