using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Library_Core_Webapi.Models
{
	public class BookInsert
	{
		//書名
		public string BookName { get; set; }

		//作者
		public string BookAuthor { get; set; }

		//出版商
		public string BookPublisher { get; set; }

		//內容簡介
		public string Note { get; set; }

		//購書日期
		public DateTime BoughtDate { get; set; }

		//圖書類別
		public string BookClass { get; set; }
	}
}