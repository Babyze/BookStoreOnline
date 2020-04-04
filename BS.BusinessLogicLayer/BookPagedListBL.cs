using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS.BusinessObjectLayer;
using BS.DataAcessLayer;

namespace BS.BusinessLogicLayer
{
    public class BookPagedListBL
    {
		private readonly BookDB BookDB = null;
		public int CurrentPage { get; private set; }
		public int TotalPages { get; private set; }
		public int PageSize { get; private set; }
		public int TotalCount { get; private set; }

		public bool HasPrevious => CurrentPage > 1;
		public bool HasNext => CurrentPage < TotalPages;
		public int GenreId { private get; set; }

		public BookPagedListBL(bool sale, PagingParameter pagingParameter)
		{
			BookDB = new BookDB();
			TotalCount = BookDB.TotalBook(sale);
			CurrentPage = pagingParameter.PageNumber;
			PageSize = pagingParameter.PageSize;
			TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
		}

		public BookPagedListBL(int GenreId, PagingParameter pagingParameter)
		{
			BookDB = new BookDB();
			this.GenreId = GenreId;
			TotalCount = BookDB.TotalBook(GenreId);
			CurrentPage = pagingParameter.PageNumber;
			PageSize = pagingParameter.PageSize;
			TotalPages = (int)Math.Ceiling(TotalCount / (double) PageSize);
		}

		public BookPagedListBL(string BookName, PagingParameter pagingParameter)
		{
			BookDB = new BookDB();
			TotalCount = BookDB.TotalBook(BookName);
			CurrentPage = pagingParameter.PageNumber;
			PageSize = pagingParameter.PageSize;
			TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
		}

		public IEnumerable<Book> GetBookPagedList()
		{
			return BookDB.GetAll(CurrentPage, PageSize);
		}

		public IEnumerable<Book> GetBookPagedList(string BookName)
		{
			return BookDB.GetBookByName(BookName, CurrentPage, PageSize);
		}

		public IEnumerable<Book> GetBookByGenrePagedList()
		{
			return BookDB.GetAll(GenreId, CurrentPage, PageSize);
		}

		public IEnumerable<Book> GetSaleBooks()
		{
			return BookDB.GetAllBookSale(CurrentPage, PageSize);
		}

		public object PagingMetaData()
		{
			object PagingMetaData = new
			{
				TotalCount,
				CurrentPage,
				TotalPages,
				PageSize,
				HasNext,
				HasPrevious
			};
			return PagingMetaData;
		}
	}
}
