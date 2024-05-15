using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitRoutes
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Split_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            int perId = 0;
            int idWlk;
            int dtCnt = 0;
            List<int> perList = new List<int>();
            List<RoutesOut> rOutLst = new List<RoutesOut>();
            int chkCnt = WalksCheckedListBox.CheckedItems.Count;

            //createPersCsv() .......
            if (chkCnt > 0)
            {
                foreach (var chkItem in WalksCheckedListBox.CheckedItems)
                {
                    j++;
                    label2.Text = "Route " + j + " of " + chkCnt;
                    Application.DoEvents();
                    idWlk = new Walks().getWalkID(chkItem.ToString());
                    if (idWlk > 0)
                    {
                      
                        List<WalkDetails> wdl = new WalkDetails().rtList(idWlk);
                        if (wdl != null && wdl.Count > 0)
                        {
                            i = 0;
                            dtCnt = wdl.Count;
                            if(rOutLst.Count > 0)
                            {
                                rOutLst.Clear();
                            }
                            foreach (WalkDetails wd in wdl)
                            {
                                i++;
                                if (wd.dcLink > 0)
                                {
                                    label1.Text = i + "/" + dtCnt + " Route " + chkItem.ToString() + " ... Getting account details for meter " + wd.meterNo;
                                    Application.DoEvents();
                                    wd.clt = new Client().GetClient(wd.dcLink);
                                    //Get latest reading by retriveing last period id first
                                    perId = new MeterReadingDetails().getMaxPer(wd.meterId);
                                    if (perId > 0)
                                    {
                                        wd.pRead = new MeterReadingDetails().getReading(wd.meterId, perId);
                                        RoutesOut r = new RoutesOut();
                                        r.icon = "av-timer";
                                        r.status = "red";
                                        if (wd.clt != null)
                                        {
                                            if (!string.IsNullOrWhiteSpace(wd.clt.accAdd))
                                            {
                                                r.address = wd.clt.accAdd;
                                                r.clientName = wd.clt.accName;
                                            }
                                            else
                                            {
                                                r.address = "";
                                                r.clientName = "";
                                            }
                                        }
                                        else
                                        {
                                            r.address = "";
                                            r.clientName = "";
                                        }
                                        r.lastReading = wd.pRead;

                                        r.meterNumber = wd.meterNo;
                                        rOutLst.Add(r);
                                        if (!perList.Contains(perId))
                                        {
                                            perList.Add(perId);
                                        }
                                    }
                                }
                            }    
                        }
                        
                    }
                    if(rOutLst.Count > 0)
                    {
                        createRouteCsv(chkItem.ToString(), rOutLst);
                    }
                }
                //string comm = "/C c:\\docs\\rtcpy.bat";
                //Process.Start("cmd.exe", comm);
                label1.Text = "Routes Splitting completed. Output in folder c:\\docs\\RoutesTst\\";
            }
        }

        private void createRouteCsv(string pRouteNumber, List<RoutesOut> pROutLst)
        {
            
            using (var writer = new StreamWriter("c:\\docs\\RoutesTst\\" + pRouteNumber + ".csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(pROutLst);
            }
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            int i = 0;
            if (!Directory.Exists(@"c:\docs\RoutesTst"))
            {
                Directory.CreateDirectory(@"c:\docs\RoutesTst");
            }
            string folderPath = @"c:\docs\RoutesTst\";

            // Get all file paths in the folder
            string[] filePaths = Directory.GetFiles(folderPath);

            // Delete each file
            foreach (string filePath in filePaths)
            {
                File.Delete(filePath);
            }
            List<string> wLst = new Walks().getWalks();
            if (wLst.Count > 0)
            {
                var walkItms = WalksCheckedListBox.Items;
                foreach (string w in wLst)
                {
                    walkItms.Add(w);
                }
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            for(int i = 0;i < WalksCheckedListBox.Items.Count;i++)
            {
                WalksCheckedListBox.SetItemChecked(i, true);
            }
        }

        private void btn_Deselect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < WalksCheckedListBox.Items.Count; i++)
            {
                WalksCheckedListBox.SetItemChecked(i, false);
            }
        }
    }
}
