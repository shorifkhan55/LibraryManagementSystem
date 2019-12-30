using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineLibraryManagementSystemProject.BLL;
using OnlineLibraryManagementSystemProject.Model;

namespace OnlineLibraryManagementSystemProject
{
    public partial class BookInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllAuthor();
                LoadAllPublisher();
                GridView1.DataBind();
            }
        }

        public void LoadAllAuthor()
        {
            AuthorManager authorManager=new AuthorManager();
            List<Author> authors = authorManager.GetAllAuthors();
            authorDropDownList.DataSource = authors;
            authorDropDownList.DataTextField = "AuthorName";
            authorDropDownList.DataValueField = "AuthorId";
            authorDropDownList.DataBind();
            //authorDropDownList.Items.Insert(0, new ListItem("Select", "NA"));

        }

        public void LoadAllPublisher()
        {
            PublisherManager publisherManager=new PublisherManager();
            publisherDropDownList.DataSource = publisherManager.GetAllPublishers();
            publisherDropDownList.DataTextField = "PublisherName";
            publisherDropDownList.DataValueField = "PublisherId";

            publisherDropDownList.DataBind();
            publisherDropDownList.Items.Insert(0,new ListItem("Select","Select"));
        }
        BookManager bookManager=new BookManager();
        private Book book;
        protected void AddButton_Click(object sender, EventArgs e)
        {
            if (bookNameTextBox.Text!="")
            {
                string genres = "";
                foreach (int i in genreListBox1.GetSelectedIndices())
                {
                    genres = genres + genreListBox1.Items[i] + ",";
                } // genres="Self help, Motivation";

                string genrss = genres.Remove(genres.Length - 1);
                //Image file path create
                string path = "~/BookInventory/";
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath(path + fileName));
                string filepath = path + fileName;
                //Image file path create

                book = new Book();
                Author author = new Author();
                Publisher publisher = new Publisher();
                book.Name = bookNameTextBox.Text;
                author.AuthorId = Convert.ToInt32(authorDropDownList.SelectedItem.Value);
                book.Author = author;
                publisher.PublisherId = Convert.ToInt32(publisherDropDownList.SelectedItem.Value);
                book.Publisher = publisher;
                book.Genre = genrss;
                book.Date = dateTextBox.Text;
                book.Language = languageDropDownList.SelectedItem.Value;
                book.Edition = editionTextBox.Text;
                book.BookCost = costTextBox.Text;
                book.NoOfPage = pagesTextBox.Text;
                book.Description = descriptionTextBox.Text;
                book.ActualStock = actualStockTextBox.Text;
                book.CurrentStock = actualStockTextBox.Text;
                book.BookImgLink = filepath;

                string message = bookManager.SaveBook(book);
                Response.Write("<script>alert('" + message + "');</script>");
                GridView1.DataBind();

            }
            else
            {
                Response.Write("<script>alert('Please Insert All Information!');</script>");
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {

            if (bookNameTextBox.Text!="")
            {
                string genres = "";
                foreach (int i in genreListBox1.GetSelectedIndices())
                {
                    genres = genres + genreListBox1.Items[i] + ",";
                } // genres="Self help, Motivation";

                string genrss = genres.Remove(genres.Length - 1);

                book = new Book();
                Author author = new Author();
                Publisher publisher = new Publisher();
                book.Name = bookNameTextBox.Text;
                author.AuthorId = Convert.ToInt32(authorDropDownList.SelectedItem.Value);
                book.Author = author;
                publisher.PublisherId = Convert.ToInt32(publisherDropDownList.SelectedItem.Value);
                book.Publisher = publisher;
                book.Genre = genrss;
                book.Date = dateTextBox.Text;
                book.Language = languageDropDownList.SelectedItem.Value;
                book.Edition = editionTextBox.Text;
                book.BookCost = costTextBox.Text;
                book.NoOfPage = pagesTextBox.Text;
                book.Description = descriptionTextBox.Text;
                book.ActualStock = actualStockTextBox.Text;
                book.CurrentStock = actualStockTextBox.Text;


                string message = bookManager.UpdateBook(book);
                Response.Write("<script>alert('" + message + "');</script>");
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Please Insert All Information!');</script>");
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (bookIdTextBox.Text != "")
            {
                int id = Convert.ToInt32(bookIdTextBox.Text);
                string message = bookManager.DeleteBook(id);
                Response.Write("<script>alert('" + message + "');</script>");
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Book Remove Failed, Please try again!');</script>");
            }
        }


        protected void SearchButton_OnClick(object sender, EventArgs e)
        {
            if (bookIdTextBox.Text!="")
            {
                int id =Convert.ToInt32(bookIdTextBox.Text);
                Book aBook = bookManager.GetBookInfoById(id);
                bookNameTextBox.Text = aBook.Name;
                languageDropDownList.SelectedValue = aBook.Language;
                authorDropDownList.SelectedValue = aBook.Author.AuthorId.ToString();
                publisherDropDownList.SelectedValue = aBook.Publisher.PublisherId.ToString();
                genreListBox1.ClearSelection();
                string[] tokens = aBook.Genre.Split(',');
                for (int i = 0; i < tokens.Length; i++)
                {
                    for (int j = 0; j < genreListBox1.Items.Count; j++)
                    {
                        if (genreListBox1.Items[j].ToString()==tokens[i])
                        {
                            genreListBox1.Items[j].Selected = true;
                        }
                    }
                }
                dateTextBox.Text = aBook.Date;
                editionTextBox.Text = aBook.Edition;
                costTextBox.Text = aBook.BookCost;
                pagesTextBox.Text = aBook.NoOfPage;
                actualStockTextBox.Text = aBook.ActualStock.ToString();
                currentStockTextBox.Text = aBook.CurrentStock;
                descriptionTextBox.Text = aBook.Description;
                issuedBooksTextBox.Text =
                    (Convert.ToInt32(aBook.ActualStock) - Convert.ToInt32(aBook.CurrentStock)).ToString();
              
            }
            else
            {
                Response.Write("<script>alert('Please Insert Book Id');</script>");
            }
        }
    }
}