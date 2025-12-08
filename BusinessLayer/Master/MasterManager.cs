using BusinessLayer.Interface;
using DataLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;


namespace BusinessLayer
{
    public class MasterManager :IMasterManager
    {
        #region Index Seo

        public int SaveIndexSeo(Index_Seo Object)
        {
            int Id = 0;
            try
            {
                Index_Seo_Repository db = new Index_Seo_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Index_Seo> GetIndexSeo(int? Index_Seo_Id, string Index_Seo_Slug)
        {
            IList<Index_Seo> ListObj = new List<Index_Seo>();
            try
            {
                Index_Seo_Repository db = new Index_Seo_Repository();
                ListObj = db.ListIndexSeo(Index_Seo_Id, Index_Seo_Slug);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateIndexSeo(Index_Seo Object)
        {
            int Id = 0;
            try
            {
                Index_Seo_Repository db = new Index_Seo_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteIndexSeo(int Index_Seo_Id)
        {
            int Id = 0;
            try
            {
                Index_Seo_Repository db = new Index_Seo_Repository();
                Id = db.Delete(Index_Seo_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }

        #endregion

        #region Index Features
        public int SaveIndexFeatures(Index_Features Object)
        {
            int Id = 0;
            try
            {
                Index_Features_Repository db = new Index_Features_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Index_Features_Business> GetIndexFeatures(int? Index_Features_Id, int Index_Seo_Id)
        {
            IList<Index_Features_Business> ListObj = new List<Index_Features_Business>();
            try
            {
                Index_Features_Repository db = new Index_Features_Repository();
                ListObj = db.ListIndexFeatures(Index_Features_Id, Index_Seo_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateIndexFeatures(Index_Features Object)
        {
            int Id = 0;
            try
            {
                Index_Features_Repository db = new Index_Features_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteIndexFeatures(int Index_Features_Id)
        {
            int Id = 0;
            try
            {
                Index_Features_Repository db = new Index_Features_Repository();
                Id = db.Delete(Index_Features_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion
            
        #region Index Services
        public int SaveIndexServices(Index_Services Object)
        {
            int Id = 0;
            try
            {
                Index_Services_Repository db = new Index_Services_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Index_Services_Business> GetIndexServices(int? Index_Services_Id, int Index_Seo_Id)
        {
            IList<Index_Services_Business> ListObj = new List<Index_Services_Business>();
            try
            {
                Index_Services_Repository db = new Index_Services_Repository();
                ListObj = db.ListIndexServices(Index_Services_Id, Index_Seo_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateIndexServices(Index_Services Object)
        {
            int Id = 0;
            try
            {
                Index_Services_Repository db = new Index_Services_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteIndexServices(int Index_Services_Id)
        {
            int Id = 0;
            try
            {
                Index_Services_Repository db = new Index_Services_Repository();
                Id = db.Delete(Index_Services_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Index Slider
        public  int SaveIndexSlider(Index_Slider Object)
        {
            int Id = 0;
            try
            {
                Index_Slider_Repository db = new Index_Slider_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Index_Slider_Business> GetIndexSlider(int? Index_Slider_Id, int Index_Seo_Id)
        {
            IList<Index_Slider_Business> ListObj = new List<Index_Slider_Business>();
            try
            {
                Index_Slider_Repository db = new Index_Slider_Repository();
                ListObj = db.ListIndexSlider(Index_Slider_Id, Index_Seo_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateIndexSlider(Index_Slider Object)
        {
            int Id = 0;
            try
            {
                Index_Slider_Repository db = new Index_Slider_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteIndexSlider(int Index_Slider_Id)
        {
            int Id = 0;
            try
            {
                Index_Slider_Repository db = new Index_Slider_Repository();
                Id = db.Delete(Index_Slider_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Index Team
        public int SaveIndexTeam(Index_Team Object)
        {
            int Id = 0;
            try
            {
                Index_Team_Repository db = new Index_Team_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Index_Team_Business> GetIndexTeam(int? Index_Team_Id, int Index_Seo_Id)
        {
            IList<Index_Team_Business> ListObj = new List<Index_Team_Business>();
            try
            {
                Index_Team_Repository db = new Index_Team_Repository();
                ListObj = db.ListIndexTeam(Index_Team_Id, Index_Seo_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateIndexTeam(Index_Team Object)
        {
            int Id = 0;
            try
            {
                Index_Team_Repository db = new Index_Team_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteIndexTeam(int Index_Team_Id)
        {
            int Id = 0;
            try
            {
                Index_Team_Repository db = new Index_Team_Repository();
                Id = db.Delete(Index_Team_Id);
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
