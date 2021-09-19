
namespace HFUT_AutoSignGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_e_test = new System.Windows.Forms.Button();
            this.textBox_t_testResult = new System.Windows.Forms.TextBox();
            this.textBox_b_acc = new System.Windows.Forms.TextBox();
            this.textBox_b_pass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_e_smtp = new System.Windows.Forms.TextBox();
            this.textBox_e_sender = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_e_smtpAuth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_e_testResult = new System.Windows.Forms.Label();
            this.checkBox_e_enable = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox_b_showpass = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label12 = new System.Windows.Forms.Label();
            this.listView_t = new System.Windows.Forms.ListView();
            this.columnHeader_ID = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_acc = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_type = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_time = new System.Windows.Forms.ColumnHeader();
            this.button_t_add = new System.Windows.Forms.Button();
            this.button_t_del = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox_e_showpass = new System.Windows.Forms.CheckBox();
            this.button_b_test = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label_b_testResult = new System.Windows.Forms.Label();
            this.textBox_e_receiver = new System.Windows.Forms.TextBox();
            this.button_t_get = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_e_test
            // 
            this.button_e_test.Location = new System.Drawing.Point(18, 406);
            this.button_e_test.Name = "button_e_test";
            this.button_e_test.Size = new System.Drawing.Size(113, 29);
            this.button_e_test.TabIndex = 9;
            this.button_e_test.Text = "邮件测试";
            this.button_e_test.UseVisualStyleBackColor = true;
            this.button_e_test.Click += new System.EventHandler(this.button_e_test_Click);
            // 
            // textBox_t_testResult
            // 
            this.textBox_t_testResult.Location = new System.Drawing.Point(534, 385);
            this.textBox_t_testResult.Multiline = true;
            this.textBox_t_testResult.Name = "textBox_t_testResult";
            this.textBox_t_testResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_t_testResult.Size = new System.Drawing.Size(330, 79);
            this.textBox_t_testResult.TabIndex = 22;
            this.textBox_t_testResult.Text = "测试结果";
            // 
            // textBox_b_acc
            // 
            this.textBox_b_acc.Location = new System.Drawing.Point(89, 75);
            this.textBox_b_acc.Name = "textBox_b_acc";
            this.textBox_b_acc.Size = new System.Drawing.Size(125, 27);
            this.textBox_b_acc.TabIndex = 0;
            this.textBox_b_acc.Tag = "tb";
            this.textBox_b_acc.Text = "2019123456";
            this.textBox_b_acc.TextChanged += new System.EventHandler(this.textBox_b_acc_TextChanged);
            // 
            // textBox_b_pass
            // 
            this.textBox_b_pass.Location = new System.Drawing.Point(89, 115);
            this.textBox_b_pass.Name = "textBox_b_pass";
            this.textBox_b_pass.Size = new System.Drawing.Size(125, 27);
            this.textBox_b_pass.TabIndex = 1;
            this.textBox_b_pass.Tag = "tb";
            this.textBox_b_pass.Text = "test";
            this.textBox_b_pass.UseSystemPasswordChar = true;
            this.textBox_b_pass.TextChanged += new System.EventHandler(this.textBox_b_pass_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "学号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "密码";
            // 
            // textBox_e_smtp
            // 
            this.textBox_e_smtp.Location = new System.Drawing.Point(116, 243);
            this.textBox_e_smtp.Name = "textBox_e_smtp";
            this.textBox_e_smtp.Size = new System.Drawing.Size(168, 27);
            this.textBox_e_smtp.TabIndex = 5;
            this.textBox_e_smtp.Tag = "te";
            this.textBox_e_smtp.Text = "smtp.qq.com";
            this.textBox_e_smtp.TextChanged += new System.EventHandler(this.textBox_e_smtp_TextChanged);
            // 
            // textBox_e_sender
            // 
            this.textBox_e_sender.Location = new System.Drawing.Point(116, 283);
            this.textBox_e_sender.Name = "textBox_e_sender";
            this.textBox_e_sender.Size = new System.Drawing.Size(168, 27);
            this.textBox_e_sender.TabIndex = 6;
            this.textBox_e_sender.Tag = "te";
            this.textBox_e_sender.Text = "123456789@qq.com";
            this.textBox_e_sender.TextChanged += new System.EventHandler(this.textBox_e_sender_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "smtp服务器";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "发件人邮箱";
            // 
            // textBox_e_smtpAuth
            // 
            this.textBox_e_smtpAuth.Location = new System.Drawing.Point(116, 323);
            this.textBox_e_smtpAuth.Name = "textBox_e_smtpAuth";
            this.textBox_e_smtpAuth.Size = new System.Drawing.Size(168, 27);
            this.textBox_e_smtpAuth.TabIndex = 7;
            this.textBox_e_smtpAuth.Tag = "te";
            this.textBox_e_smtpAuth.Text = "abcdefghijklmnop";
            this.textBox_e_smtpAuth.UseSystemPasswordChar = true;
            this.textBox_e_smtpAuth.TextChanged += new System.EventHandler(this.textBox_e_smtpAuth_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "smtp授权码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "收件人邮箱";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(162, 400);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "测试结果:";
            // 
            // label_e_testResult
            // 
            this.label_e_testResult.AutoSize = true;
            this.label_e_testResult.Location = new System.Drawing.Point(211, 422);
            this.label_e_testResult.Name = "label_e_testResult";
            this.label_e_testResult.Size = new System.Drawing.Size(39, 20);
            this.label_e_testResult.TabIndex = 6;
            this.label_e_testResult.Text = "暂无";
            // 
            // checkBox_e_enable
            // 
            this.checkBox_e_enable.AutoSize = true;
            this.checkBox_e_enable.Cursor = System.Windows.Forms.Cursors.Help;
            this.checkBox_e_enable.Location = new System.Drawing.Point(76, 207);
            this.checkBox_e_enable.Name = "checkBox_e_enable";
            this.checkBox_e_enable.Size = new System.Drawing.Size(121, 24);
            this.checkBox_e_enable.TabIndex = 4;
            this.checkBox_e_enable.Text = "启用邮件模块";
            this.toolTip1.SetToolTip(this.checkBox_e_enable, "打卡程序运行结束后，将结果发送至指定邮箱(可以自己发给自己)");
            this.checkBox_e_enable.UseVisualStyleBackColor = true;
            this.checkBox_e_enable.CheckedChanged += new System.EventHandler(this.checkBox_e_enable_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(99, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "基本信息";
            // 
            // checkBox_b_showpass
            // 
            this.checkBox_b_showpass.AutoSize = true;
            this.checkBox_b_showpass.Location = new System.Drawing.Point(220, 118);
            this.checkBox_b_showpass.Name = "checkBox_b_showpass";
            this.checkBox_b_showpass.Size = new System.Drawing.Size(76, 24);
            this.checkBox_b_showpass.TabIndex = 8;
            this.checkBox_b_showpass.TabStop = false;
            this.checkBox_b_showpass.Text = "可见性";
            this.checkBox_b_showpass.UseVisualStyleBackColor = true;
            this.checkBox_b_showpass.CheckedChanged += new System.EventHandler(this.checkBox_b_showpass_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(906, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(589, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "定时设置";
            // 
            // listView_t
            // 
            this.listView_t.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ID,
            this.columnHeader_acc,
            this.columnHeader_type,
            this.columnHeader_time});
            this.listView_t.FullRowSelect = true;
            this.listView_t.HideSelection = false;
            this.listView_t.Location = new System.Drawing.Point(403, 91);
            this.listView_t.MultiSelect = false;
            this.listView_t.Name = "listView_t";
            this.listView_t.Size = new System.Drawing.Size(440, 200);
            this.listView_t.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_t.TabIndex = 10;
            this.listView_t.UseCompatibleStateImageBehavior = false;
            this.listView_t.View = System.Windows.Forms.View.Details;
            this.listView_t.SelectedIndexChanged += new System.EventHandler(this.listView_t_SelectedIndexChanged);
            // 
            // columnHeader_ID
            // 
            this.columnHeader_ID.Text = "任务ID";
            this.columnHeader_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader_acc
            // 
            this.columnHeader_acc.Text = "学号";
            this.columnHeader_acc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_acc.Width = 140;
            // 
            // columnHeader_type
            // 
            this.columnHeader_type.Text = "执行方式";
            this.columnHeader_type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_type.Width = 100;
            // 
            // columnHeader_time
            // 
            this.columnHeader_time.Text = "设定时间";
            this.columnHeader_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_time.Width = 140;
            // 
            // button_t_add
            // 
            this.button_t_add.Location = new System.Drawing.Point(466, 327);
            this.button_t_add.Name = "button_t_add";
            this.button_t_add.Size = new System.Drawing.Size(113, 29);
            this.button_t_add.TabIndex = 20;
            this.button_t_add.Text = "添加定时任务";
            this.button_t_add.UseVisualStyleBackColor = true;
            this.button_t_add.Click += new System.EventHandler(this.button_t_add_Click);
            // 
            // button_t_del
            // 
            this.button_t_del.Location = new System.Drawing.Point(664, 327);
            this.button_t_del.Name = "button_t_del";
            this.button_t_del.Size = new System.Drawing.Size(113, 29);
            this.button_t_del.TabIndex = 20;
            this.button_t_del.Text = "删除定时任务";
            this.button_t_del.UseVisualStyleBackColor = true;
            this.button_t_del.Click += new System.EventHandler(this.button_t_del_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 500;
            // 
            // checkBox_e_showpass
            // 
            this.checkBox_e_showpass.AutoSize = true;
            this.checkBox_e_showpass.Location = new System.Drawing.Point(290, 326);
            this.checkBox_e_showpass.Name = "checkBox_e_showpass";
            this.checkBox_e_showpass.Size = new System.Drawing.Size(76, 24);
            this.checkBox_e_showpass.TabIndex = 8;
            this.checkBox_e_showpass.TabStop = false;
            this.checkBox_e_showpass.Text = "可见性";
            this.checkBox_e_showpass.UseVisualStyleBackColor = true;
            this.checkBox_e_showpass.CheckedChanged += new System.EventHandler(this.checkBox_e_showpass_CheckedChanged);
            // 
            // button_b_test
            // 
            this.button_b_test.Location = new System.Drawing.Point(18, 163);
            this.button_b_test.Name = "button_b_test";
            this.button_b_test.Size = new System.Drawing.Size(113, 29);
            this.button_b_test.TabIndex = 3;
            this.button_b_test.Text = "登录测试";
            this.button_b_test.UseVisualStyleBackColor = true;
            this.button_b_test.Click += new System.EventHandler(this.button_b_test_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(162, 154);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 20);
            this.label15.TabIndex = 6;
            this.label15.Text = "测试结果:";
            // 
            // label_b_testResult
            // 
            this.label_b_testResult.AutoSize = true;
            this.label_b_testResult.Location = new System.Drawing.Point(211, 176);
            this.label_b_testResult.Name = "label_b_testResult";
            this.label_b_testResult.Size = new System.Drawing.Size(39, 20);
            this.label_b_testResult.TabIndex = 6;
            this.label_b_testResult.Text = "暂无";
            // 
            // textBox_e_receiver
            // 
            this.textBox_e_receiver.Location = new System.Drawing.Point(116, 363);
            this.textBox_e_receiver.Name = "textBox_e_receiver";
            this.textBox_e_receiver.Size = new System.Drawing.Size(168, 27);
            this.textBox_e_receiver.TabIndex = 8;
            this.textBox_e_receiver.Tag = "te";
            this.textBox_e_receiver.Text = "123456789@qq.com";
            this.textBox_e_receiver.TextChanged += new System.EventHandler(this.textBox_e_receiver_TextChanged);
            // 
            // button_t_get
            // 
            this.button_t_get.Location = new System.Drawing.Point(332, 406);
            this.button_t_get.Name = "button_t_get";
            this.button_t_get.Size = new System.Drawing.Size(176, 29);
            this.button_t_get.TabIndex = 21;
            this.button_t_get.Text = "单次打卡测试";
            this.button_t_get.UseVisualStyleBackColor = true;
            this.button_t_get.Click += new System.EventHandler(this.button_t_get_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 495);
            this.Controls.Add(this.listView_t);
            this.Controls.Add(this.checkBox_e_showpass);
            this.Controls.Add(this.checkBox_b_showpass);
            this.Controls.Add(this.checkBox_e_enable);
            this.Controls.Add(this.label_b_testResult);
            this.Controls.Add(this.label_e_testResult);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_e_receiver);
            this.Controls.Add(this.textBox_e_smtpAuth);
            this.Controls.Add(this.textBox_e_sender);
            this.Controls.Add(this.textBox_e_smtp);
            this.Controls.Add(this.textBox_b_pass);
            this.Controls.Add(this.textBox_b_acc);
            this.Controls.Add(this.textBox_t_testResult);
            this.Controls.Add(this.button_t_get);
            this.Controls.Add(this.button_t_add);
            this.Controls.Add(this.button_t_del);
            this.Controls.Add(this.button_b_test);
            this.Controls.Add(this.button_e_test);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "合工大自动打卡";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_e_test;
        private System.Windows.Forms.TextBox textBox_t_testResult;
        private System.Windows.Forms.TextBox textBox_b_acc;
        private System.Windows.Forms.TextBox textBox_b_pass;
        private System.Windows.Forms.TextBox textBox_e_smtp;
        private System.Windows.Forms.TextBox textBox_e_sender;
        private System.Windows.Forms.TextBox textBox_e_smtpAuth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_e_testResult;
        private System.Windows.Forms.CheckBox checkBox_e_enable;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_b_showpass;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListView listView_t;
        private System.Windows.Forms.Button button_t_add;
        private System.Windows.Forms.Button button_t_del;
        private System.Windows.Forms.ColumnHeader columnHeader_type;
        private System.Windows.Forms.ColumnHeader columnHeader_time;
        private System.Windows.Forms.ColumnHeader columnHeader_acc;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColumnHeader columnHeader_ID;
        private System.Windows.Forms.CheckBox checkBox_e_showpass;
        private System.Windows.Forms.Button button_b_test;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label_b_testResult;
        private System.Windows.Forms.TextBox textBox_e_receiver;
        private System.Windows.Forms.Button button_t_get;
    }
}

