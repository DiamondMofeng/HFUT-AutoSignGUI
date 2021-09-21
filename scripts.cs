using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
//using OpenQA.Selenium.Edge;
//using Microsoft.Edge;

namespace HFUT_AutoSignGUI
{
    class scripts
    {
        /// <summary>
        /// 从配置文件中获取信息，仅需输入标题与内容
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="content"></param>
        static void email(string subject, string content)
        {
            try
            {
                var emailAcount = "123456@qq.com";
                var emailPassword = "smtp密码";
                var reciver = "receiver@qq.com";

                MailMessage message = new MailMessage();
                //设置发件人,发件人需要与设置的邮件发送服务器的邮箱一致
                MailAddress fromAddr = new MailAddress("123456789@qq.com");
                message.From = fromAddr;
                //设置收件人,可添加多个,添加方法与下面的一样
                message.To.Add(reciver);
                //设置抄送人
                message.CC.Add("123456778@qq.com");
                //设置邮件标题
                message.Subject = subject;
                //设置邮件内容
                message.Body = content;
                //设置邮件发送服务器,服务器根据你使用的邮箱而不同,可以到相应的 邮箱管理后台查看,下面是QQ的
                SmtpClient client = new SmtpClient("smtp.qq.com", 25);
                //设置发送人的邮箱账号和密码
                client.Credentials = new NetworkCredential(emailAcount, emailPassword);
                //启用ssl,也就是安全发送
                client.EnableSsl = true;
                //发送邮件
                client.Send(message);

                Console.Write("发送成功");
            }
            catch (System.FormatException)
            {
                Console.Write("邮件发送失败，错误原因：" + "邮箱格式不正确");
                return;
            }
            catch (System.Net.Mail.SmtpException)
            {
                Console.Write("邮件发送失败，错误原因：" + "smtp服务器连接错误，请检查相关信息");
                return;
            }
            catch (Exception ex)
            {
                Console.Write("邮件发送失败，错误原因：" + ex);
                return;
            }

            return;
        }
        /// <summary>
        /// 输入全部信息的email函数
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="content"></param>
        /// <param name="sender"></param>
        /// <param name="receiver"></param>
        /// <param name="stmpServer"></param>
        /// <param name="stmpAuth"></param>
        static void email(string subject, string content,
            string sender, string receiver,
            string stmpServer, string stmpAuth)
        {
            //try
            //{

            MailMessage message = new MailMessage();
            //设置发件人,发件人需要与设置的邮件发送服务器的邮箱一致
            MailAddress fromAddr = new MailAddress(sender);
            message.From = fromAddr;
            //设置收件人,可添加多个,添加方法与下面的一样
            message.To.Add(receiver);
            //设置抄送人
            message.CC.Add(sender);
            //设置邮件标题
            message.Subject = subject;
            //设置邮件内容
            message.Body = content;
            //设置邮件发送服务器,服务器根据你使用的邮箱而不同,可以到相应的 邮箱管理后台查看,下面是QQ的
            SmtpClient client = new SmtpClient(stmpServer, 25);
            //设置发送人的邮箱账号和密码
            client.Credentials = new NetworkCredential(sender, stmpAuth);
            //启用ssl,也就是安全发送
            //client.EnableSsl = true;
            //发送邮件
            client.Send(message);

            Console.Write("发送成功");
            //}
            //catch (Exception ex)
            //{
            //    Console.Write("发送失败，错误原因：" + ex);
            //}
            return;
        }
        /// <summary>
        /// 输入四项信息以进行测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="receiver"></param>
        /// <param name="stmpServer"></param>
        /// <param name="stmpAuth"></param>
        /// <returns></returns>
        public static bool TestEmail(string sender, string receiver,
            string stmpServer, string stmpAuth)
        {
            try
            {
                email("测试", "若收到此邮件代表测试成功", sender, receiver, stmpServer, stmpAuth);
                return true;
            }
            catch
            {
                return false;
            }

        }
        private static bool IsElementExists_ByXpath(IWebDriver driver, string Xpath)
        {
            try
            {
                driver.FindElement(By.XPath(Xpath));
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static bool TestLogin(string account, string password)
        {

            //我想通过https://cas.hfut.edu.cn/cas/login进行测试而不是stu.hfut.edu.cn，
            //但前者登陆后若无跳转则会堵塞。暂时找不到解决方法，可能是edge有毛病
            EdgeOptions edgeOptions = new EdgeOptions();


            edgeOptions.UseChromium = true;
            edgeOptions.AddArgument("--headless");

            edgeOptions.AddArgument("disable-gpu");

            edgeOptions.AddArgument("--allow-running-insecure-content");

            edgeOptions.AddArgument("--ignore-certificate-errors");
            edgeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
            //using (IWebDriver driver = new EdgeDriver(System.Windows.Forms.Application.StartupPath + "MicrosoftWebDriver.exe",edgeOptions))
            using (IWebDriver driver = new EdgeDriver(edgeOptions))
            {

                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //driver.Navigate().GoToUrl("https://cas.hfut.edu.cn/cas/login");
                //driver.Navigate().GoToUrl("http://stu.hfut.edu.cn");
                //这个看起来不错，但不知道能不能持久使用
                driver.Navigate().GoToUrl("https://cas.hfut.edu.cn/cas/login?service=http%3A%2F%2Fauth.hfut.edu.cn%2Famp-auth-adapter%2FloginSuccess%3FsessionToken%3D3dde5c3f8bf44ddda55dfaca5918b4fa");
                //Thread.Sleep(5000);//我不想用这个
                //driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/button[1]")).Click();
                driver.FindElement(By.Id("username")).SendKeys(account);
                driver.FindElement(By.Id("pwd")).SendKeys(password);
                driver.FindElement(By.Id("sb2")).Click();
                return !IsElementExists_ByXpath(driver,
                   "/html/body/div[2]/div/div[2]/form/div[2]/div/span/div/span");
                //if (IsElementExists_ByXpath(driver,
                //    "/html/body/div[2]/div/div[2]/form/div[2]/div/span/div/span") == true)
                //{
                //    return false;
                //}
                //else
                //{
                //    return false;
                //}


                //IWebElement 

            }
        }
        public static string signTest(string acc, string pass, string Eenable, string smtp, string sender, string smtpAuth, string receiver, int filter = 1)
        {


            //启动cmd

            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "AutoSignEXE.exe";

            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.Arguments = acc + " " + pass + " " + Eenable + " " + smtp + " " + sender + " " + smtpAuth + " " + receiver;

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
            //p.StandardInput.WriteLine("schtasks /query" + "&exit");

            p.StandardInput.AutoFlush = true;





            p.WaitForExit();
            string Output = p.StandardOutput.ReadToEnd();
            p.Close();

            if (filter == 1)
            {



                //等待程序执行完退出进程



                //使用正则表达式，若首字符(汉字)则输出


                string strOutput = "";
                string[] ii = Output.Split("\r\n");
                foreach (string i in ii)
                {
                    if (i.Length >= 2)
                    {
                        if (Regex.IsMatch(i.Substring(0, 1), "[^A-Za-z0-9_]"))
                        {
                            strOutput = strOutput + i + "\r\n";
                        }
                    }

                }
                return strOutput;
            }
            else return Output;

            //Console.WriteLine(strOuput);

            //Console.ReadKey();
        }


        /// <summary>
        /// 为XML文件按传入参数添加TaskList下的Task节点
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="TaskID"></param>
        /// <param name="account"></param>
        /// <param name="mode"></param>
        /// <param name="hh"></param>
        /// <param name="mm"></param>
        public static void addTaskToXML(XmlDocument xml, string TaskID, string account, string mode, string hh, string mm)
        {
            //为TaskList添加元素Task
            XmlNode TaskList = xml.SelectSingleNode("TaskList");//查找<TaskList>节点
            XmlElement Task = xml.CreateElement("Task");//创建一个<Task>元素节点
            Task.SetAttribute("id", TaskID);//设置该节点id属性
            TaskList.AppendChild(Task);//添加<Task>到<TaskList>节点中
            //为Task添加内容
            XmlElement acc = xml.CreateElement("account");//添加<account>元素节点
            acc.InnerText = account;//设置<account>元素节点的文本节点内容
            Task.AppendChild(acc);//添加<account>到<Task>节点中

            XmlElement solution = xml.CreateElement("solution");
            solution.InnerText = mode;
            Task.AppendChild(solution);

            XmlElement time = xml.CreateElement("time");
            time.InnerText = hh + ":" + mm;
            Task.AppendChild(time);
        }
        /// <summary>
        /// 这个重载仅用于测试，会为XML文件添加无意义参数
        /// </summary>
        /// <param name="xml"></param>
        public static void addTaskToXML(XmlDocument xml)
        {
            //为TaskList添加元素Task
            XmlNode TaskList = xml.SelectSingleNode("TaskList");//查找<TaskList>节点
            XmlElement Task = xml.CreateElement("Task");//创建一个<Task>元素节点
            Task.SetAttribute("id", "Test");//设置该节点id属性
            TaskList.AppendChild(Task);//添加<Task>到<TaskList>节点中
            //为Task添加内容
            XmlElement acc = xml.CreateElement("account");//添加<account>元素节点
            acc.InnerText = "2019123456";//设置<account>元素节点的文本节点内容
            Task.AppendChild(acc);//添加<account>到<Task>节点中

            XmlElement solution = xml.CreateElement("solution");
            solution.InnerText = "mode";
            Task.AppendChild(solution);

            XmlElement time = xml.CreateElement("time");
            time.InnerText = "hh:mm";
            Task.AppendChild(time);
        }
        public static void LoadTasks(string xmlPath, System.Windows.Forms.ListView listView)
        {
            //先清空listview
            foreach (System.Windows.Forms.ListViewItem item in listView.Items)
            {
                listView.Items.Remove(item);
            }


            //打开XMLTasks.xml
            XmlReaderSettings set = new XmlReaderSettings();
            set.DtdProcessing = DtdProcessing.Parse;
            using (XmlReader reader = XmlReader.Create(xmlPath, set))
            {
                //Console.WriteLine("test");//debug
                while (reader.ReadToFollowing("Task"))
                {
                    XmlReader taskReader = reader.ReadSubtree();
                    string id = "";
                    string acc = "";
                    string mode = "";
                    string time = "";
                    if (taskReader.HasAttributes == true)
                    {
                        //taskReader.MoveToAttribute(0);//这个函数有毛病
                        taskReader.MoveToContent();
                        id = taskReader.GetAttribute("id");


                    }
                    while (taskReader.Read())
                    {

                        //try
                        //{
                        if (taskReader.NodeType == XmlNodeType.Whitespace) continue;

                        //if (taskReader.NodeType == XmlNodeType.Attribute)
                        //{
                        //    if (taskReader.Name == "id")
                        //    {
                        //        id = taskReader.Value;
                        //    }
                        //}

                        if (taskReader.NodeType == XmlNodeType.Element)
                        {
                            switch (taskReader.Name)
                            {
                                //case "id":
                                //    id = reader.ReadElementContentAsString();
                                //    continue;
                                case "account":
                                    acc = reader.ReadElementContentAsString();
                                    continue;
                                case "solution":
                                    mode = reader.ReadElementContentAsString();
                                    continue;
                                case "time":
                                    time = reader.ReadElementContentAsString();
                                    continue;
                            }
                            //void getValue(XmlReader reader, string targetValue, out string StringToSave)
                            //{
                            //if (reader.Name == targetValue)
                            //{
                            //    StringToSave = reader.ReadElementContentAsString();
                            //}
                            //else StringToSave = "";
                            //}
                            //getValue(taskReader, "id", out id);
                            //getValue(taskReader, "account", out acc);
                            //getValue(taskReader, "solution", out mode);
                            //getValue(taskReader, "time", out time);

                        }
                        //}
                        //catch
                        //{
                        //    continue;
                        //}

                    }
                    System.Windows.Forms.ListViewItem listViewItem_Task = new System.Windows.Forms.ListViewItem(new string[] {
                            id,
                            acc,
                            mode,
                            time}, -1);

                    listView.Items.Add(listViewItem_Task);
                }
            }
        }



        public static void DeleteTaskInSchTasks(string taskID)
        {
            //启动cmd

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
            p.StandardInput.WriteLine("schtasks /delete /f /tn " + taskID);
            //p.StandardInput.AutoFlush = true;
            p.StandardInput.Close();

            p.WaitForExit();
            p.Close();


            //debug
            //string strOuput = p.StandardOutput.ReadToEnd();

            //p.Close();

            //Console.WriteLine(strOuput);

            //Console.ReadKey();
        }

        public static void DeleteTaskInXML(string XMLPath, string taskID)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(XMLPath);

            XmlElement taskToRemove = xml.GetElementById(taskID);

            xml.DocumentElement.RemoveChild(taskToRemove);

            xml.Save(XMLPath);

        }
        /// <summary>
        /// 检查所输入时间的合理性
        /// </summary>
        /// <param name="hh">小时</param>
        /// <param name="mm">分钟</param>
        /// <returns>true如果未发现错误，false如果时间不合理</returns>
        public static bool t_CheckTime(int hh, int mm)
        {
            if (hh < 14 || hh >= 24) return false;
            if (mm < 0 || mm >= 60) return false;
            else return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskID"></param>
        /// <returns>true if exists,false if not exists</returns>
        public static bool isTaskIDExists(string taskID, string XMLPath)
        {
            //试试Linq
            XDocument xdoc = XDocument.Load(XMLPath);
            var queryIDs =
                from att_id in xdoc.Element("TaskList").Elements("Task").Attributes("id")
                where att_id.Value == taskID
                select att_id.Value;
            if (queryIDs.Take(1).Count() >= 1)
            {
                return true;
            }
            else return false;
        }
        public static void CheckXMLExists()
        {
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







        }
        /// <summary>
        /// 按照模板生成计划任务所用XML
        /// </summary>
        /// <param name="PathXMLpattern"></param>
        /// <param name="PathXMLExport"></param>
        /// <param name="taskID"></param>
        /// <param name="hh"></param>
        /// <param name="mm"></param>
        /// <param name="TimerEnabled"></param>
        /// <param name="LogonEnabled"></param>
        /// <param name="ExecPath"></param>
        /// <param name="Arguments"></param>
        /// <param name="DirectoryPath"></param>
        public static void GenerateTaskXMLFromPattern(string PathXMLpattern, string PathXMLExport
       , string taskID
       , string hh , string mm
       , string TimerEnabled
       , string LogonEnabled
       , string ExecPath
       , string Arguments
       , string DirectoryPath)
        {


            XmlDocument doc = new XmlDocument();
            doc.Load(PathXMLpattern);

            // 加载命名空间，因为模板文档里面带了命名空间
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("p", "http://schemas.microsoft.com/windows/2004/02/mit/task");



            XmlNode node;
            XmlNode root = doc.DocumentElement;

            //taskID
            node = root.SelectSingleNode("/p:Task/p:RegistrationInfo/p:URI", nsmgr);
            node.InnerText = "\\HFUT\\" + taskID;
            //运行时间
            if (TimerEnabled == "true")
            { 
            node = root.SelectSingleNode("/p:Task/p:Triggers/p:CalendarTrigger/p:StartBoundary", nsmgr);
            node.InnerText = "2021-01-01T" + hh + ":" + mm + ":00";
            }
            //是否定时运行
            node = root.SelectSingleNode("/p:Task/p:Triggers/p:CalendarTrigger/p:Enabled", nsmgr);
            node.InnerText = TimerEnabled;
            //是否登陆时运行
            node = root.SelectSingleNode("/p:Task/p:Triggers/p:LogonTrigger/p:Enabled", nsmgr);
            node.InnerText = LogonEnabled;
            //要运行的软件的路径
            node = root.SelectSingleNode("/p:Task/p:Actions/p:Exec/p:Command", nsmgr);
            node.InnerText = ExecPath;
            //启动项参数
            node = root.SelectSingleNode("/p:Task/p:Actions/p:Exec/p:Arguments", nsmgr);
            node.InnerText = Arguments;
            //工作目录
            node = root.SelectSingleNode("/p:Task/p:Actions/p:Exec/p:WorkingDirectory", nsmgr);
            node.InnerText = DirectoryPath;


            //写入用户id，以通过安全性检查；无需外部参数
            node = root.SelectSingleNode("/p:Task/p:Principals/p:Principal/p:UserId", nsmgr);
            node.InnerText = Environment.UserName;




            doc.Save(PathXMLExport);
            //doc.Save(Console.Out);
            //Console.ReadKey(true);
        }
        /// <summary>
        /// return false if 没有接受免责声明
        /// </summary>
        public static bool Disclaimer()
        {
            if (AppSettings.Default.Disclaimer == false)
            {
                if (System.Windows.Forms.MessageBox.Show("若您使用本软件，则首先需要熟知并同意以下内容：" +
                    "\r\n①本软件仅供同学在确认所提交的疫情相关报备信息准确无误的情况下使用，软件所使用打卡信息为前一天成功提交的内容，若其中涉及的任何内容发生改变，须根据真实情况自行修改疫情信息报备内容。 因使用本脚本可能带来的任何风险问题均由使用者本人承担。" +
                    "\r\n②作者保证使用此软件所产生的敏感信息均仅存放于使用者的计算机中，且不会用于以目的为疫情信息填报以外的任何功能。" +
                    "\r\n③本软件遵循 "+Form1.License+" 开源协议"
                    , "免责声明", System.Windows.Forms.MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                {
                    return false;
                }
                else
                {
                    AppSettings.Default.Disclaimer = true;
                    AppSettings.Default.Save();
                    return true;
                }
            }
            else return true;
        }
        /// <summary>
        /// 将输入字符串中的非字母、数字开头行剔除
        /// </summary>
        /// <param name="strToBeFlitred"></param>
        /// <returns>过滤后的字符串</returns>
        public static string Fliter(string strToBeFlitred)
        {
            string strOutput = "";
            string[] ii = strToBeFlitred.Split("\r\n");
            foreach (string i in ii)
            {
                if (i.Length >= 2)
                {
                    if (Regex.IsMatch(i.Substring(0, 1), "[^A-Za-z0-9_(]"))
                    {
                        strOutput = strOutput + i + "\r\n";
                    }
                }

            }
            return strOutput;
        }
        public static bool IsXMLExists(string XMLPath)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
            doc.Load(XMLPath);
                return true;
            }
            catch (System.IO.FileNotFoundException)
            {
                return false;
            }
        }
    }
}
