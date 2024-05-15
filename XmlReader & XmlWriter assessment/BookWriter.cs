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
        settings.Indent = true; // Indent the XML for readability

        // Create an XmlWriter instance
        using (XmlWriter writer = XmlWriter.Create(filePath, settings))
        {
            // Write the XML declaration
            writer.WriteStartDocument();

            // Write the root element
            writer.WriteStartElement("Books");

            // Write each book
            foreach (var book in books.BookList)
            {
                writer.WriteStartElement("Book");

                // Write individual elements
                WriteElement(writer, "Title", book.Title);
                WriteElement(writer, "Author", book.Author);
                WriteElement(writer, "Year", book.Year.ToString());
                WriteElement(writer, "Category", book.Category.ToString());
                WriteElement(writer, "Price", book.Price.ToString());

                writer.WriteEndElement(); // End Book element
            }
            writer.WriteEndElement(); // End Books element
            writer.WriteEndDocument();
        }
    }

    // Helper method to write an XML element with a specified name and value
    private static void WriteElement(XmlWriter writer, string name, string value)
    {
        writer.WriteStartElement(name);
        writer.WriteString(value);
        writer.WriteEndElement();
    }
    }
}