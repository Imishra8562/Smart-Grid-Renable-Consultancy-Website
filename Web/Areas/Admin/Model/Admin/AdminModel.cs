using Domain;
using System.Collections.Generic;
using System.Web;

namespace Web.Areas.Admin.Model
{
    public class AdminModel
    {
        #region  Client
        public HttpPostedFileBase Company_Logo { get; set; }
        public HttpPostedFileBase Client_Video_Thumbnail { get; set; }
        public Client Client_Obj { get; set; }
        public Client_Business Client__Business_Obj { get; set; }
        public IList<Client_Business> List_Client_Business_Obj { get; set; }

        #endregion

        #region News
        public HttpPostedFileBase News_Image { get; set; }
        public News News_Obj { get; set; }
        public IList<News> List_News_Obj { get; set; }
        #endregion

        #region Blog Category
        public Blog_Category Blog_Category_Obj { get; set; }
        public IList<Blog_Category> List_Blog_Category_Obj { get; set; }

        #endregion

        #region Blog
        public HttpPostedFileBase Blog_Image { get; set; }
        public HttpPostedFileBase Meta_Og_Image { get; set; }
        public Blog Blog_Obj { get; set; }
        public Blog_Business Blog_Business_Obj { get; set; }
        public IList<Blog_Business> List_Blog_Business_Obj { get; set; }
        #endregion

        #region BlogFAQ
        public Blog_FAQ Blog_FAQ_Obj { get; set; }
        public Blog_FAQ_Business Blog_FAQ_Business_Obj { get; set; }
        public IList<Blog_FAQ> List_Blog_FAQ_Obj { get; set; }
        public IList<Blog_FAQ_Business> List_Blog_FAQ_Business_Obj { get; set; }

        #endregion

        #region Status
        public Status Status_Obj { get; set; }
        public IList<Status> List_Status_Obj { get; set; }
        #endregion

        #region Event
        public Event Event_Obj { get; set; }
        public IList<Event> List_Event_Obj { get; set; }
        #endregion

        #region Event detail
        public HttpPostedFileBase Event_Image { get; set; }
        public Event_Detail Event_Detail_Obj { get; set; }
        public Event_Detail_Business Event_Detail_Business_Obj { get; set; }
        public IList<Event_Detail_Business> List_Event_Detail_Business_Obj { get; set; }
        public IList<Event_Detail> List_Event_Detail_Obj { get; set; }
        public string Type { get; set; }
        public IList<HttpPostedFileBase> List_Id_Obj { get; set; }
        #endregion

        #region Software Demo
        public Software_Demo Software_Demo_Obj { get; set; }
        public IList<Software_Demo> List_Software_Demo_Obj { get; set; }
        #endregion

        #region  Job Request
        public HttpPostedFileBase Upload_Resume { get; set; }
        public Job_Request Job_Request_Obj { get; set; }
        public IList<Job_Request> List_Job_Request_Obj { get; set; }
        #endregion

        #region Partner
        public HttpPostedFileBase Upload_File { get; set; }
        public Partner Partner_Obj { get; set; }
        public IList<Partner> List_Partner_Obj { get; set; }
        #endregion

        #region Contact
        public Contact Contact_Obj { get; set; }
        public IList<Contact> List_Contact_Obj { get; set; }
        #endregion

        #region Blog Comment
        public Blog_Comment Blog_Comment_Obj { get; set; }
        public Blog_Comment_Business Blog_Comment_Business_Obj { get; set; }
        public IList<Blog_Comment_Business> List_Blog_Comment_Business_Obj { get; set; }

        #endregion

        #region Industries

        public HttpPostedFileBase Industries_Image { get; set; }
        public HttpPostedFileBase Industries_Og_Image { get; set; }
        public Industries Industries_Obj { get; set; }
        public IList<Industries> List_Industries_Obj { get; set; }
        #endregion

        #region Product

        public HttpPostedFileBase Product_Image { get; set; }
        public HttpPostedFileBase Product_Og_Image { get; set; }
        public Product Product_Obj { get; set; }
        public Product_Business Product_Business_Obj { get; set; }
        public IList<Product_Business> List_Product_Business_Obj { get; set; }
        #endregion

        #region Product Benefits
        public Product_Benefits Product_Benefits_Obj { get; set; }
        public Product_Benefits_Business Product_Benefits_Business_Obj { get; set; }
        public IList<Product_Benefits_Business> List_Product_Benefits_Business_Obj { get; set; }
        public HttpPostedFileBase Product_Benefits_Images { get; set; }

        public IList<Product_Benefits> List_Product_Benefits_Obj { get; set; }
        public IList<ProductBenefitsIntImage> List_ProductBenefitsId_Obj { get; set; }
        #endregion

        #region Product Brochure
        public Product_Brochure Product_Brochure_Obj { get; set; }
        public Product_Brochure_Business Product_Brochure_Business_Obj { get; set; }
        public IList<Product_Brochure> List_Product_Brochure_Obj { get; set; }
        public IList<Product_Brochure_Business> List_Product_Brochure_Business_Obj { get; set; }
        public HttpPostedFileBase Product_Brochure_File { get; set; }

        #endregion

        #region Product FAQ
        public Product_FAQ Product_FAQ_Obj { get; set; }
        public Product_FAQ_Business Product_FAQ_Business_Obj { get; set; }
        public IList<Product_FAQ> List_Product_FAQ_Obj { get; set; }
        public IList<Product_FAQ_Business> List_Product_FAQ_Business_Obj { get; set; }


        #endregion

        #region Product Features
        public Product_Features Product_Features_Obj { get; set; }
        public Product_Features_Business Product_Features_Business_Obj { get; set; }
        public IList<Product_Features_Business> List_Product_Features_Business_Obj { get; set; }
        public HttpPostedFileBase Product_Features_Images { get; set; }
        public IList<ProductFeaturesIntImage> List_ProductFeaturesId_Obj { get; set; }
        public IList<Product_Features> List_Product_Features_Obj { get; set; }

        #endregion

        #region Product Image
        public Product_Image Product_Image_Obj { get; set; }
        public Product_Image_Business Product_Image_Business_Obj { get; set; }
        public IList<Product_Image> List_Product_Image_Obj { get; set; }
        public IList<Product_Image_Business> List_Product_Image_Business_Obj { get; set; }
        public HttpPostedFileBase Product_Details_Image { get; set; }
        public IList<HttpPostedFileBase> List_Product_Image_Id_Obj { get; set; }
        #endregion

        #region Product Module
        public Product_Module Product_Module_Obj { get; set; }
        public HttpPostedFileBase Product_Module_Images { get; set; }
        public Product_Module_Business Product_Module_Business_Obj { get; set; }
        public IList<Product_Module_Business> List_Product_Module_Business_Obj { get; set; }
        public IList<Product_Module> List_Product_Module_Obj { get; set; }
        public IList<ProductModuleIntImage> List_ProductModuleId_Obj { get; set; }

        #endregion

        #region Product Portfolio
        public Product_Portfolio Product_Portfolio_Obj { get; set; }
        public Product_Portfolio_Business Product_Portfolio_Business_Obj { get; set; }
        public IList<Product_Portfolio> List_Product_Portfolio_Obj { get; set; }
        public IList<Product_Portfolio_Business> List_Product_Portfolio_Business_Obj { get; set; }
        public HttpPostedFileBase Product_Portfolio_Images { get; set; }
        public IList<HttpPostedFileBase> List_Product_Portfolio_Id_Obj { get; set; }
        #endregion

        #region Demo Follow Up

        public Demo_Follow_Up Demo_Follow_Up_Obj { get; set; }
        public Demo_Follow_Up_Business Demo_Follow_Up_Business_Obj { get; set; }
        public IList<Demo_Follow_Up_Business> List_Demo_Follow_Up_Business_Obj { get; set; }

        #endregion
    }

    public class ProductModuleIntImage
    {
        public int Product_Id { get; set; }
        public HttpPostedFileBase Product_Module_Image { get; set; }
        public string Product_Module_Detail { get; set; }
    }
    public class ProductFeaturesIntImage
    {
        public int Product_Id { get; set; }
        public HttpPostedFileBase Product_Features_Image { get; set; }
        public string Product_Features_Detail { get; set; }
    }
  
    public class ProductBenefitsIntImage
    {
        public int Product_Id { get; set; }
        public HttpPostedFileBase Product_Benefits_Image { get; set; }
        public string Product_Benefits_Detail { get; set; }
    }



}
