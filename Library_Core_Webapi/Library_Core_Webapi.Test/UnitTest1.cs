using Library_Core_Webapi.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Library_Core_Webapi.Test
{
	[TestFixture]
	public class BookServiceTests
	{
		private static BookService _bookService;
		private static int InsertId = 0;
		private static Models.BookInsert InsertData = new Models.BookInsert
		{
			BookName = "TestInsertBook",
			BookAuthor = "Marz",
			BookPublisher = "南一",
			Note = "112233",
			BoughtDate = DateTime.Parse("2019/03/15"),
			BookClass = "BK"
		};

		[SetUp]
		public void Setup()
		{
			var config = new ConfigurationBuilder()
	                    .AddJsonFile("appsettings.json")
						.Build();
			_bookService = new BookService(config);
		}

		[Test,Order(1)]
		public async Task TestInsertBook_returnInsertId()
		{
			InsertId = await _bookService.InsertBook(InsertData);
			Console.WriteLine("InsertBookId : " + InsertId);
			Assert.AreNotEqual(0, InsertId);
		}
		[Test, Order(2)]
		public async Task TestGetUpdateBook_InputInsertId_returnInsertData()
		{
			Models.BookUpdate GetData = await _bookService.GetUpdateBook(InsertId);
			Console.WriteLine("UpdateId : " + InsertId);
			Assert.AreEqual(InsertData.BookName, GetData.BookName);
			Assert.AreEqual(InsertData.BookAuthor, GetData.BookAuthor);
			Assert.AreEqual(InsertData.BookPublisher, GetData.BookPublisher);
			Assert.AreEqual(InsertData.Note, GetData.Note);
			Assert.AreEqual(InsertData.BoughtDate.ToString("yyyy/MM/dd"), GetData.BoughtDate);
			Assert.AreEqual(InsertData.BookClass, GetData.BookClassId);
		}
		[Test, Order(3)]
		public async Task TestUpdatetBook_InputInsertId_returnnothing()
		{
			Console.WriteLine("UpdateBookId : " + InsertId);
			Models.BookUpdate UpdateData = new Models.BookUpdate
			{
				BookID = Convert.ToString(InsertId),
				BookName = "TestUpdateBook",
				BookAuthor = "Marz",
				BookPublisher = "南一",
				Note = "112233",
				BoughtDate = "2019/03/15",
				BookClassId = "BK",
				BookStatusId = "A",
				BookKeeperId = null
			};
			await _bookService.UpdateBook(UpdateData);
			Models.BookUpdate GetData = await _bookService.GetUpdateBook(InsertId);
			Assert.AreEqual(UpdateData.BookName, GetData.BookName);
			Assert.AreEqual(UpdateData.BookAuthor, GetData.BookAuthor);
			Assert.AreEqual(UpdateData.BookPublisher, GetData.BookPublisher);
			Assert.AreEqual(UpdateData.Note, GetData.Note);
			Assert.AreEqual(UpdateData.BoughtDate, GetData.BoughtDate);
			Assert.AreEqual(UpdateData.BookClassId, GetData.BookClassId);
			Assert.AreEqual(UpdateData.BookStatusId, GetData.BookStatusId);
			Assert.AreEqual(UpdateData.BookKeeperId, GetData.BookKeeperId);
		}

		[Test, Order(4)]
		public async Task TestDeleteBook_InputInsertId_returnDeleteString()
		{
			{
				string IfDelete = await _bookService.DecideDelete(Convert.ToString(InsertId));
				Console.WriteLine("DeleteId : " + InsertId);

				Assert.AreEqual("刪除成功", IfDelete);
				Assert.IsNull(await _bookService.GetUpdateBook(InsertId));
			}
		}

	}
}