using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library_Core_Webapi.Models
{
	public class BookUpdate
	{

		//ID
		public string BookID { get; set; }

		//書名
		public string BookName { get; set; }

		//作者
		public string BookAuthor { get; set; }

		//出版商
		public string BookPublisher { get; set; }

		//內容簡介
		public string Note { get; set; }

		//購書日期
		public string BoughtDate { get; set; }

		//圖書類別
		public string BookClassId { get; set; }

		//借閱狀態
		public string BookStatusId { get; set; }

		//借閱人
		public string BookKeeperId { get; set; }
	}
}