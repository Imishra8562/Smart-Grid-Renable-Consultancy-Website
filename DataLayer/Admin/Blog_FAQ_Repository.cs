using Domain;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Blog_FAQ_Repository : BaseRepository<Blog_FAQ>
    {
        public IList<Blog_FAQ_Business> ListBlogFAQ(int? Blog_FAQ_Id, int? Blog_Id)
        {
            IList<Blog_FAQ_Business> List_Obj = null;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database _db = factory.Create("DefConn");
                DbCommand sqlCommand = _db.GetStoredProcCommand("sp_List_Blog_FAQ");
                sqlCommand.CommandTimeout = 120;
                DataSet dataSet = new DataSet();

                var P1 = sqlCommand.CreateParameter();
                P1.ParameterName = "Blog_FAQ_Id";
                P1.Value = Blog_FAQ_Id;
                sqlCommand.Parameters.Add(P1);

                var P2 = sqlCommand.CreateParameter();
                P2.ParameterName = "Blog_Id";
                P2.Value = Blog_Id;
                sqlCommand.Parameters.Add(P2);

                _db.LoadDataSet(sqlCommand, dataSet, TableName);
                DataSet ds = dataSet;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<Blog_FAQ_Business>(ds.Tables[0]);
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
