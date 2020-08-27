

using System;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using MyCouldBook.BookListManagement.BookList;
using System.Collections.ObjectModel;
using MyCouldBook.BookListManagement.RelationShipps;

namespace MyCouldBook.BookListManagement.BookList.Dtos
{	
	/// <summary>
	/// 的列表DTO
	/// <see cref="BookList"/>
	/// </summary>
    public class BookListListDto : CreationAuditedEntityDto<long> 
    {

        
		/// <summary>
		/// 书单名称
		/// </summary>
		[MaxLength(50, ErrorMessage="书单名称超出最大长度")]
		[MinLength(1, ErrorMessage="书单名称小于最小长度")]
		[Required(ErrorMessage="书单名称不能为空")]
		public string ListName { get; set; }



		/// <summary>
		/// 简介
		/// </summary>
		[MaxLength(200, ErrorMessage="简介超出最大长度")]
		[MinLength(10, ErrorMessage="简介小于最小长度")]
		public string Intro { get; set; }



		/// <summary>
		/// BookListAndBooks
		/// </summary>
		public List<BookListAndBook> BookListAndBooks { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}