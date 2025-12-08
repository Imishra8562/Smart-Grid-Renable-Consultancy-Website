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
    public class Demo_Follow_Up_Repository : BaseRepository<Demo_Follow_Up>
    {
        public IList<Demo_Follow_Up_Business> ListDemoFollowUp(int? Demo_Follow_Up_Id, string Demo_Follow_Up_Code, int? Software_Demo_Id, bool? Is_Active, int? Created_By)
        {
            IList<Demo_Follow_Up_Business> List_Obj = null;

            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database _db = factory.Create("DefConn");
                DbCommand sqlCommand = _db.GetStoredProcCommand("sp_List_Demo_Follow_Up");
                DataSet dataSet = new DataSet();

                var P1 = sqlCommand.CreateParameter();
                P1.ParameterName = "Demo_Follow_Up_Id";
                P1.Value = Demo_Follow_Up_Id;
                sqlCommand.Parameters.Add(P1);

                var P11 = sqlCommand.CreateParameter();
                P11.ParameterName = "Demo_Follow_Up_Code";
                P11.Value = Demo_Follow_Up_Code;
                sqlCommand.Parameters.Add(P11);


                var P2 = sqlCommand.CreateParameter();
                P2.ParameterName = "Software_Demo_Id";
                P2.Value = Software_Demo_Id;
                sqlCommand.Parameters.Add(P2);

                var P4 = sqlCommand.CreateParameter();
                P4.ParameterName = "Is_Active";
                P4.Value = Is_Active;
                sqlCommand.Parameters.Add(P4);

                var P5 = sqlCommand.CreateParameter();
                P5.ParameterName = "Created_By";
                P5.Value = Created_By;
                sqlCommand.Parameters.Add(P5);


                _db.LoadDataSet(sqlCommand, dataSet, TableName);

                DataSet ds = dataSet;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<Demo_Follow_Up_Business>(ds.Tables[0]);
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
