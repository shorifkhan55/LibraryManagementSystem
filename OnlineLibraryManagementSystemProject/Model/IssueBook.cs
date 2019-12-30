using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystemProject.Model
{
    public class IssueBook
    {
        public int Id { get; set; }
        public Member Member { get; set; }
        public Book Book { get; set; }
        public string StartDate { get; set; }
        public string ReturnDate { get; set; }
    }
}