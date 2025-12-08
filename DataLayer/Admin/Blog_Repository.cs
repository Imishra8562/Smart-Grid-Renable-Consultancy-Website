using Domain;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DataLayer
{
    public class Blog_Repository : BaseRepository<Blog>
    {
        public IList<Blog_Business> ListBlog(int? Blog_Id, int? Blog_Category_Id, string Blog_Link)
        {
            IList<Blog_Business> List_Obj = null;

            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database _db = factory.Create("DefConn");
                DbCommand sqlCommand = _db.GetStoredProcCommand("sp_List_Blog");
                DataSet dataSet = new DataSet();

                var BlogId = sqlCommand.CreateParameter();
                BlogId.ParameterName = "Blog_Id";
                BlogId.Value = Blog_Id;
                sqlCommand.Parameters.Add(BlogId);

                var Bloglink = sqlCommand.CreateParameter();
                Bloglink.ParameterName = "Blog_Link";
                Bloglink.Value = Blog_Link;
                sqlCommand.Parameters.Add(Bloglink);

                var BlogCategoryId = sqlCommand.CreateParameter();
                BlogCategoryId.ParameterName = "Blog_Category_Id";
                BlogCategoryId.Value = Blog_Category_Id;
                sqlCommand.Parameters.Add(BlogCategoryId);

                _db.LoadDataSet(sqlCommand, dataSet, TableName);

                DataSet ds = dataSet;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<Blog_Business>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return List_Obj;

        }
    }
}
