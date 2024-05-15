using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitRoutes
{
    class Client
    {
        public int dcLink;
        private string accNo;
        public string accName;
        public string accAdd;

        public Client GetClient(int pDcLink)
        {
            object obj;
            string phyAd;
            string Addr = "";
            ConnClass clx = new ConnClass();
            clx.OpenCon();
            SqlCommand InsCmd = clx.SysCon.CreateCommand();
            InsCmd.CommandTimeout = 300;
            InsCmd.CommandText = "select account,name,Physical1,Physical2,Physical3," +
            "Physical4,Physical5 from client where dcLink = " + pDcLink;
            try
            {
                SqlDataReader dr = InsCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Client c = new Client();
                        c.dcLink = pDcLink;
                        c.accNo = dr[0].ToString();
                        c.accName = dr[1].ToString();
                        phyAd = dr[2].ToString();
                        if(!string.IsNullOrWhiteSpace(phyAd))
                        {
                            Addr = phyAd;
                        }
                        phyAd = dr[3].ToString();
                        if (!string.IsNullOrWhiteSpace(phyAd))
                        {
                            Addr = Addr + "," + phyAd;
                        }
                        phyAd = dr[4].ToString();
                        if (!string.IsNullOrWhiteSpace(phyAd))
                        {
                            Addr = Addr + "," + phyAd;
                        }
                        phyAd = dr[5].ToString();
                        if (!string.IsNullOrWhiteSpace(phyAd))
                        {
                            Addr =  Addr + "," + phyAd;
                        }
                        phyAd = dr[6].ToString();
                        if (!string.IsNullOrWhiteSpace(phyAd))
                        {
                            Addr =  Addr + "," + phyAd;
                        }
                        c.accAdd = Addr;
                        clx.CloseCon();
                        return c;
                    }
                }
                return null;
                //MessageBox.Show("Code count " + namn.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                clx.CloseCon();
                return null;
            }
        }
    }
}
