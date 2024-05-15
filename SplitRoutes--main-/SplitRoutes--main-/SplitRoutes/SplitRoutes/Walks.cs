using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitRoutes
{
    class Walks
    {
        public List<string> getWalks()
        {
            List<string> walkList = new List<string>();
            ConnClass clx = new ConnClass();
            clx.OpenCon();
            SqlCommand InsCmd = clx.SysCon.CreateCommand();
            InsCmd.CommandTimeout = 300;
            InsCmd.CommandText = "select Code from _ccg_EB_Walks order by Code";
            try
            {
                SqlDataReader dr = InsCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        walkList.Add(dr[0].ToString());
                    }
                }
                return walkList;
                //MessageBox.Show("Code count " + namn.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return walkList;
            }
        }

        public int getWalkID(string pWalkCode)
        {
            int idWalk = 0;
            ConnClass clx = new ConnClass();
            clx.OpenCon();
            SqlCommand InsCmd = clx.SysCon.CreateCommand();
            InsCmd.CommandTimeout = 300;
            InsCmd.CommandText = "select ID from _ccg_EB_Walks where Code = " + "'" + pWalkCode + "'";
            try
            {
                SqlDataReader dr = InsCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        idWalk = Convert.ToInt32(dr[0]);
                    }
                }
                clx.CloseCon();
                return idWalk;
                //MessageBox.Show("Code count " + namn.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                clx.CloseCon();
                return -1;
            }
        }
    }
}
