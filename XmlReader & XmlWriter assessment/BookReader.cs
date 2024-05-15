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
        public static BookCollection ReadFromXml(string filePath)
        {
            BookCollection books = new BookCollection();

            using (XmlReader reader = XmlReader.Create(filePath))
            {
                // Read the XML until there are no more nodes
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Whitespace || reader.NodeType == XmlNodeType.SignificantWhitespace)
                    {
                        continue;
                    }
                    // Check the node type
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            // If it's an element, switch on its name
                            switch (reader.Name)
                            {
                                case "book":
                                    // Handle the book element
                                    //Console.WriteLine("Book:");
                                    Book newBook = new Book();
                                    books.BookList.Add(newBook);
                                    break;
                                case "title":
                                    // Handle the title element
                                    if (reader.NodeType == XmlNodeType.Whitespace || reader.NodeType == XmlNodeType.SignificantWhitespace)
                                    {
                                        continue;
                                    }
                                    // Console.WriteLine("Title: " + reader.ReadElementContentAsString());
                                    // books.BookList[^1].Title = reader.ReadElementContentAsString();
                                    string title = reader.ReadElementContentAsString();
                                    Console.WriteLine("Title: " + title);
                                    books.BookList[^1].Title = title;
                                    break;
                                case "author":
                                    // Handle the author element
                                    
                                    string author = reader.ReadElementContentAsString();
                                    Console.WriteLine("Author: " + author);
                                    books.BookList[^1].Author = author;
                                    break;
                                case "year":
                                    // Handle the year element
                                    // Console.WriteLine("Year: " + reader.ReadElementContentAsInt());
                                    // books.BookList[^1].Year = reader.ReadElementContentAsInt();
                                    int year = reader.ReadElementContentAsInt();
                                    Console.WriteLine("Year: " + year);
                                    books.BookList[^1].Year = year;
                                    break;
                                case "category":
                                    //Console.WriteLine("Category: " + reader.ReadElementContentAsString());
                                    CategoryType category = (CategoryType)Enum.Parse(typeof(CategoryType), reader.ReadElementContentAsString());
                                    Console.WriteLine("Category: " + category);
                                    books.BookList[^1].Category = category;
                                    break;
                                case "price":
                                    // Console.WriteLine("Price: " + reader.ReadElementContentAsDouble());
                                    // books.BookList[^1].Price = reader.ReadElementContentAsInt();
                                    double price = reader.ReadElementContentAsDouble();
                                    Console.WriteLine("Price: " + price);
                                    books.BookList[^1].Price = price;
                                    Console.WriteLine();
                                    break;
                                    // Add cases for handling other elements as needed
                            }
                            break;
                            // Add cases for handling other node types as needed
                    }
                }
            }
            return books;
        }
    }
}