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
    public class Knowledge_Base_Repository : BaseRepository<Knowledge_Base>
    {
        public IList<Knowledge_Base> ListKnowledgeBase(int? Knowledge_Base_Id, string Knowledge_Base_Url_Link)
        {
            IList<Knowledge_Base> List_Obj = null;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database database = factory.Create("DefConn");
                DbCommand sqlCommand = database.GetStoredProcCommand("sp_List_Knowledge_Base");
                DataSet dataset = new DataSet();

                var p1 = sqlCommand.CreateParameter();
                p1.ParameterName = "Knowledge_Base_Id";
                p1.Value = Knowledge_Base_Id;
                sqlCommand.Parameters.Add(p1);

                var P2 = sqlCommand.CreateParameter();
                P2.ParameterName = "Knowledge_Base_Url_Link";
                P2.Value = Knowledge_Base_Url_Link;
                sqlCommand.Parameters.Add(P2);

                database.LoadDataSet(sqlCommand, dataset, TableName);

                DataSet ds = dataset;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<Knowledge_Base>(ds.Tables[0]);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return List_Obj;
        }
    }
}
