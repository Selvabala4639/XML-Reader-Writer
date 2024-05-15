using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XmlReader___XmlWriter_assessment
{
    public enum CategoryType{
        Historical,
        Fantasy,
        Study,
        Programming,
        Engineering
    }
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public CategoryType Category { get; set; }
        public double Price { get; set; }
    }
}