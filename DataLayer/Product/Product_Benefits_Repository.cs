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
  public  class Product_Benefits_Repository : BaseRepository<Product_Benefits>
    {
        public IList<Product_Benefits_Business> ListProductBenefits(int? Product_Benefits_Id, int? Product_Id)
        {
            IList<Product_Benefits_Business> List_Obj = null;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database _db = factory.Create("DefConn");
                DbCommand sqlCommand = _db.GetStoredProcCommand("sp_List_Product_Benefits");
                sqlCommand.CommandTimeout = 120;
                DataSet dataSet = new DataSet();

                var P1 = sqlCommand.CreateParameter();
                P1.ParameterName = "Product_Benefits_Id";
                P1.Value = Product_Benefits_Id;
                sqlCommand.Parameters.Add(P1);

                var P2 = sqlCommand.CreateParameter();
                P2.ParameterName = "Product_Id";
                P2.Value = Product_Id;
                sqlCommand.Parameters.Add(P2);

                _db.LoadDataSet(sqlCommand, dataSet, TableName);
                DataSet ds = dataSet;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<Product_Benefits_Business>(ds.Tables[0]);
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
