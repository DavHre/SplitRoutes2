using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitRoutes
{
    class WalkDetails
    {
        public int meterId;
        public string meterNo;
        public float pRead;
        public int dcLink;
        public Client clt;

        public List<WalkDetails> rtList(int pIWalkId)
        {
            List<WalkDetails> wdList = new List<WalkDetails>();
            object obj;
            ConnClass clx = new ConnClass();
            clx.OpenCon();
            SqlCommand InsCmd = clx.SysCon.CreateCommand();
            //InsCmd.CommandText = "select iWalkMeterId from _mtblWalkDetails where " +
            //"iWalkId = " + pIWalkId;
            InsCmd.CommandText = "select m.WalkID,m.ID,m.Number,s.CustomerID " +
            "from _ccg_EB_Meters m left join _ccg_EB_PropertyServices s on s.MeterID = m.ID " +
             "where WalkID = " + pIWalkId + " order by CustomerID";


            try
            {
                SqlDataReader dr = InsCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        WalkDetails w = new WalkDetails();
                        //w.meterId = Convert.ToInt32(dr[2]);
                        //w.meterNo = dr[3].ToString();
                        w.meterId = Convert.ToInt32(dr[1]);
                        w.meterNo = dr[2].ToString();

                        obj = dr[3];
                        if(dr[3] == System.DBNull.Value)
                        {
                            w.dcLink = 0;
                        }
                        else
                        {
                            w.dcLink = Convert.ToInt32(obj);
                        }
                        //w.dcLink = Convert.ToInt32(dr[4]);
                        wdList.Add(w);
                    }
                    return wdList;
                }
                return null;
                //MessageBox.Show("Code count " + namn.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
    }
}
