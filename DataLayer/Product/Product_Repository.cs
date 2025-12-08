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
    public class Product_Repository : BaseRepository<Product>
    {
        public IList<Product_Business> ListProduct(int? Product_Id, int? Industries_Id, string Product_Url_Link)
        {
            IList<Product_Business> List_Obj = null;

            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database _db = factory.Create("DefConn");
                DbCommand sqlCommand = _db.GetStoredProcCommand("sp_List_Product");
                DataSet dataSet = new DataSet();

                var P1 = sqlCommand.CreateParameter();
                P1.ParameterName = "Product_Id";
                P1.Value = Product_Id;
                sqlCommand.Parameters.Add(P1);

                var P2 = sqlCommand.CreateParameter();
                P2.ParameterName = "Industries_Id";
                P2.Value = Industries_Id;
                sqlCommand.Parameters.Add(P2);

               var P3 = sqlCommand.CreateParameter();
                P3.ParameterName = "Product_Url_Link";
                P3.Value = Product_Url_Link;
                sqlCommand.Parameters.Add(P3);

                _db.LoadDataSet(sqlCommand, dataSet, TableName);

                DataSet ds = dataSet;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<Product_Business>(ds.Tables[0]);
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
