using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Library_Core_Webapi.Models
{
	public class BookSearch
	{
		//書ID
		public int BookID { get; set; }
		//書名
		public string BookName { get; set; }
		//圖書類別
		public string BookClassId { get; set; }
		//借閱人
		public string BookKeeperId { get; set; }
		//借閱狀態
		public string BookStatusId { get; set; }
		//購書日期
		public string BoughtDate { get; set; }
	}
}