using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystemProject.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Date { get; set; }
        public string Language { get; set; }
        public Author Author { get; set; }
        public  Publisher Publisher { get; set; }
        public string Edition { get; set; }
        public string BookCost { get; set; }
        public string NoOfPage { get; set; }
        public string Description { get; set; }
        public string ActualStock { get; set; }
        public string CurrentStock { get; set; }
        public string BookImgLink { get; set; }
    }
}