using Domain;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DataLayer
{

    public class Blog_Category_Repository : BaseRepository<Blog_Category>
    {
        public IList<Blog_Category> ListBlogCategory(int? Blog_Category_Id, string Category_Description)
        {
            IList<Blog_Category> List_Obj = null;

            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database _db = factory.Create("DefConn");
                DbCommand sqlCommand = _db.GetStoredProcCommand("sp_List_Blog_Category");
                DataSet dataSet = new DataSet();

                var BlogId = sqlCommand.CreateParameter();
                BlogId.ParameterName = "Blog_Category_Id";
                BlogId.Value = Blog_Category_Id;
                sqlCommand.Parameters.Add(BlogId);

                var P2 = sqlCommand.CreateParameter();
                P2.ParameterName = "Category_Description";
                P2.Value = Category_Description;
                sqlCommand.Parameters.Add(P2);

                _db.LoadDataSet(sqlCommand, dataSet, TableName);

                DataSet ds = dataSet;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<Blog_Category>(ds.Tables[0]);
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
