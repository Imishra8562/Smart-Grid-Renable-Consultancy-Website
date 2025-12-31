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
    public class Engineering_Services_Tabs_Repository : BaseRepository<Engineering_Services_Tabs>
    {
        public IList<Engineering_Services_Tabs> ListEngineeringServicesTabs(int? Engineering_Services_Tabs_Id, int? Engineering_Services_Id)
        {
            IList<Engineering_Services_Tabs> List_Obj = null;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database _db = factory.Create("DefConn");
                DbCommand sqlCommand = _db.GetStoredProcCommand("sp_List_Engineering_Services_Tabs");
                DataSet dataSet = new DataSet();

                var P1 = sqlCommand.CreateParameter();
                P1.ParameterName = "Engineering_Services_Tabs_Id";
                P1.Value = Engineering_Services_Tabs_Id;
                sqlCommand.Parameters.Add(P1);

                var P2 = sqlCommand.CreateParameter();
                P2.ParameterName = "Engineering_Services_Id";
                P2.Value = Engineering_Services_Id;
                sqlCommand.Parameters.Add(P2);
                _db.LoadDataSet(sqlCommand, dataSet, TableName);
                DataSet ds = dataSet;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<Engineering_Services_Tabs>(ds.Tables[0]);
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
