
namespace HFUT_AutoSignGUI
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkBox_t_OnLogin = new System.Windows.Forms.CheckBox();
            this.checkBox_e_enable = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_e_receiver = new System.Windows.Forms.TextBox();
            this.textBox_e_smtpAuth = new System.Windows.Forms.TextBox();
            this.textBox_e_smtp = new System.Windows.Forms.TextBox();
            this.textBox_b_pass = new System.Windows.Forms.TextBox();
            this.textBox_b_acc = new System.Windows.Forms.TextBox();
            this.label_b_testResult = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button_b_test = new System.Windows.Forms.Button();
            this.button_e_test = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label_e_testResult = new System.Windows.Forms.Label();
            this.button_signTest = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBox_e_showpass = new System.Windows.Forms.CheckBox();
            this.checkBox_t_Timer = new System.Windows.Forms.CheckBox();
            this.button_s_save = new System.Windows.Forms.Button();
            this.button_s_cancel = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_t_hh = new System.Windows.Forms.TextBox();
            this.textBox_t_mm = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_t_testResult = new System.Windows.Forms.TextBox();
            this.checkBox_b_showpass = new System.Windows.Forms.CheckBox();
            this.textBox_t_taskID = new System.Windows.Forms.TextBox();
            this.label_t_taskID = new System.Windows.Forms.Label();
            this.textBox_e_sender = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // checkBox_t_OnLogin
            // 
            this.checkBox_t_OnLogin.AutoSize = true;
            this.checkBox_t_OnLogin.Cursor = System.Windows.Forms.Cursors.Help;
            this.checkBox_t_OnLogin.Location = new System.Drawing.Point(592, 58);
            this.checkBox_t_OnLogin.Name = "checkBox_t_OnLogin";
            this.checkBox_t_OnLogin.Size = new System.Drawing.Size(136, 24);
            this.checkBox_t_OnLogin.TabIndex = 9;
            this.checkBox_t_OnLogin.Text = "启动电脑时执行";
            this.toolTip1.SetToolTip(this.checkBox_t_OnLogin, "实际上为登录电脑用户时执行");
            this.checkBox_t_OnLogin.UseVisualStyleBackColor = true;
            // 
            // checkBox_e_enable
            // 
            this.checkBox_e_enable.AutoSize = true;
            this.checkBox_e_enable.Cursor = System.Windows.Forms.Cursors.Help;
            this.checkBox_e_enable.Location = new System.Drawing.Point(88, 207);
            this.checkBox_e_enable.Name = "checkBox_e_enable";
            this.checkBox_e_enable.Size = new System.Drawing.Size(121, 24);
            this.checkBox_e_enable.TabIndex = 2;
            this.checkBox_e_enable.Text = "启用邮件模块";
            this.toolTip1.SetToolTip(this.checkBox_e_enable, "打卡程序运行结束后，将结果发送至指定邮箱(可以自己发给自己)");
            this.checkBox_e_enable.UseVisualStyleBackColor = true;
            this.checkBox_e_enable.CheckedChanged += new System.EventHandler(this.checkBox_e_enable_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "收件人邮箱";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "发件人邮箱";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "密码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "smtp授权码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "smtp服务器";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(98, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "基本信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "学号";
            // 
            // textBox_e_receiver
            // 
            this.textBox_e_receiver.Location = new System.Drawing.Point(128, 363);
            this.textBox_e_receiver.Name = "textBox_e_receiver";
            this.textBox_e_receiver.Size = new System.Drawing.Size(168, 27);
            this.textBox_e_receiver.TabIndex = 6;
            this.textBox_e_receiver.Tag = "te";
            this.textBox_e_receiver.Text = "123456789@qq.com";
            this.textBox_e_receiver.TextChanged += new System.EventHandler(this.textBox_e_receiver_TextChanged);
            // 
            // textBox_e_smtpAuth
            // 
            this.textBox_e_smtpAuth.Location = new System.Drawing.Point(128, 323);
            this.textBox_e_smtpAuth.Name = "textBox_e_smtpAuth";
            this.textBox_e_smtpAuth.Size = new System.Drawing.Size(168, 27);
            this.textBox_e_smtpAuth.TabIndex = 5;
            this.textBox_e_smtpAuth.Tag = "te";
            this.textBox_e_smtpAuth.Text = "abcdefghijklmnop";
            this.textBox_e_smtpAuth.UseSystemPasswordChar = true;
            this.textBox_e_smtpAuth.TextChanged += new System.EventHandler(this.textBox_e_smtpAuth_TextChanged);
            // 
            // textBox_e_smtp
            // 
            this.textBox_e_smtp.Location = new System.Drawing.Point(128, 243);
            this.textBox_e_smtp.Name = "textBox_e_smtp";
            this.textBox_e_smtp.Size = new System.Drawing.Size(168, 27);
            this.textBox_e_smtp.TabIndex = 3;
            this.textBox_e_smtp.Tag = "te";
            this.textBox_e_smtp.Text = "smtp.qq.com";
            this.textBox_e_smtp.TextChanged += new System.EventHandler(this.textBox_e_smtp_TextChanged);
            // 
            // textBox_b_pass
            // 
            this.textBox_b_pass.Location = new System.Drawing.Point(88, 96);
            this.textBox_b_pass.Name = "textBox_b_pass";
            this.textBox_b_pass.Size = new System.Drawing.Size(125, 27);
            this.textBox_b_pass.TabIndex = 1;
            this.textBox_b_pass.Tag = "tb";
            this.textBox_b_pass.Text = "123";
            this.textBox_b_pass.UseSystemPasswordChar = true;
            this.textBox_b_pass.TextChanged += new System.EventHandler(this.textBox_b_pass_TextChanged);
            // 
            // textBox_b_acc
            // 
            this.textBox_b_acc.Location = new System.Drawing.Point(88, 56);
            this.textBox_b_acc.Name = "textBox_b_acc";
            this.textBox_b_acc.Size = new System.Drawing.Size(125, 27);
            this.textBox_b_acc.TabIndex = 0;
            this.textBox_b_acc.Tag = "tb";
            this.textBox_b_acc.Text = "2019123456";
            this.textBox_b_acc.TextChanged += new System.EventHandler(this.textBox_b_acc_TextChanged);
            // 
            // label_b_testResult
            // 
            this.label_b_testResult.AutoSize = true;
            this.label_b_testResult.Location = new System.Drawing.Point(231, 160);
            this.label_b_testResult.Name = "label_b_testResult";
            this.label_b_testResult.Size = new System.Drawing.Size(39, 20);
            this.label_b_testResult.TabIndex = 26;
            this.label_b_testResult.Text = "暂无";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(182, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "测试结果:";
            // 
            // button_b_test
            // 
            this.button_b_test.Location = new System.Drawing.Point(43, 144);
            this.button_b_test.Name = "button_b_test";
            this.button_b_test.Size = new System.Drawing.Size(113, 29);
            this.button_b_test.TabIndex = 2;
            this.button_b_test.Text = "登录测试";
            this.button_b_test.UseVisualStyleBackColor = true;
            this.button_b_test.Click += new System.EventHandler(this.button_b_test_Click);
            // 
            // button_e_test
            // 
            this.button_e_test.Location = new System.Drawing.Point(44, 409);
            this.button_e_test.Name = "button_e_test";
            this.button_e_test.Size = new System.Drawing.Size(113, 29);
            this.button_e_test.TabIndex = 7;
            this.button_e_test.Text = "邮件测试";
            this.button_e_test.UseVisualStyleBackColor = true;
            this.button_e_test.Click += new System.EventHandler(this.button_e_test_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(183, 403);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "测试结果:";
            // 
            // label_e_testResult
            // 
            this.label_e_testResult.AutoSize = true;
            this.label_e_testResult.Location = new System.Drawing.Point(232, 425);
            this.label_e_testResult.Name = "label_e_testResult";
            this.label_e_testResult.Size = new System.Drawing.Size(39, 20);
            this.label_e_testResult.TabIndex = 26;
            this.label_e_testResult.Text = "暂无";
            // 
            // button_signTest
            // 
            this.button_signTest.Cursor = System.Windows.Forms.Cursors.Help;
            this.button_signTest.Location = new System.Drawing.Point(515, 190);
            this.button_signTest.Name = "button_signTest";
            this.button_signTest.Size = new System.Drawing.Size(113, 29);
            this.button_signTest.TabIndex = 13;
            this.button_signTest.Text = "打卡测试";
            this.toolTip1.SetToolTip(this.button_signTest, "(仅本窗口用到左侧所填信息)进行测试，并将结果输出至下方文本框");
            this.button_signTest.UseVisualStyleBackColor = true;
            this.button_signTest.Click += new System.EventHandler(this.button_signTest_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(615, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 20);
            this.label12.TabIndex = 20;
            this.label12.Text = "任务执行方式";
            // 
            // checkBox_e_showpass
            // 
            this.checkBox_e_showpass.AutoSize = true;
            this.checkBox_e_showpass.Location = new System.Drawing.Point(302, 326);
            this.checkBox_e_showpass.Name = "checkBox_e_showpass";
            this.checkBox_e_showpass.Size = new System.Drawing.Size(76, 24);
            this.checkBox_e_showpass.TabIndex = 23;
            this.checkBox_e_showpass.Text = "可见性";
            this.checkBox_e_showpass.UseVisualStyleBackColor = true;
            this.checkBox_e_showpass.CheckedChanged += new System.EventHandler(this.checkBox_e_showpass_CheckedChanged);
            // 
            // checkBox_t_Timer
            // 
            this.checkBox_t_Timer.AutoSize = true;
            this.checkBox_t_Timer.Location = new System.Drawing.Point(592, 95);
            this.checkBox_t_Timer.Name = "checkBox_t_Timer";
            this.checkBox_t_Timer.Size = new System.Drawing.Size(91, 24);
            this.checkBox_t_Timer.TabIndex = 10;
            this.checkBox_t_Timer.Text = "定时执行";
            this.checkBox_t_Timer.UseVisualStyleBackColor = true;
            this.checkBox_t_Timer.CheckedChanged += new System.EventHandler(this.checkBox_t_Timer_CheckedChanged);
            // 
            // button_s_save
            // 
            this.button_s_save.Location = new System.Drawing.Point(418, 409);
            this.button_s_save.Name = "button_s_save";
            this.button_s_save.Size = new System.Drawing.Size(150, 29);
            this.button_s_save.TabIndex = 15;
            this.button_s_save.Text = "保存任务";
            this.button_s_save.UseVisualStyleBackColor = true;
            this.button_s_save.Click += new System.EventHandler(this.button_s_save_Click);
            // 
            // button_s_cancel
            // 
            this.button_s_cancel.Location = new System.Drawing.Point(585, 409);
            this.button_s_cancel.Name = "button_s_cancel";
            this.button_s_cancel.Size = new System.Drawing.Size(150, 29);
            this.button_s_cancel.TabIndex = 16;
            this.button_s_cancel.Text = "取消";
            this.button_s_cancel.UseVisualStyleBackColor = true;
            this.button_s_cancel.Click += new System.EventHandler(this.button_s_cancel_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(691, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 20);
            this.label13.TabIndex = 30;
            this.label13.Text = "时";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(763, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 20);
            this.label14.TabIndex = 31;
            this.label14.Text = "分";
            // 
            // textBox_t_hh
            // 
            this.textBox_t_hh.Enabled = false;
            this.textBox_t_hh.Location = new System.Drawing.Point(649, 135);
            this.textBox_t_hh.Name = "textBox_t_hh";
            this.textBox_t_hh.Size = new System.Drawing.Size(36, 27);
            this.textBox_t_hh.TabIndex = 11;
            // 
            // textBox_t_mm
            // 
            this.textBox_t_mm.Enabled = false;
            this.textBox_t_mm.Location = new System.Drawing.Point(721, 135);
            this.textBox_t_mm.Name = "textBox_t_mm";
            this.textBox_t_mm.Size = new System.Drawing.Size(36, 27);
            this.textBox_t_mm.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(585, 138);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 20);
            this.label15.TabIndex = 30;
            this.label15.Text = " 每天的";
            // 
            // textBox_t_testResult
            // 
            this.textBox_t_testResult.Location = new System.Drawing.Point(405, 246);
            this.textBox_t_testResult.Multiline = true;
            this.textBox_t_testResult.Name = "textBox_t_testResult";
            this.textBox_t_testResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_t_testResult.Size = new System.Drawing.Size(330, 119);
            this.textBox_t_testResult.TabIndex = 14;
            this.textBox_t_testResult.Text = "测试结果";
            // 
            // checkBox_b_showpass
            // 
            this.checkBox_b_showpass.AutoSize = true;
            this.checkBox_b_showpass.Location = new System.Drawing.Point(219, 98);
            this.checkBox_b_showpass.Name = "checkBox_b_showpass";
            this.checkBox_b_showpass.Size = new System.Drawing.Size(76, 24);
            this.checkBox_b_showpass.TabIndex = 33;
            this.checkBox_b_showpass.Text = "可见性";
            this.checkBox_b_showpass.UseVisualStyleBackColor = true;
            this.checkBox_b_showpass.CheckedChanged += new System.EventHandler(this.checkBox_b_showpass_CheckedChanged);
            // 
            // textBox_t_taskID
            // 
            this.textBox_t_taskID.Location = new System.Drawing.Point(428, 56);
            this.textBox_t_taskID.Name = "textBox_t_taskID";
            this.textBox_t_taskID.Size = new System.Drawing.Size(125, 27);
            this.textBox_t_taskID.TabIndex = 8;
            // 
            // label_t_taskID
            // 
            this.label_t_taskID.AutoSize = true;
            this.label_t_taskID.Cursor = System.Windows.Forms.Cursors.Help;
            this.label_t_taskID.Location = new System.Drawing.Point(464, 24);
            this.label_t_taskID.Name = "label_t_taskID";
            this.label_t_taskID.Size = new System.Drawing.Size(54, 20);
            this.label_t_taskID.TabIndex = 20;
            this.label_t_taskID.Text = "任务ID";
            this.toolTip1.SetToolTip(this.label_t_taskID, "每个任务都应有一个独立的标识符");
            // 
            // textBox_e_sender
            // 
            this.textBox_e_sender.Location = new System.Drawing.Point(128, 283);
            this.textBox_e_sender.Name = "textBox_e_sender";
            this.textBox_e_sender.Size = new System.Drawing.Size(168, 27);
            this.textBox_e_sender.TabIndex = 4;
            this.textBox_e_sender.Tag = "te";
            this.textBox_e_sender.Text = "123456789@qq.com";
            this.textBox_e_sender.TextChanged += new System.EventHandler(this.textBox_e_sender_TextChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.ReshowDelay = 100;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 501);
            this.Controls.Add(this.checkBox_b_showpass);
            this.Controls.Add(this.textBox_t_testResult);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox_t_hh);
            this.Controls.Add(this.textBox_t_mm);
            this.Controls.Add(this.label_e_testResult);
            this.Controls.Add(this.label_b_testResult);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_e_test);
            this.Controls.Add(this.button_s_cancel);
            this.Controls.Add(this.button_s_save);
            this.Controls.Add(this.button_signTest);
            this.Controls.Add(this.button_b_test);
            this.Controls.Add(this.checkBox_e_showpass);
            this.Controls.Add(this.checkBox_t_Timer);
            this.Controls.Add(this.checkBox_t_OnLogin);
            this.Controls.Add(this.checkBox_e_enable);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label_t_taskID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_e_receiver);
            this.Controls.Add(this.textBox_e_smtpAuth);
            this.Controls.Add(this.textBox_e_sender);
            this.Controls.Add(this.textBox_e_smtp);
            this.Controls.Add(this.textBox_t_taskID);
            this.Controls.Add(this.textBox_b_pass);
            this.Controls.Add(this.textBox_b_acc);
            this.Name = "Form2";
            this.Text = "添加定时任务";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_t_OnLogin;
        private System.Windows.Forms.CheckBox checkBox_e_enable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_e_receiver;
        private System.Windows.Forms.TextBox textBox_e_smtpAuth;
        private System.Windows.Forms.TextBox textBox_e_smtp;
        private System.Windows.Forms.TextBox textBox_b_pass;
        private System.Windows.Forms.TextBox textBox_b_acc;
        private System.Windows.Forms.Label label_b_testResult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_b_test;
        private System.Windows.Forms.Button button_e_test;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_e_testResult;
        private System.Windows.Forms.Button button_signTest;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox_e_showpass;
        private System.Windows.Forms.CheckBox checkBox_t_Timer;
        private System.Windows.Forms.Button button_s_save;
        private System.Windows.Forms.Button button_s_cancel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_t_hh;
        private System.Windows.Forms.TextBox textBox_t_mm;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_t_testResult;
        private System.Windows.Forms.CheckBox checkBox_b_showpass;
        private System.Windows.Forms.TextBox textBox_t_taskID;
        private System.Windows.Forms.Label label_t_taskID;
        private System.Windows.Forms.TextBox textBox_e_sender;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}