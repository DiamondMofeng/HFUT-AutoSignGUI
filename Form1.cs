using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace HFUT_AutoSignGUI
{
    

    //整体思路：
    /* 软件包括两级目录，一级目录下存放.exe,main.py,config.json(为保证安全可能设为隐藏)
     * 二级目录为python.exe解释器，包括所用到的第三方库
     * 
     * 运行流程：
     * 1.   初次设定: 
     *      获取exe所在目录，为内部解释器配置环境变量，（为main.py配置config.json文件的绝对路径）
     *          
     * 2.   填写完基本信息后，点击保存按钮将信息填入config.json，
     *      点击测试按钮后，调用main.py进行测试，返回测试结果并将其显示于窗口中
     *      
     * 3.   定时任务：
     *      (1)软件每次启动时，读取系统当前存在的定时任务，将符合条件的显示于窗口中，方便用户了解当前定时信息
     *      (2.1)时间输入窗口须对输入数据进行检查, >= 14:00
     *      (2.2)点击添加定时任务按钮，运行cmd程序将定时任务写入
     *      
     * 
     * 
     * 
     */
    public partial class Form1 : Form
    {
        string Version = "1.0.0b";
        public Form1()
        {
            InitializeComponent();
            LoadSettings();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            scripts.LoadTasks("XMLTasks.xml", listView_t);
        }
        private void LoadSettings()
        {
            //
            textBox_b_acc.Text = AppSettings.Default.acc;
            textBox_b_pass.Text = AppSettings.Default.pass;
            //
            textBox_e_smtp.Text = AppSettings.Default.smtpServer;
            textBox_e_smtpAuth.Text = AppSettings.Default.smtpAuth;
            textBox_e_sender.Text = AppSettings.Default.sender;
            textBox_e_receiver.Text = AppSettings.Default.receiver;

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //textBox_e_smtp.Enabled = checkBox_email.Checked;
            //textBox_e_sender.Enabled = checkBox_email.Checked;
            //textBox_e_smtpAuth.Enabled = checkBox_email.Checked;
            //textBox_e_receiver.Enabled = checkBox_email.Checked;
        }

        private void checkBox_b_showpass_CheckedChanged(object sender, EventArgs e)
        {
            textBox_b_pass.UseSystemPasswordChar = !checkBox_b_showpass.Checked;
        }
        private void checkBox_e_showpass_CheckedChanged(object sender, EventArgs e)
        {
            textBox_e_smtpAuth.UseSystemPasswordChar = !checkBox_e_showpass.Checked;
        }
        

        private void button_t_get_Click(object sender, EventArgs e)
        {
            textBox_t_get.Text = "";
            //textBox_t_get.Text = common.getSchtasks();
            textBox_t_get.Text = scripts.signTest(textBox_b_acc.Text, textBox_b_pass.Text
                , EmailEnabled
                , textBox_e_smtp.Text, textBox_e_sender.Text
                , textBox_e_smtpAuth.Text, textBox_e_receiver.Text);
        }
        /// <summary>
        /// 点击按钮时，首先对输入时间进行检查，若无问题，则设定自动打卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



        private void listView_t_SelectedIndexChanged(object sender, EventArgs e)
        {





        }

        private void button_t_add_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.ShowDialog();
            //Form2关闭后重新载入XMLTasks
            scripts.LoadTasks("XMLTasks.xml", listView_t);
        }



        private void button_t_del_Click(object sender, EventArgs e)// 点击按钮时删除所选项
        {
            MessageBoxButtons confirmButtons = MessageBoxButtons.OKCancel;
            if (listView_t.SelectedItems.Count != 0)
            {
                DialogResult dr = MessageBox.Show("确认要删除所选项吗？", "确认操作", confirmButtons);
                if (dr == DialogResult.OK)
                {

                    //在xml中删除对应项
                    //先获取想删除的ID
                    ListViewItem SelectedTaskItem = listView_t.SelectedItems[0];
                    string TaskID = SelectedTaskItem.Text;
                    scripts.DeleteTask("XMLTasks.xml", TaskID);

                    //再在listview中删除对应项

                    for (int i = listView_t.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        ListViewItem selectedTasks = listView_t.SelectedItems[i];
                        listView_t.Items.Remove(selectedTasks);
                    }


                }
                else return;
            }



        }

        private void textBox_b_acc_TextChanged(object sender, EventArgs e)
        {
            AppSettings.Default.acc = textBox_b_acc.Text;
            AppSettings.Default.Save();
        }

        private void textBox_b_pass_TextChanged(object sender, EventArgs e)
        {
            AppSettings.Default.pass = textBox_b_pass.Text;
            AppSettings.Default.Save();
        }

        private void textBox_e_smtp_TextChanged(object sender, EventArgs e)
        {
            AppSettings.Default.smtpServer = textBox_e_smtp.Text;
            AppSettings.Default.Save();
        }

        private void textBox_e_sender_TextChanged(object sender, EventArgs e)
        {
            AppSettings.Default.sender = textBox_e_sender.Text;
            AppSettings.Default.Save();
        }

        private void textBox_e_smtpAuth_TextChanged(object sender, EventArgs e)
        {
            AppSettings.Default.smtpAuth = textBox_e_smtpAuth.Text;
            AppSettings.Default.Save();
        }

        private void textBox_e_receiver_TextChanged(object sender, EventArgs e)
        {
            AppSettings.Default.receiver = textBox_e_receiver.Text;
            AppSettings.Default.Save();
        }

        private void button_e_test_Click(object sender, EventArgs e)
        {

            if (scripts.TestEmail(textBox_e_sender.Text,
                textBox_e_receiver.Text,
                textBox_e_smtp.Text,
                textBox_e_smtpAuth.Text) == true)
            {
                label_e_testResult.Text = "测试成功！";
                label_e_testResult.ForeColor = Color.Green;
            }
            else
            {
                label_e_testResult.Text = "测试失败！";
                label_e_testResult.ForeColor = Color.Red;
            }
        }

        private void button_b_test_Click(object sender, EventArgs e)
        {

            if (textBox_b_acc.Text == "" || textBox_b_pass.Text == "")
            {
                label_b_testResult.Text = "测试失败！";
                label_b_testResult.ForeColor = Color.Red;
                return;
            }
            else if (scripts.TestLogin(textBox_b_acc.Text, textBox_b_pass.Text) == true)
            {
                label_b_testResult.Text = "测试成功！";
                label_b_testResult.ForeColor = Color.Green;
            }
            else
            {
                label_b_testResult.Text = "测试失败！";
                label_b_testResult.ForeColor = Color.Red;
            }
        }

        string EmailEnabled = "0";
        private void checkBox_e_enable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_e_enable.Enabled == true) EmailEnabled = "1";
            if (checkBox_e_enable.Enabled == false) EmailEnabled = "0";
        }

        
    }
    public class common
    {
        //这是一个工具类，存放全局函数和变量

        //public static ListViewItem selectedTasks;
        //public static string EmailEnabled1 = "0";
        //public static string EmailEnabled2 = "0";






        

        /// <summary>
        /// 获取并处理计划任务中关于自动打卡程序的信息，并以string返回相关信息
        /// </summary>
        /// <returns>string 自动打卡信息</returns>
        public static string getSchtasks()
        {

            return GetTaskInfo();
        }
        /// <summary>
        /// 获取并返回计划任务中所有信息
        /// </summary>
        /// <returns>string 计划任务中所有信息</returns>
        private static string GetTaskInfo()
        {
            //启动cmd

            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            //启动程序
            p.Start();

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine("schtasks /query" + "&exit");

            p.StandardInput.AutoFlush = true;

            //获取输出信息
            string strOuput = p.StandardOutput.ReadToEnd();
            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();

            return strOuput;

            //Console.WriteLine(strOuput);

            //Console.ReadKey();
        }
        private static string ProcessInfo()
        {
            //string a = "123";
            //a.IndexOf



            return "123";
        }
    }
}
