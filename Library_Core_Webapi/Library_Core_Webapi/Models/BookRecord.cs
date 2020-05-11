using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library_Core_Webapi.Models
{
	public class BookRecord
	{
		//借閱日期
		public string LendDate { get; set; }
		//借閱人員編號
		public string BookKeeperId { get; set; }
		//英文姓名
		public string UserEname { get; set; }
		//中文姓名
		public string UserCname { get; set; }
	}
}
