using System;
using XmlReader___XmlWriter_assessment;

namespace XmlReadeXml_Writer;
class Program{
    public static void Main(string[] args)
    {
         string filePath = "Books.xml";
        BookCollection allBooks = BookReader.ReadFromXml(filePath);

        // Retrieve a subset of BookCollection using the methods defined in BookCollection class
        BookCollection subsetByYear = allBooks.GetBooksByYear(1980);
        BookCollection subsetByCategory = allBooks.GetBooksByCategory(CategoryType.Programming);

        // Save the retrieved subset of collection into a XML file
        BookWriter.WriteToXml(subsetByYear, "subset_by_year1980.xml");
        BookWriter.WriteToXml(subsetByCategory, "subset_by_category_Programming.xml");
    }
}
