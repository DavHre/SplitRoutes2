using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitRoutes
{
    class ConnClass
    {
        public static string wIpAdd = "192.168.0.6";
        public static string wUser = "sa";
        //public static string wUser = "Administrator";
        public static string wPass;
        public static string wUsrOptions;
        public static bool isConnected;
        //  public static string wLib = "biq";
        public static string wLib = "munhmf1";
        public static string wLib1 = "biqdta";
        public static int glbOpt;

        public static long wInan;
        public int wLastInan;

        public static string wSrc;

        //public string Con400Str = "Data Source=192.168.0.118;Initial Catalog=TestBilling;Integrated Security=SSPI";
        //public string Con400Str = "Data Source=192.168.0.118\\SAGESQLSERVER\\SQL2016,49771;Initial Catalog=Test Billing;User ID=" + "'" + wUser + "'" + ";" + "Password=Camelsa@123";
        //public string Con400Str = "Data Source=192.168.0.137\\SAGESQLSERVER01\\SQL2016,52387;Initial Catalog=City of Harare;User ID=" + "'" + wUser + "'" + ";" + "Password=Camelsa@123";
        //public string Con400Str0 = "Data Source=192.168.0.137;Initial Catalog=City of Harare;User ID=sa;Password=Camelsa@123";
        //public string Con400Str = "Server=192.168.0.137;Database=City of Harare;persist security info=True;MultipleActiveResultSets=True;User=sa;Password=Camelsa@123";
        //public string Con400Str = "Data Source=192.168.0.137\\sql2016;Initial Catalog=City of Harare;User ID=sa;Password=Camelsa@123";
        public string Con400Str = "Data Source=192.168.0.137\\coh;Initial Catalog=City of Harare;User ID=sa2;Password=hrE24!";
        public SqlConnection SysCon = new SqlConnection();

        public void OpenCon()
        {
            if (isConnected == true)
            {
                CloseCon();
            }
            try
            {
                SysCon.ConnectionString = Con400Str;
                SysCon.Open();
                isConnected = true;
                //MessageBox.Show("Connected to AS400");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed");
                MessageBox.Show(ex.ToString());
                isConnected = false;
            }
        }

        public void CloseCon()
        {
            SysCon.Close();
            isConnected = false;
        }
    }
}
