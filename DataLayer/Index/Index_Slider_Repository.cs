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
    public class Index_Slider_Repository :BaseRepository<Index_Slider>
    {
        public IList<Index_Slider_Business> ListIndexSlider(int? Index_Slider_Id, int? Index_Seo_Id)
        {
            IList<Index_Slider_Business> List_Obj = null;

            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database _db = factory.Create("DefConn");
                DbCommand sqlCommand = _db.GetStoredProcCommand("sp_List_Index_Slider");
                DataSet dataSet = new DataSet();

                var p1 = sqlCommand.CreateParameter();
                p1.ParameterName = "Index_Slider_Id";
                p1.Value = Index_Slider_Id;
                sqlCommand.Parameters.Add(p1);

                var P2 = sqlCommand.CreateParameter();
                P2.ParameterName = "Index_Seo_Id";
                P2.Value = Index_Seo_Id;
                sqlCommand.Parameters.Add(P2);

                _db.LoadDataSet(sqlCommand, dataSet, TableName);

                DataSet ds = dataSet;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<Index_Slider_Business>(ds.Tables[0]);
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
