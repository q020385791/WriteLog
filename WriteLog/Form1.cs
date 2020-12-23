using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WriteLog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static string _Path = string.Empty;
        private void button1_Click(object sender, EventArgs e)
        {
            WriteLog(textBox1.Text);
        }

        public void WriteLog(string Message)
        {
            //取得當前目錄
            _Path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //如果Log資料夾不存在則創立資料夾
            string LogFolderPath = Path.Combine(_Path, "Log");
            if (!Directory.Exists(LogFolderPath))
            {
                Directory.CreateDirectory(LogFolderPath);
            }

            try
            {
                string LogName = "Log_" + DateTime.Today.Year.ToString() + "_" + DateTime.Today.Month.ToString() + "_" + DateTime.Today.Day.ToString()+ ".txt";

                using (StreamWriter w=File.AppendText(Path.Combine(LogFolderPath, LogName)))
                {
                    //throw new ArgumentException("這是錯誤訊息");
                    w.WriteAsync(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")+":>>>>"+Message);
                    w.WriteAsync(Environment.NewLine);
                }
                
            }
            catch (Exception ex)
            {
                string LogName = "Log_" + DateTime.Today.Year.ToString() + "_" + DateTime.Today.Month.ToString() + "_" + DateTime.Today.Day.ToString() + ".txt";

                using (StreamWriter w = File.AppendText(Path.Combine(_Path, LogName)))
                {

                    w.WriteAsync(ex.Message);
                }

            }

        }

    }
}
