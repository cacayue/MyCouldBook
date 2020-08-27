
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.Collections.ObjectModel;
using MyCouldBook.BookListManagement.Books;


namespace  MyCouldBook.BookListManagement.Books.Dtos
{
	/// <summary>
	/// 的列表DTO
	/// <see cref="Book"/>
	/// </summary>
    public class BookEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// 书籍名称
		/// </summary>
		[MaxLength(50, ErrorMessage="书籍名称超出最大长度")]
		[MinLength(1, ErrorMessage="书籍名称小于最小长度")]
		[Required(ErrorMessage="书籍名称不能为空")]
		public string Name { get; set; }



		/// <summary>
		/// 作者
		/// </summary>
		[MaxLength(50, ErrorMessage="作者超出最大长度")]
		[MinLength(1, ErrorMessage="作者小于最小长度")]
		[Required(ErrorMessage="作者不能为空")]
		public string Author { get; set; }



		/// <summary>
		/// 购买链接
		/// </summary>
		[MinLength(10, ErrorMessage="购买链接小于最小长度")]
		public string PriceUrl { get; set; }



		/// <summary>
		/// 封面链接
		/// </summary>
		public string ImgUrl { get; set; }



		/// <summary>
		/// 简介
		/// </summary>
		[MaxLength(200, ErrorMessage="简介超出最大长度")]
		[MinLength(10, ErrorMessage="简介小于最小长度")]
		public string Intro { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}