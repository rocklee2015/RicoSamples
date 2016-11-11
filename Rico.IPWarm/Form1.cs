using SoDao.Service.PublicDB;
using SoDao.Service.PublicDB.PublicDBWcf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPWarmInitial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInitial_Click(object sender, EventArgs e)
        {
            string root = System.AppDomain.CurrentDomain.BaseDirectory;
            ReadAndWrite(root + "ip.txt", root + "Result.txt");
        }
        private Dictionary<string, Sodao.IPSearch.Service.Thrift.IPData> ReadIp(List<string> ips)
        {
            var ipResult = Sodao.IPSearch.Service.Thrift.ThriftProxy.IPSearchService.IPData_List(ips).Result;//("批量获取ip地址信息失败");
            return ipResult;
        }
        public void WriteTxt(string path,string message)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.WriteLine(message);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        public void ReadAndWrite(string readPath, string writePath)
        {
            StreamReader readSR = new StreamReader(readPath, Encoding.Default);
            FileStream fs = new FileStream(writePath, FileMode.Create);
            StreamWriter writeSW = new StreamWriter(fs, Encoding.Default);
            String line;
            List<string> ips = new List<string>();
            long total = 0,success=0,fail=0;
            string root = System.AppDomain.CurrentDomain.BaseDirectory;
            string successFile = root + "success.txt";
            string failFile = root + "fail.txt";
            FileStream sucessFS = new FileStream(successFile, FileMode.Create);
            StreamWriter sucessSW = new StreamWriter(sucessFS, Encoding.Default);
            FileStream failFs = new FileStream(failFile, FileMode.Create);
            StreamWriter failSW = new StreamWriter(failFs, Encoding.Default);

            while ((line = readSR.ReadLine()) != null)
            {
                ips.Add(line);
                var ipResult = ReadIp(ips);
                Sodao.IPSearch.Service.Thrift.IPData ipData = null;
                ipResult.TryGetValue(line,out ipData);
                if (ipData != null)
                {
                    var msg = line + "\t" + ipData.Address1 + "\t";
                    SqlExcute(string.Format("update IPWarmDetail set IpAddress='{0}'  where Ip='{1}'", ipData.Address1,line));
                    if (string.IsNullOrEmpty(ipData.Address1))
                    {
                        fail++;
                        failSW.WriteLine(msg+fail);
                    }
                    else
                    {
                        success++;
                        sucessSW.WriteLine(msg + success);
                    }
                    Write(richTextBox1, msg);
                    writeSW.WriteLine(msg);
                }
            }
            writeSW.Flush();
            writeSW.Close();

            sucessSW.Flush();
            sucessSW.Close();
            sucessFS.Close();

            failSW.Flush();
            failSW.Close();
            failFs.Close();

            fs.Close();
            readSR.Close();
        }
        /// <summary>
        /// 废弃
        /// </summary>
        /// <param name="readPath"></param>
        /// <param name="writePath"></param>
        public void ReadAndWrite1(string readPath, string writePath)
        {
            StreamReader readSR = new StreamReader(readPath, Encoding.Default);
            FileStream fs = new FileStream(writePath, FileMode.Create);
            StreamWriter writeSW = new StreamWriter(fs);
            String line;
            List<string> ips = new List<string>();
            while ((line = readSR.ReadLine()) != null)
            {
                ips.Add(line);
                Write(richTextBox1, line);
                writeSW.WriteLine(line.ToString() + "\t匹配成功！");
                var ipResult = ReadIp(ips);
                Task.Factory.StartNew(() =>
                {
                    //StringBuilder sqlStr = new StringBuilder();
                    foreach (var ip in ipResult)
                    {
                        //sqlStr.AppendFormat("update IPWarmDetail set IpAddress='{0}'  where Ip='{1}';", ip.Value.Address1, ip.Key);
                        SqlExcute(string.Format("update IPWarmDetail set IpAddress='{0}'  where Ip='{1}';", ip.Value.Address1, ip.Key));
                    }
                    // SqlExcute(sqlStr.ToString());
                });
                ips.Clear();
            }
            //清空缓冲区
            writeSW.Flush();
            //关闭流
            writeSW.Close();
            fs.Close();
            readSR.Close();
        }
        public void SqlExcute(string sqlText)
        {
            using (SqlConnection Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ERP"].ToString()))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = sqlText;
                command.CommandType = CommandType.Text;
                
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                command.Connection = Connection;
                var result=command.ExecuteNonQuery();
            }
        }
        public DataTable GetDataTable(string sqlText)
        {
            using (SqlConnection Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ERP"].ToString()))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = sqlText;
                command.CommandType = CommandType.Text;

                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                command.Connection = Connection;

                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    DataSet ds = new DataSet();
                    // 填充DataSet.   
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
        public void SqlExcute2()
        {
            foreach (var sql in new List<string> { "update table set name='11' where id=1","...." })
            {
                SqlExcute(sql);
            }
        }
        public void SqlExcute1()
        {
            using (SqlConnection Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ERP"].ToString()))
            {
                SqlCommand command = new SqlCommand();

                command.CommandType = CommandType.Text;
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                foreach (var sql in new List<string> { "update table set name='11' where id=1" })
                {
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }

            }
        }
        public void Write(Control control, string str)
        {
            System.Windows.Forms.MethodInvoker invoker = () =>
            {
                var rich = control as RichTextBox;
                rich.Text += str + "\r\n";
                rich.Select();//让RichTextBox获得焦点 
                rich.Select(rich.TextLength, 0);//将插入符号置于文本结束处 
                rich.ScrollToCaret();

            };
            if (control.InvokeRequired)
            {
                control.Invoke(invoker);
            }
            else
            {
                invoker();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateIpAddress();
        }
        public void UpdateIpAddress()
        {
            Write(richTextBox1, "数据查询中...");
            var dt = GetDataTable("select distinct ip from IPWarmDetail where [IpAddress] is null or [IpAddress]=''");
            Write(richTextBox1, "数据查询OK!");
            Write(richTextBox1, "供查询"+dt.Rows.Count+"条数据");
            List<string> ips = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var ip = dt.Rows[i]["ip"].ToString();
                ips.Add(ip);
               
                if (i % 100 == 0&&i!=0)
                {
                    MatchAndUpdateIpAddress(ips);
                    ips.Clear();
                    Write(richTextBox1, string.Format("共{0}条数据，剩余{1}条",dt.Rows.Count, dt.Rows.Count-i));
                }
            }
            if (ips.Count > 0)
            {
                MatchAndUpdateIpAddress(ips);
                ips.Clear();
            }
            Write(richTextBox1, "执行完成!");
        }
        public void MatchAndUpdateIpAddress(List<string> ips)
        {
            Write(richTextBox1, "匹配IP开始！");
            var ipDatas = ReadIp(ips);
            Write(richTextBox1, "匹配IP结束！");
            foreach (var ipData in ipDatas)
            {
                if (ipData.Value != null && !string.IsNullOrEmpty(ipData.Value.Address1))
                {
                    SqlExcute(string.Format("update IPWarmDetail set IpAddress='{0}'  where Ip='{1}'", ipData.Value.Address1, ipData.Key));
                    Write(richTextBox1, string.Format("{0}\t{1}", ipData.Key, ipData.Value.Address1));
                }
                else
                {
                    Write(richTextBox1, string.Format("{0}\t{1}", ipData.Key, "IP Not Found"));
                }
            }
            Write(richTextBox1, "更新IP结束！");

        }
    }
}
