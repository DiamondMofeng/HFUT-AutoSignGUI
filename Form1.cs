using System;
using System.Diagnostics;
using System.Drawing;
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
        string Version = "1.0.1";
        public Form1()
        {
            InitializeComponent();
            LoadSettings();


        }
        private void Form1_Load(object sender, EventArgs e)
        {

            if (scripts.Disclaimer() == false)
                this.Close();

            if (!System.IO.File.Exists("msedgedriver.exe") || !System.IO.File.Exists("AutoSignEXE.exe"))
            {
                MessageBox.Show("缺少运行所需exe文件，将退出程序。\r\n" + "请重新下载", "错误：缺少运行所需文件");
                this.Close();
            }

            //有空要做成自动生成的
            if (!scripts.IsXMLExists("XMLTasks.xml") || !scripts.IsXMLExists("TaskPattern.xml"))
            {
                MessageBox.Show("缺少运行所需xml文件，将退出程序。\r\n" + "请重新下载", "错误：缺少运行所需文件");
                this.Close();
            }

            MessageBox.Show("使用本软件前应确定好软件的位置，因为随便移动会导致问题：\r\n" +
                "如果添加任务后要挪动本软件的位置，或更改所在文件夹的名字\r\n" +
                "请务必先将所有任务删除！！！\r\n" +
                "请务必先将所有任务删除！！！\r\n" +
                "请务必先将所有任务删除！！！\r\n" +
                "否则以前添加的任务可能会无法进行/无法通过本软件删除，变为系统垃圾", "重要的事情说三遍");


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
            textBox_t_testResult.Text = "";
            //检查基础信息是否有遗漏
            //foreach (Control t in this.Controls)
            //{
            //    if (t is not TextBox) continue;
            //    if ((string)t.Tag == "tb")
            //    {
            //        if (t.Text == "" || t.Text.Contains(" "))
            //            textBox_t_testResult.Text = "信息不能为空，且不能有空格";
            //        return;
            //    }
            //    if ((string)t.Tag == "te" && checkBox_e_enable.Checked == true)
            //    {
            //        if (t.Text == "" || t.Text.Contains(" "))
            //        {
            //            textBox_t_testResult.Text = "信息不能为空，且不能有空格";
            //            return;
            //        }
            //    }
            //}

            //textBox_t_get.Text = common.getSchtasks();
            textBox_t_testResult.Text = scripts.signTest(textBox_b_acc.Text, textBox_b_pass.Text
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
                    scripts.DeleteTaskInXML("XMLTasks.xml", TaskID);

                    //在计划任务中删除对应项
                    scripts.DeleteTaskInSchTasks(TaskID);

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
            if (checkBox_e_enable.Checked == true) EmailEnabled = "1";
            if (checkBox_e_enable.Checked == false) EmailEnabled = "0";
        }

        private void button_t_test_Click(object sender, EventArgs e)
        {
            //如果没有选择，则不进行
            if (listView_t.SelectedItems.Count == 0)
            {
                return;
            }


            //清空现有信息
            textBox_t_testResult.Text = "";


            MessageBox.Show("已开始测试，短时间内请勿重复测试造成卡顿" +
                "\r\n请在大约半分钟后打开运行日志查看结果" +
                "\r\n(测试结果不会在下方显示)", "注意");

            //获取所选项id
            string taskID = listView_t.SelectedItems[0].Text;

            //用cmd
            //schtasks /run taskID来测试
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
            p.StandardInput.WriteLine("schtasks /run /tn " + taskID);

            p.StandardInput.AutoFlush = true;

            p.StandardInput.Close();
            //获取输出信息
            string strOuput = p.StandardOutput.ReadToEnd();
            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();

            textBox_t_testResult.Text = scripts.Fliter(strOuput);




        }

        private void 如何获取smtp相关信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://jingyan.baidu.com/article/b0b63dbf1b2ef54a49307054.html");
        }


        private void 免责声明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("若您使用本软件，则视为您已熟知并同意以下内容：" +
                    "\r\n①本软件仅供同学在确认所提交的疫情相关报备信息准确无误的情况下使用，软件所使用打卡信息为前一天成功提交的内容，若其中涉及的任何内容发生改变，须根据真实情况自行修改疫情信息报备内容。 因使用本脚本可能带来的任何风险问题均由使用者本人承担。" +
                    "\r\n②作者保证使用此软件所产生的敏感信息均仅存放于使用者的计算机中，且不会用于以目的为疫情信息填报以外的任何功能。" +
                    "\r\n③本软件遵循 GPL-2.0 开源协议"
                    , "免责声明");
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("本软件仅供学习交流，如作他用所承受的法律责任一概与作者无关" +
                "\r\n合工大自动打卡" + " Version:" + Version +
                "\r\n编程语言： C# .Net 5 " +
                "\r\n" +
                "", "关于 合工大自动打卡");
        }

        private void githubPageToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/DiamondMofeng/HFUT-AutoSignGUI");
        }

        private void 各邮箱smtp服务器地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://www.cnblogs.com/lxwphp/p/7731252.html");
        }

        private void button_t_openLog_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists("log.txt"))
            {
                MessageBox.Show("当前还没有生成任何日志","打开日志失败");
                return;
            }
            Process.Start("notepad.exe", Application.StartupPath + "log.txt");
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
