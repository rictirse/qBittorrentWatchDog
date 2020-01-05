using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Threading;
using System.Windows.Forms;

namespace WatchDog
{
    public partial class Frm : Form
    {
        System.Windows.Forms.Timer UpdataTimer       = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer CheckTimer        = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer CheckProcessTimer = new System.Windows.Forms.Timer();
        List<int> ls_Avg = new List<int>();
        int Count        = 0;
        string log       = "";
        const int course = 600; //取樣600個，1秒取一次等於10分鐘取樣

        public Frm()
        {
            InitializeComponent();

            //更新下載流量timer
            UpdataTimer.Interval = 1000; // 1sec
            UpdataTimer.Tick    += new EventHandler(this.OnUpdateInfoDate);
            UpdataTimer.Enabled  = true;

            //確認流量是否低於門檻值
            CheckTimer.Interval = 600000; //10 min
            CheckTimer.Tick    += new EventHandler(this.OnCheckDate);
            CheckTimer.Enabled  = true;

            //確認軟體是否存在，如果被關掉就會重新開啟
            CheckProcessTimer.Interval = 60000; //1 min
            CheckProcessTimer.Tick    += new EventHandler(this.OnCheckProcess);
            CheckProcessTimer.Enabled  = true;
        }

        public void OnCheckDate(object sender, EventArgs e)
        {
            int Threshold;

            if (int.TryParse(tb_threshold.Text, out Threshold))
            {
                int dataAvg = (int)ls_Avg.Average();

                if (Count != 0 && // 總計數大於零
                    dataAvg < Threshold) // 門檻值小於平均流量
                {
                    log = string.Format("{0}{1} {2}: Restart | {3}/{4}\r\n",
                        log,
                        DateTime.Now.ToShortDateString(),
                        DateTime.Now.TimeOfDay,
                        Threshold,
                        dataAvg);

                    tb_log.Text = log;
                    ResetData();
                    Restart();
                }
            }
        }

        private void OnCheckProcess(object sender, EventArgs e)
        {
            Process[] qBittorrentPrt;
            qBittorrentPrt = Process.GetProcessesByName("qbittorrent");
            if (qBittorrentPrt.Length == 0) //開啟數量等於0 就重開
            {
                Runqbittorrent();
            }
        }

        private void Restart()
        {
            Process[] qBittorrentPrt;
            qBittorrentPrt = Process.GetProcessesByName("qbittorrent");
            foreach (Process item in qBittorrentPrt)
            {
                try
                {
                    item.Kill();
                    Thread.Sleep(1000);
                    Runqbittorrent();

                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }
        }

        private void Runqbittorrent()
        {
            log = string.Format("{0}{1} {2}: Restart qBittorrent}\r\n",
                log,
                DateTime.Now.ToShortDateString(),
                DateTime.Now.TimeOfDay);

            tb_log.Text = log;

            Process memProcess = new Process();
            memProcess.StartInfo.FileName = "C:\\Program Files\\qBittorrent\\qbittorrent.exe";
            memProcess.StartInfo.UseShellExecute = true;
            memProcess.Start();
        }

        private void ResetData()
        {
            ls_Avg.Clear();
            Count = 0;
        }

        public void OnUpdateInfoDate(object sender, EventArgs e)
        {
            int dataPerSec = GetBytesReceivedPerSec();

            if (ls_Avg.Count <= course)
            {

                ls_Avg.Add(dataPerSec);

            }
            else
            {
                ls_Avg[Count] = dataPerSec;
                Count++;
                if (Count >= course) Count = 1;
            }

            lb_BytesReceivedPerSec.Text = string.Format("BytesReceivedPerSec：{0} Kbps", dataPerSec);
            lb_BytesReceivedAvg.Text    = string.Format("BytesReceivedAvg：{0:F2} Kbps", ls_Avg.Average());
            lb_Status.Text              = string.Format("Status：ListCount：{0} | Course：{1}/{2}", ls_Avg.Count, Count, course);
        }

        static private int GetBytesReceivedPerSec()
        {
            int Kbps = 0;
            UInt64 bps = 0;

            ObjectQuery winQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Tcpip_NetworkInterface");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(winQuery);
            foreach (ManagementObject item in searcher.Get())
            {
                bps += Convert.ToUInt64(item["BytesReceivedPerSec"]);
            }
            Kbps = (int)(bps / 1024 * 0.8); //bps Conver to Kbps
            
            return Kbps;
        }

        private void Tb_threshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
