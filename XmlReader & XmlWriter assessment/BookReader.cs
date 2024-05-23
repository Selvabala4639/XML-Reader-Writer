using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace XmlReader___XmlWriter_assessment
{
    public class BookReader
    {
        //This method is used to read xml and create object for BookCollection
        public static BookCollection ReadFromXml(string filePath)
        {
            //Create object for BookCollection 
            BookCollection books = new BookCollection();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            //This will initialize XML reader
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                // Iterate through each node of the xml document until there is no more nodes.
                while (reader.Read())
                {
                    //To check node type is whitspace
                    if (reader.NodeType == XmlNodeType.Whitespace)
                    {
                        continue;
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Books")
                    {
                        books = new BookCollection();
                        // Move to the next node
                        while (!(reader.NodeType == XmlNodeType.EndElement && reader.Name == "Books"))
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "book")
                            {
                                // Create Book object for each book element
                                Book newBook = new Book();
                                //Add book to the booklist of that object
                                books.BookList.Add(newBook);

                                while (!(reader.NodeType == XmlNodeType.EndElement && reader.Name == "book"))
                                {
                                    switch (reader.NodeType)
                                    {
                                        case XmlNodeType.Element:
                                            // If it's an element, check for its element name
                                            switch (reader.Name)
                                            {
                                                case "title":
                                                    //Store element content in a variable
                                                    string title = reader.ReadElementContentAsString();
                                                    //Print the content
                                                    Console.WriteLine("Title: " + title);
                                                    //Assign element content to the respective property in book object.
                                                    books.BookList[^1].Title = title;
                                                    break;
                                                case "author":
                                                    //Store element content in a variable
                                                    string author = reader.ReadElementContentAsString();
                                                    Console.WriteLine("Author: " + author);
                                                    books.BookList[^1].Author = author;
                                                    break;
                                                case "year":
                                                    //Store element content in a variable
                                                    int year = reader.ReadElementContentAsInt();
                                                    Console.WriteLine("Year: " + year);
                                                    books.BookList[^1].Year = year;
                                                    break;
                                                case "category":
                                                    //Store element content in a variable
                                                    CategoryType category = (CategoryType)Enum.Parse(typeof(CategoryType), reader.ReadElementContentAsString());
                                                    Console.WriteLine("Category: " + category);
                                                    books.BookList[^1].Category = category;
                                                    break;
                                                case "price":
                                                    //Store element content in a variable
                                                    double price = reader.ReadElementContentAsDouble();
                                                    Console.WriteLine("Price: " + price);
                                                    books.BookList[^1].Price = price;
                                                    Console.WriteLine();
                                                    break;
                                            }
                                            //Declare break statement if nodetype is not an element.
                                            break;
                                    }
                                    reader.Read();
                                }
                            }
                            reader.Read();
                        }
                    }
                }
            }
            //This will return a empty BookCollection
            return books;
        }
    }
}