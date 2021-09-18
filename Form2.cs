using System;
using System.Drawing;
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
            //void showCheckResult()
            //{
            //    if (errorMsg != "")
            //        MessageBox.Show(errorMsg, "保存失败");
            //    else if (MessageBox.Show("所填信息无明显错误\r\n确定要保存吗？", "确认保存", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //        return;
            //}
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
            if (textBox_t_taskID.Text == "")
            {
                errorMsg += "\r\n任务ID为空:\r\n    任务ID不应为空，且不能与现有项重复";
                //return;
            }
            else if (scripts.isTaskIDExists(textBox_t_taskID.Text, "XMLTasks.xml"))
            {
                errorMsg += "\r\n任务ID与现有项重复:\r\n    任务ID不应为空，且不能与现有项重复";
            }
            //检查mode设置合理性，并将结果存入string mode
            string mode = "";
            if (checkBox_t_OnLogin.Checked == true && checkBox_t_Timer.Checked == true)
            {

            }
            else
            {
                if (checkBox_t_OnLogin.Checked == true)
                {

                }
                else if (checkBox_t_Timer.Checked == true)
                {

                }
                else
                {
                    errorMsg += "\r\n未选择运行方式:\r\n    最少选择一项运行方式";
                    //return;
                }
            }
            //检查时间合理性，并将结果存入变量int hh,mm, string hh_str,mm_str
            if (int.TryParse(textBox_t_hh.Text, out int hh) == false
                || int.TryParse(textBox_t_mm.Text, out int mm) == false
                || scripts.t_CheckTime(hh, mm) == false)
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







            ////打开cmd输入计划任务


            ////检查计划任务是否设置成功


            ////保存数据至xml文件

            //参考资料：https://www.cnblogs.com/guxia/p/8242483.html
            XmlDocument xml = new XmlDocument();

            //尝试读取现有文件，若读取失败则生成新xml文件
            try
            {
                xml.Load("XMLTasks.xml");
            }
            catch (System.IO.FileNotFoundException)
            {
                //添加XML标记(声明)
                XmlDeclaration xmldecl;
                xmldecl = xml.CreateXmlDeclaration("1.0", "utf-8", null);
                xml.AppendChild(xmldecl);
                //添加根元素TaskList
                XmlElement AddTaskList = xml.CreateElement("", "TaskList", "");
                xml.AppendChild(AddTaskList);

                //scripts.addTaskToXML(xml);//for test

                xml.Save("XMLTasks.xml");//保存这个xml文件

            }
            scripts.addTaskToXML(xml, textBox_t_taskID.Text, textBox_b_acc.Text, mode, textBox_t_hh.Text, textBox_t_mm.Text);
            xml.Save("XMLTasks.xml");

            //最后重新加载Form1的ListView
            //已在form1中实现

            //询问是否继续添加
            if (MessageBox.Show("添加成功！\r\n还要继续添加吗？", "继续添加", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
