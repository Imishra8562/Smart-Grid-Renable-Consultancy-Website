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
    public class Industries_Repository : BaseRepository<Industries>
    {
        public IList<Industries> ListIndustries(int? Industries_Id, string Industries_Url_Link)
        {
            IList<Industries> List_Obj = null;

            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database _db = factory.Create("DefConn");
                DbCommand sqlCommand = _db.GetStoredProcCommand("sp_List_Industries");
                DataSet dataSet = new DataSet();

                var BlogId = sqlCommand.CreateParameter();
                BlogId.ParameterName = "Industries_Id";
                BlogId.Value = Industries_Id;
                sqlCommand.Parameters.Add(BlogId);

                var P2 = sqlCommand.CreateParameter();
                P2.ParameterName = "Industries_Url_Link";
                P2.Value = Industries_Url_Link;
                sqlCommand.Parameters.Add(P2);

                _db.LoadDataSet(sqlCommand, dataSet, TableName);

                DataSet ds = dataSet;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<Industries>(ds.Tables[0]);
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
