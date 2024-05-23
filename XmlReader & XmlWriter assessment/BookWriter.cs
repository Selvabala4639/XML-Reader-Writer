using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace XmlReader___XmlWriter_assessment
{
    public class BookWriter
    {   
         public static void WriteToXml(BookCollection books, string filePath)
        {
            // Create XmlWriterSettings for more control over how the XML is written
            XmlWriterSettings settings = new XmlWriterSettings();
            //Set XML indent to true for readability
            settings.Indent = true; 

            // Create an XmlWriter instance
            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                // Write the XML declaration/prolog
                writer.WriteStartDocument();
                
                // Write the root element
                writer.WriteStartElement("Books");

                // Write each book to xml file
                foreach (var book in books.BookList)
                {
                    writer.WriteStartElement("book");

                    // Write individual elements
                    //Pass parameters as starting element and element content
                    WriteElement(writer, "title", book.Title);
                    WriteElement(writer, "author", book.Author);
                    WriteElement(writer, "year", book.Year.ToString());
                    WriteElement(writer, "category", book.Category.ToString());
                    WriteElement(writer, "price", book.Price.ToString());

                    writer.WriteEndElement(); // End Book element
                }
                writer.WriteEndElement(); // End Books element
                writer.WriteEndDocument(); //End XML Declaration
            }
        }
        //Method to write an XML element with a specified starting element and element content
        private static void WriteElement(XmlWriter writer, string elementName, string elementContent)
        {
            writer.WriteStartElement(elementName);
            writer.WriteString(elementContent);
            writer.WriteEndElement();
        }
    }
}