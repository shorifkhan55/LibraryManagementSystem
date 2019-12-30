using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineLibraryManagementSystemProject.DAL;
using OnlineLibraryManagementSystemProject.Model;

namespace OnlineLibraryManagementSystemProject.BLL
{
    public class PublisherManager
    {
        PublisherGateway publisherGateway=new PublisherGateway();

        public string SavePublisher(Publisher publisher)
        {
            bool isMemberId = publisherGateway.CheckPublisherName(publisher);
            if (isMemberId == false)
            {
                int rowAffected = publisherGateway.SavePublisher(publisher);
                if (rowAffected > 0)
                {
                    return "Publisher submit Successfully.";
                }
                else
                {
                    return "Publisher submit Failed, Try Again.";
                }
            }
            else
            {
                return "This Name Already Used, please try Another Publisher Name";
            }
        }

        public Publisher GetPublisherName(int id)
        {
            return publisherGateway.GetPublisherName(id);
        }

        public bool CheckPublisherId(int id)
        {
            return publisherGateway.CheckPublisherId(id);
        }

        public string DeletePublisher(int id)
        {
            int rowAffected = publisherGateway.DeletePublisher(id);
            if (rowAffected > 0)
            {
                return "Publisher Delete Successfully.";
            }
            else
            {
                return "Publisher Delete Failed, Try Again.";
            }
        }

        public string UpdatePublisher(Publisher publisher)
        {
            int rowAffected = publisherGateway.UpdatePublisher(publisher);
            if (rowAffected > 0)
            {
                return "Publisher Update Successfully.";
            }
            else
            {
                return "Publisher Update Failed, Try Again.";
            }
        }

        public List<Publisher> GetAllPublishers()
        {
            return publisherGateway.GetAllPublishers();
        }
    }
}