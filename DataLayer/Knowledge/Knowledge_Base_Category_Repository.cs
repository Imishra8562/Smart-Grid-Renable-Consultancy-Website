using Domain;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Knowledge_Base_Category_Repository :BaseRepository<Knowledge_Base_Category>
    {
        public IList<Knowledge_Base_Category> ListKnowledgeBaseCategory(int? Knowledge_Base_Category_Id, string Category_Url_Link)
        {
            IList<Knowledge_Base_Category> List_Obj = null;

            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database _db = factory.Create("DefConn");
                DbCommand sqlCommand = _db.GetStoredProcCommand("sp_List_Knowledge_Base_Category");
                DataSet dataSet = new DataSet();

                var KBC_ID = sqlCommand.CreateParameter();
                KBC_ID.ParameterName = "Knowledge_Base_Category_Id";
                KBC_ID.Value = Knowledge_Base_Category_Id;
                sqlCommand.Parameters.Add(KBC_ID);

                var P2 = sqlCommand.CreateParameter();
                P2.ParameterName = "Category_Url_Link";
                P2.Value = Category_Url_Link;
                sqlCommand.Parameters.Add(P2);

                _db.LoadDataSet(sqlCommand, dataSet, TableName);

                DataSet ds = dataSet;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<Knowledge_Base_Category>(ds.Tables[0]);
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
