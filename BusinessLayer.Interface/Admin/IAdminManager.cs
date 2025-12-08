using Domain;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface IAdminManager
    {

        #region Client

        int SaveClient(Client Object);
        IList<Client_Business> GetClient(int? Client_Id, int? Product_Id);
        int UpdateClient(Client Object);
        int DeleteClient(int Client_Id);

        #endregion

        #region News

        int SaveNews(News Object);
        IList<News> GetNews(int? News_Id);
        int UpdateNews(News Object);
        int DeleteNews(int News_Id);

        #endregion

        #region Blog Category

        int SaveBlogCategory(Blog_Category Object);
        IList<Blog_Category> GetBlogCategory(int? Blog_Category_Id, string Category_Description);
        int UpdateBlogCategory(Blog_Category Object);
        int DeleteBlogCategory(int Blog_Category_Id);

        #endregion

        #region Blog

        int SaveBlog(Blog Object);
        IList<Blog_Business> GetBlog(int? Blog_Id, int? Blog_Category_Id, string Blog_Link);
        int UpdateBlog(Blog Object);
        int DeleteBlog(int Blog_Id);

        #endregion

        #region BlogFAQ
        int SaveBlogFAQ(Blog_FAQ Object);
        IList<Blog_FAQ_Business> GetBlogFAQ(int? Blog_FAQ_Id, int? Product_Id);
        int UpdateBlogFAQ(Blog_FAQ Object);
        int DeleteBlogFAQ(int Blog_FAQ_Id);

        #endregion

        #region Status

        int SaveStatus(Status Object);
        IList<Status> GetStatus(int? Status_Id);
        int UpdateStatus(Status Object);
        int DeleteStatus(int Status_Id);

        #endregion

        #region Event

        int SaveEvent(Event Object);
        IList<Event> GetEvent(int? Event_Id);
        int UpdateEvent(Event Object);
        int DeleteEvent(int Event_Id);

        #endregion

        #region Event Detail

        int SaveEventDetail(Event_Detail Object);
        IList<Event_Detail_Business> GetEventDetail(int? Event_Detail_Id, int? Event_Id);
        int UpdateEventDetail(Event_Detail Object);
        int DeleteEventDetail(int Event_Detail_Id);

        #endregion

        #region Industries

        int SaveIndustries(Industries Object);
        IList<Industries> GetIndustries(int? Industries_Id, string Industries_Url_Link);
        int UpdateIndustries(Industries Object);
        int DeleteIndustries(int Industries_Id);

        #endregion

        #region Product

        int SaveProduct(Product Object);
        IList<Product_Business> GetProduct(int? Product_Id, int? Industries_Id, string Product_Url_Link);
        int UpdateProduct(Product Object);
        int DeleteProduct(int Product_Id);

        #endregion

        #region Product Brochure
        int SaveProductBrochure(Product_Brochure Object);
        IList<Product_Brochure_Business> GetProductBrochure(int? Product_Brochure_Id, int? Product_Id);
        int UpdateProductBrochure(Product_Brochure Object);
        int DeleteProductBrochure(int Product_Brochure_Id);
        #endregion

        #region Product Benefits
        int SaveProductBenefits(Product_Benefits Object);
        IList<Product_Benefits_Business> GetProductBenefits(int? Product_Benefits_Id, int? Product_Id);
        int UpdateProductBenefits(Product_Benefits Object);
        int DeleteProductBenefits(int Product_Benefits_Id);

        #endregion

        #region Product FAQ
        int SaveProductFAQ(Product_FAQ Object);
        IList<Product_FAQ_Business> GetProductFAQ(int? Product_FAQ_Id, int? Product_Id);
        int UpdateProductFAQ(Product_FAQ Object);
        int DeleteProductFAQ(int Product_FAQ_Id);

        #endregion

        #region Product Features
        int SaveProductFeatures(Product_Features Object);
        IList<Product_Features_Business> GetProductFeatures(int? Product_Features_Id, int? Product_Id);
        int UpdateProductFeatures(Product_Features Object);
        int DeleteProductFeatures(int Product_Features_Id);

        #endregion

        #region Product Image
        int SaveProductImage(Product_Image Object);
        IList<Product_Image_Business> GetProductImage(int? Product_Image_Id, int? Product_Id);
        int UpdateProductImage(Product_Image Object);
        int DeleteProductImage(int Product_Image_Id);

        #endregion

        #region Product Module
        int SaveProductModule(Product_Module Object);
        IList<Product_Module_Business> GetProductModule(int? Product_Module_Id, int? Product_Id);
        int UpdateProductModule(Product_Module Object);
        int DeleteProductModule(int Product_Module_Id);

        #endregion

        #region Product Portfolio
        int SaveProductPortfolio(Product_Portfolio Object);
        IList<Product_Portfolio_Business> GetProductPortfolio(int? Product_Portfolio_Id, int? Product_Id);
        int UpdateProductPortfolio(Product_Portfolio Object);
        int DeleteProductPortfolio(int Product_Portfolio_Id);

        #endregion

        #region Demo Follow Up

        int SaveDemoFollowUp(Demo_Follow_Up Object);
        IList<Demo_Follow_Up_Business> GetDemoFollowUp(int? Demo_Follow_Up_Id, string Demo_Follow_Up_Code, int? Software_Demo_Id, bool? Is_Active, int? Created_By);
        int UpdateDemoFollowUp(Demo_Follow_Up Object);
        int DeleteDemoFollowUp(int Demo_Follow_Up_Id);

        #endregion
    }
}