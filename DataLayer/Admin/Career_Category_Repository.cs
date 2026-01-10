using Domain;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
namespace DataLayer
{
   public  class Career_Category_Repository : BaseRepository<Career_Category>
   {
        public IList<Career_Category> ListBlogCategory(int? Career_Category_Id, string Category_Description)
        {
            IList<Career_Category> List_Obj = null;

            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database _db = factory.Create("DefConn");
                DbCommand sqlCommand = _db.GetStoredProcCommand("sp_List_Career_Category");
                DataSet dataSet = new DataSet();

                var BlogId = sqlCommand.CreateParameter();
                BlogId.ParameterName = "Career_Category_Id";
                BlogId.Value = Career_Category_Id;
                sqlCommand.Parameters.Add(BlogId);

                _db.LoadDataSet(sqlCommand, dataSet, TableName);

                DataSet ds = dataSet;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<Career_Category>(ds.Tables[0]);
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
