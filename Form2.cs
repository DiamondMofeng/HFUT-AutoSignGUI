using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace HFUT_AutoSignGUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void checkBox_b_showpass_CheckedChanged(object sender, EventArgs e)
        {
            textBox_b_pass.UseSystemPasswordChar = !checkBox_b_showpass.Checked;
        }
        private void checkBox_e_showpass_CheckedChanged(object sender, EventArgs e)
        {
            textBox_e_smtpAuth.UseSystemPasswordChar = !checkBox_e_showpass.Checked;
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

        private void button_signTest_Click(object sender, EventArgs e)
        {
            textBox_t_testResult.Text = "";
            ////检查基础信息是否有遗漏
            //foreach (Control t in this.Controls)
            //{
            //    if (t is not TextBox) continue;
            //    if ((string)t.Tag == "tb")
            //    {
            //        if (t.Text == "" || t.Text.Contains(" "))
            //            textBox_t_testResult.Text = "信息不能为空，且不能有空格";
            //        return;
            //    }
            //    if ((string)t.Tag == "te" && checkBox_e_enable.Checked==true )
            //    {
            //        if(t.Text == "" || t.Text.Contains(" ")){
            //            textBox_t_testResult.Text = "信息不能为空，且不能有空格";
            //            return;
            //        }
            //    }
            //}
            textBox_t_testResult.Text = scripts.signTest(textBox_b_acc.Text, textBox_b_pass.Text
                , EmailEnabled
                , textBox_e_smtp.Text, textBox_e_sender.Text
                , textBox_e_smtpAuth.Text, textBox_e_receiver.Text);
        }
        string EmailEnabled = "0";
        private void checkBox_e_enable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_e_enable.Enabled == true) EmailEnabled = "1";
            if (checkBox_e_enable.Enabled == false) EmailEnabled = "0";
        }

        private void button_s_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_s_save_Click(object sender, EventArgs e)
        {
            ////检查各输入参数的合理性

            //将错误逐渐累计，最后统一呈现
            string errorMsg = "";

            //检查基础信息是否有遗漏
            if (checkBox_e_enable.Checked == true)
            {
                if (textBox_b_acc.Text == ""
                    || textBox_b_pass.Text == ""
                    || textBox_e_receiver.Text == ""
                    || textBox_e_sender.Text == ""
                    || textBox_e_smtp.Text == ""
                    || textBox_e_smtpAuth.Text == ""
                    )
                {
                    errorMsg += "登录信息或邮件信息不完整:\r\n    请填写完整";
                }
            }
            else
            {
                if (textBox_b_acc.Text == ""
                   || textBox_b_pass.Text == "")
                {
                    errorMsg += "登录信息不完整:\r\n    请填写登录信息";
                }
            }

            //检查任务id是否合理：是否不为空且不与现有id重复
            //并将结果存入string taskID
            string taskID = textBox_t_taskID.Text;
            if (taskID == "")
            {
                errorMsg += "\r\n任务ID为空:\r\n    任务ID不应为空，且不能与现有项重复";
                //return;
            }
            else if (scripts.isTaskIDExists(taskID, "XMLTasks.xml"))
            {
                errorMsg += "\r\n任务ID与现有项重复:\r\n    任务ID不应为空，且不能与现有项重复";
            }
            else if (Regex.IsMatch(taskID, "[^A-Za-z0-9_]"))
            {
                errorMsg += "\r\n任务ID不符合规范:\r\n    任务ID只能包含数字、字母、下划线";

            }


            //检查mode设置合理性
            //并将结果存入string TimerEnabled,OnlogonEnabled
            //string mode用来显示Listview中信息
            string mode = "";
            string TimerEnabled = "false";
            string OnlogonEnabled = "false";

            if (checkBox_t_OnLogin.Checked == true && checkBox_t_Timer.Checked == true)
            {
                mode = "开机时&定时";
                TimerEnabled = "true";
                OnlogonEnabled = "true";
            }
            else
            {
                if (checkBox_t_OnLogin.Checked == true)
                {
                    mode = "开机时";
                    OnlogonEnabled = "true";
                }
                else if (checkBox_t_Timer.Checked == true)
                {
                    mode = "定时打卡";
                    TimerEnabled = "true";
                }
                else
                {
                    errorMsg += "\r\n未选择运行方式:\r\n    最少选择一项运行方式";
                    //return;
                }
            }
            //检查时间合理性，并将结果存入变量int hh_,mm_, string hh,mm
            string hh = textBox_t_hh.Text;
            string mm = textBox_t_mm.Text;
            if (checkBox_t_Timer.Checked == true &&
                (
                int.TryParse(textBox_t_hh.Text, out int hh_) == false
                || int.TryParse(textBox_t_mm.Text, out int mm_) == false
                || scripts.t_CheckTime(hh_, mm_) == false
                )
                )
            {
                errorMsg += "\r\n时间输入不合理，请重新填写:\r\n    时间应晚于14:00，建议最少晚于14:30防止意外";
                //return;
            }
            //showCheckResult();
            if (errorMsg != "")
            {
                MessageBox.Show(errorMsg, "保存失败");
                return;
            }

            else if (MessageBox.Show("所填信息无明显错误\r\n确定要保存吗？", "确认保存", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            ///////////////////////////////检查完毕！！///////////////////////////////

            //处理计划任务所需参数

            //运行参数-基础信息
            string arguments = textBox_b_acc.Text + " " + textBox_b_pass.Text + " ";
            if (checkBox_e_enable.Checked == true)
            {
                arguments += "1 " + textBox_e_smtp.Text + " " + textBox_e_sender.Text + " " + textBox_e_smtpAuth.Text + " " + textBox_e_receiver.Text;
            }
            else arguments += "0 0 0 0 0" + " ";
            //额外debug信息
            //在生成的xml中，默认：有log,无driver,无browser
            string debug_log = " 1 ";
            string debug_driver = " 0 ";
            string debug_browser = " 0 ";

            arguments += debug_log + debug_driver + debug_browser;

            //本来想用纯schtasks命令去设置，奈于指令可扩展性比较低，于是换用先生成xml再用schtasks加载的方式。

            //生成目标xml
            scripts.GenerateTaskXMLFromPattern("TaskPattern.xml", "TaskCache.xml", taskID, hh, mm, TimerEnabled, OnlogonEnabled
                , System.Windows.Forms.Application.StartupPath + "AutoSignEXE.exe"//要运行的程序
                , arguments //运行参数
                , System.Windows.Forms.Application.StartupPath);//运行目录



            ////打开cmd输入计划任务
            //用cmd,schtasks /create /TN "taskID" /XML "XML.xml"导入计划任务
            //schtasks /create /tn testtt /xml "TaskCache.xml"

            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";

            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            //p.StartInfo.Arguments = "";

            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;//set false for debug
            //启动程序
            p.Start();

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine("schtasks /create" +
                " /TN " + taskID +          //任务ID是强制选项
                " /XML " + "TaskCache.xml");
            p.StandardInput.Close();

            string strOutput = p.StandardOutput.ReadToEnd();

            p.WaitForExit();
            p.Close();




            ////检查计划任务是否设置成功

            if (strOutput.Contains("成功: 成功创建计划任务"))
            {

            }
            else
            {
                MessageBox.Show("输出结果：" + strOutput, "创建任务出错");
                return;
            }

            ////保存数据至xml文件
            XmlDocument xmlAddTask = new XmlDocument();
            xmlAddTask.Load("XMLTasks.xml");
            scripts.addTaskToXML(xmlAddTask, textBox_t_taskID.Text, textBox_b_acc.Text, mode, textBox_t_hh.Text, textBox_t_mm.Text);
            xmlAddTask.Save("XMLTasks.xml");

            //最后重新加载Form1的ListView
            //已在form1中实现

            //询问是否继续添加
            if (MessageBox.Show("添加成功！\r\n还要继续添加吗？", "继续添加", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                this.Close();
            }
        }

        

        private void checkBox_t_Timer_CheckedChanged(object sender, EventArgs e)
        {
            textBox_t_hh.Enabled = checkBox_t_Timer.Checked;
            textBox_t_mm.Enabled = checkBox_t_Timer.Checked;
            if (checkBox_t_Timer.Checked == false)
            {
                textBox_t_hh.Text = "";
                textBox_t_mm.Text = "";
            }
        }


        private void LoadSettings()
        {
            //
            textBox_b_acc.Text = AppSettings.Default.acc2;
            textBox_b_pass.Text = AppSettings.Default.pass2;
            //
            textBox_e_smtp.Text = AppSettings.Default.smtpServer2;
            textBox_e_smtpAuth.Text = AppSettings.Default.smtpAuth2;
            textBox_e_sender.Text = AppSettings.Default.sender2;
            textBox_e_receiver.Text = AppSettings.Default.receiver2;

        }
        private void textBox_b_acc_TextChanged(object sender, EventArgs e)
        {
            AppSettings.Default.acc2 = textBox_b_acc.Text;
            AppSettings.Default.Save();
        }

        private void textBox_b_pass_TextChanged(object sender, EventArgs e)
        {
            AppSettings.Default.pass2 = textBox_b_pass.Text;
            AppSettings.Default.Save();
        }

        private void textBox_e_smtp_TextChanged(object sender, EventArgs e)
        {
            AppSettings.Default.smtpServer2 = textBox_e_smtp.Text;
            AppSettings.Default.Save();
        }

        private void textBox_e_sender_TextChanged(object sender, EventArgs e)
        {
            AppSettings.Default.sender2 = textBox_e_sender.Text;
            AppSettings.Default.Save();
        }

        private void textBox_e_smtpAuth_TextChanged(object sender, EventArgs e)
        {
            AppSettings.Default.smtpAuth2 = textBox_e_smtpAuth.Text;
            AppSettings.Default.Save();
        }

        private void textBox_e_receiver_TextChanged(object sender, EventArgs e)
        {
            AppSettings.Default.receiver2 = textBox_e_receiver.Text;
            AppSettings.Default.Save();
        }
    }
}
