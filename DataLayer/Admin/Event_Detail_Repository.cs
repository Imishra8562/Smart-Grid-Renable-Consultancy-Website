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

    public class Event_Detail_Repository : BaseRepository<Event_Detail>
    {
        public IList<Event_Detail_Business> ListEventDetail(int? Event_Detail_Id, int? Event_Id)
        {
            IList<Event_Detail_Business> List_Obj = null;

            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database _db = factory.Create("DefConn");
                DbCommand sqlCommand = _db.GetStoredProcCommand("sp_List_Event_Detail");
                DataSet dataSet = new DataSet();

                var EventDetailId = sqlCommand.CreateParameter();
                EventDetailId.ParameterName = "Event_Detail_Id";
                EventDetailId.Value = Event_Detail_Id;
                sqlCommand.Parameters.Add(EventDetailId);

                var EventId = sqlCommand.CreateParameter();
                EventId.ParameterName = "Event_Id";
                EventId.Value = Event_Id;
                sqlCommand.Parameters.Add(EventId);

                _db.LoadDataSet(sqlCommand, dataSet, TableName);

                DataSet ds = dataSet;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<Event_Detail_Business>(ds.Tables[0]);
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
