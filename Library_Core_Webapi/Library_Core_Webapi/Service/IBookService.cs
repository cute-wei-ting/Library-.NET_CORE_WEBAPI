using Library_Core_Webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Core_Webapi.Service
{
	public interface IBookService
	{
		Task<bool> IsIdExist(string id);
		Task<List<CustomSelectListItem>> GetDropdownList(string option);
		Task<List<string>> GetBookName();

		Task<string> DecideDelete(string BookID);
		Task<BookUpdate> GetBookDetail(int id);
		Task<List<BookRecord>> GetLendRecord(int BookId);
		Task<BookUpdate> GetUpdateBook(int id);
		Task<int> InsertBook(BookInsert insertdata);
		Task InsertLendRecord(LendRecordInsert insertdata);
		Task<List<BookSearch>> SearchBook(BookSearch searchdata);
		Task UpdateBook(BookUpdate updatedata);
	}
}
