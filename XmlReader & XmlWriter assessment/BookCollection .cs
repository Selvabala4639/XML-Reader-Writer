using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XmlReader___XmlWriter_assessment
{
    public class BookCollection 
    {
        //Property
        public List<Book> BookList { get; set; }
        //Constructor
        public BookCollection()
        {
            BookList = new List<Book>();
        }
        //This method will return BookCollection only with year provided by the user
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
        //This method will return BookCollection only with Category provided by the user
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