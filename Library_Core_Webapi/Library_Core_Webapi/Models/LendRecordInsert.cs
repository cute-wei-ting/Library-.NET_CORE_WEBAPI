using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library_Core_Webapi.Models
{
	public class LendRecordInsert
	{
		//書ID
		public int BookID { get; set; }
		//借閱人
		public string BookKeeperId { get; set; }
		//借閱日期
		public string LendDate { get; set; }
		//建立日期
		public string CreDate { get; set; }
		//建立使用者
		public string CreUsr { get; set; }
		//修改日期
		public string ModDate { get; set; }
		//修改使用者"
		public string ModUsr { get; set; }
	}
}