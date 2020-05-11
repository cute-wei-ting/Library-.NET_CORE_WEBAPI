using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library_Core_Webapi.Service;
using Library_Core_Webapi.Models;

namespace Library_Core_Webapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
			private IBookService _bookservice;
			public BookController(IBookService bookService)
			{
				_bookservice = bookService;
			}

			[HttpGet]
			public async Task<IActionResult> GetDropdownList_Json([FromQuery]string type)
			{
			   List<CustomSelectListItem> BookSelectList = await _bookservice.GetDropdownList(type);
				return Ok(BookSelectList);
			}
			[HttpGet]
			public async Task<IActionResult> GetBookName()
			{
				List<string> BookName = await _bookservice.GetBookName();
				return Ok(BookName);

			}

			[HttpGet]
			public async Task<IActionResult> GetBooksGrid([FromQuery] BookSearch booksearch)
			{
				List<BookSearch> Grid = await _bookservice.SearchBook(booksearch);
				return Ok(Grid);
			}

			/*---------------------BookDetail---------------------*/
			[HttpGet("{id}")]
			public async Task<IActionResult> GetBookDetail(string id)
			{
				if (await _bookservice.IsIdExist(id))
				{
					BookUpdate bookdetail = await _bookservice.GetBookDetail(Convert.ToInt32(id));
					return Ok(bookdetail);
				}
				else return NotFound();
			}

			/*---------------------Insert---------------------*/
			[HttpPost]
			public async Task InsertBook([FromBody]BookInsert insertdata)
			{
				int InsertID = await _bookservice.InsertBook(insertdata); //test用
			}

		/*---------------------LENDRECORD---------------------*/

			[HttpGet("{id}")]
			public async Task<IActionResult> GetLendRecord(string id)
			{

				if (await _bookservice.IsIdExist(id))
				{
					List<BookRecord> bookRecord = await _bookservice.GetLendRecord(Convert.ToInt32(id));
					return Ok(bookRecord);
				}
				else return NotFound();
			}

			/*---------------------DELETE---------------------*/
			[HttpPost]
			public async Task<IActionResult> DeleteBook([FromBody]string id)
			{
				return Ok(await _bookservice.DecideDelete(id));
			}

			/*---------------------UPDATE---------------------*/
			[HttpGet("{id}")]
			public async Task<IActionResult> GetUpdateData(string id)
			{
				if (await _bookservice.IsIdExist(id))
				{
					BookUpdate bookupdate = await _bookservice.GetUpdateBook(Convert.ToInt32(id));
					return Ok(bookupdate);
				}
				else return NotFound();
			}

			[HttpPost]
			public async Task<IActionResult> UpdateBook([FromBody]BookUpdate bookUpdate, [FromQuery]string IniBookStatus, [FromQuery] string LaterBookStatus)
			{
				//借閱人借閱狀態關係
				if ((bookUpdate.BookStatusId == "B" || bookUpdate.BookStatusId == "C") && (bookUpdate.BookKeeperId == "" || bookUpdate.BookKeeperId == null))
				{
					return Ok("此借閱狀態,借閱人不能為空");
				}
				else
				{
					//insert 借閱紀錄 
					if ((IniBookStatus == "A" || IniBookStatus == "U") && (LaterBookStatus == "B" || LaterBookStatus == "C"))
					{
						LendRecordInsert lendRecordInsert = new LendRecordInsert();
						lendRecordInsert.BookKeeperId = bookUpdate.BookKeeperId;
						lendRecordInsert.BookID = Convert.ToInt32(bookUpdate.BookID);

						await _bookservice.InsertLendRecord(lendRecordInsert);

					}
					//update 書本資料
						await _bookservice.UpdateBook(bookUpdate);
					return Ok("編輯成功");
				}
			}
	}
}
