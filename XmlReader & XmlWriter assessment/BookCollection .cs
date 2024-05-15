using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XmlReader___XmlWriter_assessment
{
    public class BookCollection 
    {
        public List<Book> BookList { get; set; }

        public BookCollection()
        {
            BookList = new List<Book>();
        }
        public BookCollection GetBooksByYear(int year) 
        {
            BookCollection result = new BookCollection();
            foreach(var book in BookList)
            {
                if(book.Year == year)
                {
                    result.BookList.Add(book);
                }
            }
            return result;
        }

        public BookCollection GetBooksByCategory(CategoryType category) 
        {
            BookCollection result  = new BookCollection();
            foreach(var book in BookList)
            {
                if(book.Category == category)
                {
                    result.BookList.Add(book);
                }
            }
            return result;
        }
    }
}