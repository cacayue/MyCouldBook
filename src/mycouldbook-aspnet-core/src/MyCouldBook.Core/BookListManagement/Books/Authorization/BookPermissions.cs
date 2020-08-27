using System;
using System.Collections.Generic;
using System.Text;

namespace MyCouldBook.BookListManagement.Books.Authorization
{
    /// <summary>
    /// 对书籍权限的声明
    /// </summary>
    public static class BookPermissions
    {
        public const string BookManager = "Page.BookManager";
        public const string Query = "Page.Book.Query";
        public const string Create = "Page.Book.Create";
        public const string Edit = "Page.Book.Edit";
        public const string Delete = "Page.Book.Delete";
        public const string BatchDelete = "Page.Book.BatchDelete";

    }
}
