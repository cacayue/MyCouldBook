
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.Collections.ObjectModel;
using MyCouldBook.BookListManagement.BookTag;


namespace  MyCouldBook.BookListManagement.BookTag.Dtos
{
	/// <summary>
	/// 的列表DTO
	/// <see cref="BookTag"/>
	/// </summary>
    public class BookTagEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// 标签名称
		/// </summary>
		[MaxLength(50, ErrorMessage="标签名称超出最大长度")]
		[Required(ErrorMessage="标签名称不能为空")]
		public string TagName { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}