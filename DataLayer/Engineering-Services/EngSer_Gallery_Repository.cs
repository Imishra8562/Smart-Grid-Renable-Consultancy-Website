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
   public class EngSer_Gallery_Repository: BaseRepository<EngSer_Gallery>
    {

        public IList<EngSer_Gallery> ListEngSerGallery(int? EngSer_Gallery_Id,int? Engineering_Services_Id)
        {
            IList<EngSer_Gallery> List_Obj = null;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database _db = factory.Create("DefConn");
                DbCommand sqlCommand = _db.GetStoredProcCommand("sp_List_EngSer_Gallery");
                DataSet dataSet = new DataSet();

                var p1 = sqlCommand.CreateParameter();
                p1.ParameterName = "EngSer_Gallery_Id";
                p1.Value = EngSer_Gallery_Id;
                sqlCommand.Parameters.Add(p1);

                var P2 = sqlCommand.CreateParameter();
                P2.ParameterName = "Engineering_Services_Id";
                P2.Value = Engineering_Services_Id;
                sqlCommand.Parameters.Add(P2);

                _db.LoadDataSet(sqlCommand, dataSet, TableName);

                DataSet ds = dataSet;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<EngSer_Gallery>(ds.Tables[0]);
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
