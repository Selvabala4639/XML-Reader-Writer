using System;
using XmlReader___XmlWriter_assessment;

namespace XmlReadeXmlWriter;
class Program{
    public static void Main(string[] args)
    {
        string filePath = "Books.xml";
        Console.WriteLine($"Printing all books in the XML file.");
        Console.WriteLine($"------------------------------------\n");
        
        BookCollection allBooks = BookReader.ReadFromXml(filePath);
        //Read the XML file & populate the BookCollection.
        int selectYear;
        int checkYear;
        bool isValidYear =false;
        //TryParse method to check whether user entered 4 digit number
        do{
            Console.Write($"Enter Year categorize books: ");
            isValidYear = int.TryParse(Console.ReadLine(),null, out selectYear);
            checkYear = selectYear.ToString().Length;
            if(!isValidYear || checkYear !=4)
            {
                Console.WriteLine($"Invalid year. Enter again");
            }
        }while(isValidYear==false || checkYear !=4);
        
        CategoryType selectCategory;
        bool validCategory = false;
        //tryParse method to check whether user entered correct Category 
        do{
            Console.WriteLine(@"Book Categories
                1. Historical,
                2. Fantasy,
                3. Study,
                4. Programming,
                5. Engineering");
            Console.Write($"Enter book category from the above Categories:");
            validCategory = Enum.TryParse<CategoryType>(Console.ReadLine(),true,out selectCategory);
            if(!validCategory)
            {
                Console.WriteLine($"Invalid category. Enter again");
            }
        }while(validCategory==false);
        
        //Retrieve a subset of BookCollection using the methods defined in BookCollection class.
        BookCollection subsetByYear = allBooks.GetBooksByYear(selectYear);
        BookCollection subsetByCategory = allBooks.GetBooksByCategory(selectCategory);

        // Save the retrieved subset of collection into a new XML file
        BookWriter.WriteToXml(subsetByYear, "Books published in "+selectYear+".xml");
        BookWriter.WriteToXml(subsetByCategory, "Books under category "+selectCategory+".xml");
    }
}
