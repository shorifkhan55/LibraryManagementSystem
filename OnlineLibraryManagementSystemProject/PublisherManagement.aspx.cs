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
    public partial class PublisherManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAllPublisher();
        }
        PublisherManager publisherManager=new PublisherManager();
        private Publisher publisher;
        protected void AddButton_Click(object sender, EventArgs e)
        {
            if (publisherNameTextBox.Text!="")
            {
                publisher=new Publisher();
                publisher.PublisherName = publisherNameTextBox.Text;

                string message = publisherManager.SavePublisher(publisher);
                Response.Write("<script>alert('"+message+"');</script>");
                LoadAllPublisher();
                publisherNameTextBox.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Please Insert Publisher Name!');</script>");
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (publisherIdTextBox.Text!="")
            {
                publisher=new Publisher();
                publisher.PublisherId = Convert.ToInt32(publisherIdTextBox.Text);
                publisher.PublisherName = publisherNameTextBox.Text;

                string message = publisherManager.UpdatePublisher(publisher);
                Response.Write("<script>alert('"+message+"');</script>");
                LoadAllPublisher();
                publisherIdTextBox.Text = "";
                publisherNameTextBox.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Please Insert Publisher Id!');</script>");
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (publisherIdTextBox.Text!="")
            {
                int id = Convert.ToInt32(publisherIdTextBox.Text);
                string message = publisherManager.DeletePublisher(id);
                Response.Write("<script>alert('"+message+"');</script>");
                LoadAllPublisher();
                publisherIdTextBox.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Please Insert Publisher Id!');</script>");
            }
        }

        private void LoadAllPublisher()
        {
            List<Publisher> publishers = publisherManager.GetAllPublishers();
            publisherGridView.DataSource = publishers;
            publisherGridView.DataBind();
        }

        protected void goButton_OnClick(object sender, EventArgs e)
        {
            if (publisherIdTextBox.Text != "")
            {
                int id = Convert.ToInt32(publisherIdTextBox.Text);
                bool isPublisher = publisherManager.CheckPublisherId(id);
                if (!isPublisher)
                {
                    Response.Write("<script>alert('Please Insert Right ID');</script>");

                }
                else
                {
                    publisher = publisherManager.GetPublisherName(id);
                    publisherNameTextBox.Text = publisher.PublisherName;
                    publisherIdTextBox.Text = publisher.PublisherId.ToString();
                }

            }
            else
            {
                Response.Write("<script>alert('Please Insert Publisher Id');</script>");

            }
        }
    }
}