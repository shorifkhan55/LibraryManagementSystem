using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineLibraryManagementSystemProject.BLL;
using OnlineLibraryManagementSystemProject.Model;

namespace OnlineLibraryManagementSystemProject
{
    public partial class AdminBookingIssuing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataBind();
            }
        }
        MemberManager memberManager = new MemberManager();
        BookManager bookManager = new BookManager();
        protected void goButton_Click(object sender, EventArgs e)
        {
            if (memberIdTextBox.Text!="" && bookIdTextBox.Text!="")
            {
               
                int memberId = Convert.ToInt32(memberIdTextBox.Text);
                Member member = memberManager.GetMemberForAdmin(memberId);

               
                int bookId = Convert.ToInt32(bookIdTextBox.Text);
                Book book = bookManager.GetBookInfoById(bookId);
                if  (memberId==member.Id && bookId==book.BookId)
                {
                    memberNameTextBox.Text = member.FullName;
                    bookNameTextBox.Text = book.Name;
                    
                }
                else
                {
                    Response.Write("<script>alert('Please Insert Right Book Id and Member Id');</script>");
                }
            }

            else
            {
                Response.Write("<script>alert('Please Insert Book Id and Member Id');</script>");
            }
        }
        IssuedBookManager issuedBookManager=new IssuedBookManager();
        protected void IssueButton_Click(object sender, EventArgs e)
        {
            if (memberIdTextBox.Text != "" && bookIdTextBox.Text != "")
            {

                IssueBook issueBook = new IssueBook();
                Book book = new Book();
                Member member = new Member();
                member.Id = Convert.ToInt32(memberIdTextBox.Text);
                issueBook.Member = member;
                book.BookId = Convert.ToInt32(bookIdTextBox.Text);
                issueBook.Book = book;
                issueBook.StartDate = startDateTextBox.Text;
                issueBook.ReturnDate = returnDateTextBox.Text;
                if (memberManager.GetMemberForIssuedBook(member.Id)==true && bookManager.CheckBookCurrentStock(book.BookId)==true)
                {
                    if (!issuedBookManager.CheckIssuedBookExisting(member.Id,book.BookId))
                    {
                        string message = issuedBookManager.IssuedBook(issueBook);
                        string message2 = bookManager.UpdateBookForCurrentStock(book);
                        Response.Write("<script>alert('" + message + "');</script>");
                        GridView1.DataBind();
                        Clean();
                    }
                    else
                    {
                        Response.Write("<script>alert('This Member Already Has The book');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please Insert Book Id and Member Id or Book Stock out');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Please Insert Book Id and Member Id');</script>");
            }
        }
        protected void ReturnButton_Click(object sender, EventArgs e)
        {
            if (memberIdTextBox.Text != "" && bookIdTextBox.Text != "")
            {

                IssueBook issueBook = new IssueBook();
                Book book = new Book();
                Member member = new Member();
                member.Id = Convert.ToInt32(memberIdTextBox.Text);
                issueBook.Member = member;
                book.BookId = Convert.ToInt32(bookIdTextBox.Text);
                issueBook.Book = book;
                issueBook.StartDate = startDateTextBox.Text;
                issueBook.ReturnDate = returnDateTextBox.Text;
                if (memberManager.GetMemberForIssuedBook(member.Id) == true && bookManager.CheckBookCurrentStock(book.BookId) == true)
                {
                        string message = issuedBookManager.ReturnBook(member.Id,book.BookId);
                        string message2 = bookManager.UpdateCurrentStockForReturn(book.BookId);
                        Response.Write("<script>alert('" + message + "');</script>");
                        GridView1.DataBind();
                  
                }
                else
                {
                    Response.Write("<script>alert('wrong Book Id and Member Id ');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Please Insert Book Id and Member Id');</script>");
            }
        }
        public void Clean()
        {
            memberIdTextBox.Text = "";
            memberIdTextBox.Text = "";
            bookIdTextBox.Text = "";
            bookNameTextBox.Text = "";
            startDateTextBox.Text = "";
            returnDateTextBox.Text = "";
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType== DataControlRowType.DataRow)
            {
                //check your condition here
                DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                DateTime today=DateTime.Today;
                if (today>dt)
                {
                    e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                }
            }
            else
            {
                
            }
        }
    }
}