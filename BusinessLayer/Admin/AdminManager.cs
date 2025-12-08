using BusinessLayer.Interface;
using DataLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer
{

    public class AdminManager : IAdminManager
    {

        #region Client

        public int SaveClient(Client Object)
        {
            int Id = 0;

            try
            {
                Client_Repository db = new Client_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }

        public IList<Client_Business> GetClient(int? Client_Id, int? Product_Id)
        {
            IList<Client_Business> ListObj = new List<Client_Business>();
            try
            {
                Client_Repository db = new Client_Repository();
                ListObj = db.ListClient(Client_Id, Product_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }




        public int UpdateClient(Client Object)
        {
            int Id = 0;

            try
            {
                Client_Repository db = new Client_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public int DeleteClient(int Client_Id)
        {
            int Id = 0;

            try
            {
                Client_Repository db = new Client_Repository();
                Id = db.Delete(Client_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }

        #endregion

        #region News

        public int SaveNews(News Object)
        {
            int Id = 0;

            try
            {
                News_Repository db = new News_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public IList<News> GetNews(int? News_Id)
        {
            IList<News> ListObj = new List<News>();
            try
            {
                News_Repository db = new News_Repository();
                DataSet ds = db.List(News_Id);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    ListObj = DataBaseUtil.DataTableToList<News>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateNews(News Object)
        {
            int Id = 0;

            try
            {
                News_Repository db = new News_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public int DeleteNews(int News_Id)
        {
            int Id = 0;

            try
            {
                News_Repository db = new News_Repository();
                Id = db.Delete(News_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }

        #endregion

        #region Blog Category

        public int SaveBlogCategory(Blog_Category Object)
        {
            int Id = 0;

            try
            {
                Blog_Category_Repository db = new Blog_Category_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public IList<Blog_Category> GetBlogCategory(int? Blog_Category_Id, string Category_Description)
        {
            IList<Blog_Category> ListObj = new List<Blog_Category>();
            try
            {
                Blog_Category_Repository db = new Blog_Category_Repository();
                ListObj = db.ListBlogCategory(Blog_Category_Id, Category_Description);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateBlogCategory(Blog_Category Object)
        {
            int Id = 0;

            try
            {
                Blog_Category_Repository db = new Blog_Category_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public int DeleteBlogCategory(int Blog_Category_Id)
        {
            int Id = 0;

            try
            {
                Blog_Category_Repository db = new Blog_Category_Repository();
                Id = db.Delete(Blog_Category_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }

        #endregion

        #region Blog
        public int SaveBlog(Blog Object)
        {
            int Id = 0;

            try
            {
                Blog_Repository db = new Blog_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public IList<Blog_Business> GetBlog(int? Blog_Id, int? Blog_Category_Id, string Blog_Link)
        {
            IList<Blog_Business> ListObj = new List<Blog_Business>();
            try
            {
                Blog_Repository db = new Blog_Repository();
                ListObj = db.ListBlog(Blog_Id, Blog_Category_Id, Blog_Link);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateBlog(Blog Object)
        {
            int Id = 0;

            try
            {
                Blog_Repository db = new Blog_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public int DeleteBlog(int Blog_Id)
        {
            int Id = 0;

            try
            {
                Blog_Repository db = new Blog_Repository();
                Id = db.Delete(Blog_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }

        #endregion

        #region BlogFAQ
        public int SaveBlogFAQ(Blog_FAQ Object)
        {
            int Id = 0;
            try
            {
                Blog_FAQ_Repository db = new Blog_FAQ_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }

        public IList<Blog_FAQ_Business> GetBlogFAQ(int? Blog_FAQ_Id, int? Blog_Id)
        {
            IList<Blog_FAQ_Business> ListObj = new List<Blog_FAQ_Business>();
            try
            {
                Blog_FAQ_Repository db = new Blog_FAQ_Repository();
                ListObj = db.ListBlogFAQ(Blog_FAQ_Id, Blog_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ListObj;
        }
        public int UpdateBlogFAQ(Blog_FAQ Object)
        {
            int Id = 0;
            try
            {
                Blog_FAQ_Repository db = new Blog_FAQ_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteBlogFAQ(int Blog_FAQ_Id)
        {
            int Id = 0;
            try
            {
                Blog_FAQ_Repository db = new Blog_FAQ_Repository();
                Id = db.Delete(Blog_FAQ_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }

        #endregion

        #region Status

        public int SaveStatus(Status Object)
        {
            int Id = 0;

            try
            {
                Status_Repository db = new Status_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public IList<Status> GetStatus(int? Status_Id)
        {
            IList<Status> ListObj = new List<Status>();
            try
            {
                Status_Repository db = new Status_Repository();
                DataSet ds = db.List(Status_Id);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    ListObj = DataBaseUtil.DataTableToList<Status>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateStatus(Status Object)
        {
            int Id = 0;

            try
            {
                Status_Repository db = new Status_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public int DeleteStatus(int Status_Id)
        {
            int Id = 0;

            try
            {
                Status_Repository db = new Status_Repository();
                Id = db.Delete(Status_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }

        #endregion

        #region Event

        public int SaveEvent(Event Object)
        {
            int Id = 0;

            try
            {
                Event_Repository db = new Event_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public IList<Event> GetEvent(int? Event_Id)
        {
            IList<Event> ListObj = new List<Event>();
            try
            {
                Event_Repository db = new Event_Repository();
                DataSet ds = db.List(Event_Id);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    ListObj = DataBaseUtil.DataTableToList<Event>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateEvent(Event Object)
        {
            int Id = 0;

            try
            {
                Event_Repository db = new Event_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public int DeleteEvent(int Event_Id)
        {
            int Id = 0;

            try
            {
                Event_Repository db = new Event_Repository();
                Id = db.Delete(Event_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }

        #endregion

        #region Event Detail

        public int SaveEventDetail(Event_Detail Object)
        {
            int Id = 0;

            try
            {
                Event_Detail_Repository db = new Event_Detail_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public IList<Event_Detail_Business> GetEventDetail(int? Event_Detail_Id, int? Event_Id)
        {
            IList<Event_Detail_Business> ListObj = new List<Event_Detail_Business>();
            try
            {
                Event_Detail_Repository db = new Event_Detail_Repository();
                ListObj = db.ListEventDetail(Event_Detail_Id, Event_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateEventDetail(Event_Detail Object)
        {
            int Id = 0;

            try
            {
                Event_Detail_Repository db = new Event_Detail_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public int DeleteEventDetail(int Event_Detail_Id)
        {
            int Id = 0;

            try
            {
                Event_Detail_Repository db = new Event_Detail_Repository();
                Id = db.Delete(Event_Detail_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }

        #endregion

        #region Industries

        public int SaveIndustries(Industries Object)
        {
            int Id = 0;

            try
            {
                Industries_Repository db = new Industries_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public IList<Industries> GetIndustries(int? Industries_Id, string Industries_Url_Link)
        {
            IList<Industries> ListObj = new List<Industries>();
            try
            {
                Industries_Repository db = new Industries_Repository();
                ListObj = db.ListIndustries(Industries_Id, Industries_Url_Link);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateIndustries(Industries Object)
        {
            int Id = 0;

            try
            {
                Industries_Repository db = new Industries_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public int DeleteIndustries(int Industries_Id)
        {
            int Id = 0;

            try
            {
                Industries_Repository db = new Industries_Repository();
                Id = db.Delete(Industries_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }

        #endregion

        #region Product

        public int SaveProduct(Product Object)
        {
            int Id = 0;

            try
            {
                Product_Repository db = new Product_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public IList<Product_Business> GetProduct(int? Product_Id, int? Industries_Id, string Product_Url_Link)
        {
            IList<Product_Business> ListObj = new List<Product_Business>();
            try
            {
                Product_Repository db = new Product_Repository();
                ListObj = db.ListProduct(Product_Id, Industries_Id, Product_Url_Link);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateProduct(Product Object)
        {
            int Id = 0;

            try
            {
                Product_Repository db = new Product_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public int DeleteProduct(int Product_Id)
        {
            int Id = 0;

            try
            {
                Product_Repository db = new Product_Repository();
                Id = db.Delete(Product_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }

        #endregion

        #region Product Brochure     
        public int SaveProductBrochure(Product_Brochure Object)
        {
            int Id = 0;
            try
            {
                Product_Brochure_Repository db = new Product_Brochure_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Product_Brochure_Business> GetProductBrochure(int? Product_Brochure_Id, int? Product_Id)
        {
            IList<Product_Brochure_Business> ListObj = new List<Product_Brochure_Business>();
            try
            {
                Product_Brochure_Repository db = new Product_Brochure_Repository();
                ListObj = db.ListProductBrochure(Product_Brochure_Id, Product_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateProductBrochure(Product_Brochure Object)
        {
            int Id = 0;
            try
            {
                Product_Brochure_Repository db = new Product_Brochure_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteProductBrochure(int Product_Brochure_Id)
        {
            int Id = 0;
            try
            {
                Product_Brochure_Repository db = new Product_Brochure_Repository();
                Id = db.Delete(Product_Brochure_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Product Benefits     
        public int SaveProductBenefits(Product_Benefits Object)
        {
            int Id = 0;
            try
            {
                Product_Benefits_Repository db = new Product_Benefits_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Product_Benefits_Business> GetProductBenefits(int? Product_Benefits_Id, int? Product_Id)
        {
            IList<Product_Benefits_Business> ListObj = new List<Product_Benefits_Business>();
            try
            {
                Product_Benefits_Repository db = new Product_Benefits_Repository();
                ListObj = db.ListProductBenefits(Product_Benefits_Id, Product_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateProductBenefits(Product_Benefits Object)
        {
            int Id = 0;
            try
            {
                Product_Benefits_Repository db = new Product_Benefits_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteProductBenefits(int Product_Benefits_Id)
        {
            int Id = 0;
            try
            {
                Product_Benefits_Repository db = new Product_Benefits_Repository();
                Id = db.Delete(Product_Benefits_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }

        #endregion

        #region Product FAQ
        public int SaveProductFAQ(Product_FAQ Object)
        {
            int Id = 0;
            try
            {
                Product_FAQ_Repository db = new Product_FAQ_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Product_FAQ_Business> GetProductFAQ(int? Product_FAQ_Id, int? Product_Id)
        {
            IList<Product_FAQ_Business> ListObj = new List<Product_FAQ_Business>();
            try
            {
                Product_FAQ_Repository db = new Product_FAQ_Repository();
                ListObj = db.ListProductFAQ(Product_FAQ_Id, Product_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateProductFAQ(Product_FAQ Object)
        {
            int Id = 0;
            try
            {
                Product_FAQ_Repository db = new Product_FAQ_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteProductFAQ(int Product_FAQ_Id)
        {
            int Id = 0;
            try
            {
                Product_FAQ_Repository db = new Product_FAQ_Repository();
                Id = db.Delete(Product_FAQ_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Product Features
        public int SaveProductFeatures(Product_Features Object)
        {
            int Id = 0;
            try
            {
                Product_Features_Repository db = new Product_Features_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Product_Features_Business> GetProductFeatures(int? Product_Features_Id, int? Product_Id)
        {
            IList<Product_Features_Business> ListObj = new List<Product_Features_Business>();
            try
            {
                Product_Features_Repository db = new Product_Features_Repository();
                ListObj = db.ListProductFeatures(Product_Features_Id, Product_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateProductFeatures(Product_Features Object)
        {
            int Id = 0;
            try
            {
                Product_Features_Repository db = new Product_Features_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteProductFeatures(int Product_Features_Id)
        {
            int Id = 0;
            try
            {
                Product_Features_Repository db = new Product_Features_Repository();
                Id = db.Delete(Product_Features_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Product Image
        public int SaveProductImage(Product_Image Object)
        {
            int Id = 0;
            try
            {
                Product_Image_Repository db = new Product_Image_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public IList<Product_Image_Business> GetProductImage(int? Product_Image_Id, int? Product_Id)
        {
            IList<Product_Image_Business> ListObj = new List<Product_Image_Business>();
            try
            {
                Product_Image_Repository db = new Product_Image_Repository();
                ListObj = db.ListProductImage(Product_Image_Id, Product_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ListObj;
        }
        public int UpdateProductImage(Product_Image Object)
        {
            int Id = 0;
            try
            {
                Product_Image_Repository db = new Product_Image_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteProductImage(int Product_Image_Id)
        {
            int Id = 0;
            try
            {
                Product_Image_Repository db = new Product_Image_Repository();
                Id = db.Delete(Product_Image_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }

        #endregion

        #region Product Module
        public int SaveProductModule(Product_Module Object)
        {
            int Id = 0;
            try
            {
                Product_Module_Repository db = new Product_Module_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Product_Module_Business> GetProductModule(int? Product_Module_Id, int? Product_Id)
        {
            IList<Product_Module_Business> ListObj = new List<Product_Module_Business>();
            try
            {
                Product_Module_Repository db = new Product_Module_Repository();
                ListObj = db.ListProductModule(Product_Module_Id, Product_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ListObj;
        }
        public int UpdateProductModule(Product_Module Object)
        {
            int Id = 0;
            try
            {
                Product_Module_Repository db = new Product_Module_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteProductModule(int Product_Module_Id)
        {
            int Id = 0;
            try
            {
                Product_Module_Repository db = new Product_Module_Repository();
                Id = db.Delete(Product_Module_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Product Portfolio
        public int SaveProductPortfolio(Product_Portfolio Object)
        {
            int Id = 0;
            try
            {
                Product_Portfolio_Repository db = new Product_Portfolio_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public IList<Product_Portfolio_Business> GetProductPortfolio(int? Product_Portfolio_Id, int? Product_Id)
        {
            IList<Product_Portfolio_Business> ListObj = new List<Product_Portfolio_Business>();
            try
            {
                Product_Portfolio_Repository db = new Product_Portfolio_Repository();
                ListObj = db.ListProductPortfolio(Product_Portfolio_Id, Product_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ListObj;
        }
        public int UpdateProductPortfolio(Product_Portfolio Object)
        {
            int Id = 0;
            try
            {
                Product_Portfolio_Repository db = new Product_Portfolio_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteProductPortfolio(int Product_Portfolio_Id)
        {
            int Id = 0;
            try
            {
                Product_Portfolio_Repository db = new Product_Portfolio_Repository();
                Id = db.Delete(Product_Portfolio_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Demo Follow Up

        public int SaveDemoFollowUp(Demo_Follow_Up Object)
        {
            int Id = 0;

            try
            {
                Demo_Follow_Up_Repository db = new Demo_Follow_Up_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public IList<Demo_Follow_Up_Business> GetDemoFollowUp(int? Demo_Follow_Up_Id, string Demo_Follow_Up_Code, int? Software_Demo_Id, bool? Is_Active, int? Created_By)
        {
            IList<Demo_Follow_Up_Business> ListObj = new List<Demo_Follow_Up_Business>();
            try
            {
                Demo_Follow_Up_Repository db = new Demo_Follow_Up_Repository();
                ListObj = db.ListDemoFollowUp(Demo_Follow_Up_Id, Demo_Follow_Up_Code, Software_Demo_Id, Is_Active, Created_By);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateDemoFollowUp(Demo_Follow_Up Object)
        {
            int Id = 0;

            try
            {
                Demo_Follow_Up_Repository db = new Demo_Follow_Up_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public int DeleteDemoFollowUp(int Demo_Follow_Up_Id)
        {
            int Id = 0;

            try
            {
                Demo_Follow_Up_Repository db = new Demo_Follow_Up_Repository();
                Id = db.Delete(Demo_Follow_Up_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }

        #endregion

    }
}
