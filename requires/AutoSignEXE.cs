using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace AutoSignEXE
{
    class AutoSignEXE
    {
        static void Main(string[] args)
        {
            //for string[] args:
            //string 学号,string 密码,
            //string EmailEnabled
            //string smtp服务器,string sender,
            //string smtpAuth,string receiver
            //一共7个参数
            string acc = "未填写";
            string pass = "unknow";
            //
            string EmailEnabled = "0";
            //
            string smtpServer = "unknow";
            string sender = "unknow";
            string smtpAuth = "unknow";
            string receiver = "unknow";
            //默认：原地输出，显示driver.exe，不显示browser
            string debug_log = "0";//0则原地输出，1则输出至log.txt
            string debug_driver = "1";
            string debug_browser = "0";//0则不显示，1则显示


            if (checkAgruments() == false) return;


            //using (var writer = new StreamWriter(Console.OpenStandardOutput()))

            //将输出定向到log文件而不是窗口中
            

            if (debug_log == "1")
            {

                StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + "\\log.txt", true);
                writer.WriteLine("\r\n\r\n---------------学号:" + args[0] + "|运行时间：" + DateTime.Now.ToString() + "---------------");
                Console.SetOut(writer);
                sign(acc, pass);
                writer.Close();
            }
            


            if (debug_log == "0")
            {
                sign(acc, pass);

            }






            ///////////////////////////////////////////////def part/////////////////////////





            ////////////////////////////////////////////////////////////////////

            //return true if passed,false if failed
            bool checkAgruments()
            {
                try
                {
                    acc = args[0];
                    pass = args[1];
                    EmailEnabled = args[2];

                    if (EmailEnabled == "1")
                    {
                        smtpServer = args[3];
                        sender = args[4];
                        smtpAuth = args[5];
                        receiver = args[6];
                    }


                    try
                    {
                        debug_log = args[7];
                        debug_driver = args[8];
                        debug_browser = args[9];

                    }
                    catch
                    {

                    }

                    return true;
                }
                catch
                {
                    Console.WriteLine("输入参数不正确！" +
                        "应为七项：string:学号，密码，邮件模块开关(1),smtp服务器，邮件发送者，smtp授权码，邮件接收者"
                        + "\r\n或为三项: string:学号，密码，邮件模块开关(0)");
                    //Console.WriteLine("按任意键退出...");
                    //Console.ReadKey(true);
                    return false;
                }
                //if (args.Length >= 7)
                //{

                //    acc = args[0];
                //    pass = args[1];
                //    EmailEnabled = args[2];
                //    smtpServer = args[3];
                //    sender = args[4];
                //    smtpAuth = args[5];
                //    receiver = args[6];

                //    try
                //    {
                //        debug_cmd = args[7];
                //        debug_driver = args[8];
                //        debug_browser = args[9];
                //    }
                //    catch
                //    {

                //    }
                //    return true;

                //}
                //// else if (args.Length == 3 && args[2] == "0")
                //else if (args.Length >= 3 && args[2] == "0")
                //{
                //    acc = args[0];
                //    pass = args[1];
                //    EmailEnabled = args[2];
                //    return true;
                //}
                //else
                //{
                //    Console.WriteLine("输入参数不正确！" +
                //        "应为七项：string:学号，密码，邮件模块开关(1),smtp服务器，邮件发送者，smtp授权码，邮件接收者"
                //        + "\r\n或为三项: string:学号，密码，邮件模块开关(0)");
                //    //Console.WriteLine("按任意键退出...");
                //    //Console.ReadKey(true);
                //    return false;
                //}
            }

            bool IsElementExists_ByXpath(IWebDriver driver, string Xpath)
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

            void sign(string account, string password)
            {
                //隐藏driver.exe的控制行窗口
                var ser = EdgeDriverService.CreateChromiumService();
                if (debug_driver == "0")
                    ser.HideCommandPromptWindow = true;


                //主要是隐藏浏览器窗口
                EdgeOptions edgeOptions = new EdgeOptions();


                edgeOptions.UseChromium = true;

                if (debug_browser == "0")
                {


                    edgeOptions.AddArgument("--headless");

                    edgeOptions.AddArgument("disable-gpu");

                    edgeOptions.AddArgument("--allow-running-insecure-content");

                    edgeOptions.AddArgument("--ignore-certificate-errors");
                }
                edgeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
                using (IWebDriver driver = new EdgeDriver(ser, edgeOptions))
                {


                    //driver.Navigate().GoToUrl("https://cas.hfut.edu.cn/cas/login");
                    //driver.Navigate().GoToUrl("http://stu.hfut.edu.cn");
                    //这个看起来不错，但不知道能不能持久使用
                    //driver.Navigate().GoToUrl("https://cas.hfut.edu.cn/cas/login?service=http%3A%2F%2Fauth.hfut.edu.cn%2Famp-auth-adapter%2FloginSuccess%3FsessionToken%3D3dde5c3f8bf44ddda55dfaca5918b4fa");
                    driver.Navigate().GoToUrl("http://stu.hfut.edu.cn/xsfw/sys/xsyqxxsjapp/*default/index.do#/mrbpa");
                    Thread.Sleep(6000);
                    driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/button[1]")).Click();
                    driver.FindElement(By.Id("username")).SendKeys(account);
                    driver.FindElement(By.Id("pwd")).SendKeys(password);
                    driver.FindElement(By.Id("sb2")).Click();
                    if (IsElementExists_ByXpath(driver,
                       "/html/body/div[2]/div/div[2]/form/div[2]/div/span/div/span"))
                    {
                        driver.Close();
                        Console.WriteLine("自动打卡失败！原因：学号/密码错误");
                        email("自动打卡失败！", "原因：登陆失败！");
                        //Console.WriteLine("按任意键退出...");
                        //Console.ReadKey(true);
                        return;
                    }

                    if (DateTime.Now.ToLocalTime().Hour <= 13)
                    {
                        driver.Close();
                        Console.WriteLine("自动打卡失败！原因：登陆成功，但还未到打卡时间");
                        email("自动打卡失败！", "原因：登陆成功，但还未到打卡时间");
                        return;
                    }

                    Thread.Sleep(10000);
                    //如果没有找到保存按钮
                    if (!IsElementExists_ByXpath(driver, "//*[@id='save']"))
                    {
                        //如果找到编辑按钮
                        if (IsElementExists_ByXpath(driver, "/html/body/main/article/section/div/div[3]/div[2]/div/div[4]/div["
                                       + "2]/div/table/tbody/tr[1]/td[2]/a[1]"))
                        {
                            Console.WriteLine("自动打卡失败！原因：可能已打过卡");
                            email("自动打卡失败！原因：可能已打过卡", "可能今日已打过卡，若不放心请登录今日校园检查");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("自动打卡失败！原因：可能程序出错");
                            email("自动打卡失败！原因：可能程序出现故障", "可能程序出现故障，今日请手动打卡，闲时可向作者反馈问题");
                            return;
                        }
                    }
                    //否则执行打卡操作
                    else
                    {
                        driver.FindElement(By.XPath("//*[@id='save']")).Click();
                        Console.WriteLine("自动打卡成功！");
                        email("自动打卡成功！", "学号" + account + "于" + DateTime.Now.ToShortTimeString().ToString() + "进行了自动打卡");
                        return;
                    }
                }
            }





            void email(string subject, string content)
            {
                if (EmailEnabled == "0")
                {
                    Console.WriteLine("邮件模块已关闭，不发送邮件");
                    return;
                }

                try
                {

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
                    SmtpClient client = new SmtpClient(smtpServer, 25);
                    //设置发送人的邮箱账号和密码
                    client.Credentials = new NetworkCredential(sender, smtpAuth);
                    //启用ssl,也就是安全发送
                    //client.EnableSsl = true;
                    //发送邮件
                    client.Send(message);

                    Console.Write("邮件发送成功");//debug
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




        }
    }
}
