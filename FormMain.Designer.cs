namespace GoogolDemo
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel_para = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1_1 = new System.Windows.Forms.TextBox();
            this.textBox2_1 = new System.Windows.Forms.TextBox();
            this.textBox3_1 = new System.Windows.Forms.TextBox();
            this.textBox1_2 = new System.Windows.Forms.TextBox();
            this.textBox2_2 = new System.Windows.Forms.TextBox();
            this.textBox3_2 = new System.Windows.Forms.TextBox();
            this.textBox1_3 = new System.Windows.Forms.TextBox();
            this.textBox2_3 = new System.Windows.Forms.TextBox();
            this.textBox3_3 = new System.Windows.Forms.TextBox();
            this.textBox1_4 = new System.Windows.Forms.TextBox();
            this.textBox2_4 = new System.Windows.Forms.TextBox();
            this.textBox3_4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_slg = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button_ChangeSpd = new System.Windows.Forms.Button();
            this.button_ChangePos = new System.Windows.Forms.Button();
            this.button_Act = new System.Windows.Forms.Button();
            this.textBox_spd = new System.Windows.Forms.TextBox();
            this.textBox_pos = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.groupBox_itp = new System.Windows.Forms.GroupBox();
            this.button_itpAct = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.groupBox_cmd = new System.Windows.Forms.GroupBox();
            this.button_rpt = new System.Windows.Forms.Button();
            this.button_HomeAct = new System.Windows.Forms.Button();
            this.button_EmgStop = new System.Windows.Forms.Button();
            this.button_stoprpt = new System.Windows.Forms.Button();
            this.timer_guard = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel_para.SuspendLayout();
            this.groupBox_slg.SuspendLayout();
            this.groupBox_itp.SuspendLayout();
            this.groupBox_cmd.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(134, 39);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Enable";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "--Select an axis--",
            ">>BAT<<",
            ">>BAZ<<",
            ">>EJP<<"});
            this.comboBox1.Location = new System.Drawing.Point(4, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(119, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.DropDown += new System.EventHandler(this.LoadItems);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "--Select an axis--",
            ">>BAT<<",
            ">>BAZ<<",
            ">>EJP<<"});
            this.comboBox2.Location = new System.Drawing.Point(4, 68);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(119, 20);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.DropDown += new System.EventHandler(this.LoadItems);
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "--Select an axis--",
            ">>BAT<<",
            ">>BAZ<<",
            ">>EJP<<"});
            this.comboBox3.Location = new System.Drawing.Point(4, 99);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(119, 20);
            this.comboBox3.TabIndex = 4;
            this.comboBox3.DropDown += new System.EventHandler(this.LoadItems);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(134, 70);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(60, 16);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Enable";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(134, 101);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(60, 16);
            this.checkBox3.TabIndex = 7;
            this.checkBox3.Text = "Enable";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // tableLayoutPanel_para
            // 
            this.tableLayoutPanel_para.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel_para.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel_para.ColumnCount = 6;
            this.tableLayoutPanel_para.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel_para.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel_para.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel_para.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel_para.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel_para.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel_para.Controls.Add(this.label6, 5, 0);
            this.tableLayoutPanel_para.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel_para.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel_para.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel_para.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel_para.Controls.Add(this.textBox1_1, 2, 1);
            this.tableLayoutPanel_para.Controls.Add(this.comboBox3, 0, 3);
            this.tableLayoutPanel_para.Controls.Add(this.checkBox1, 1, 1);
            this.tableLayoutPanel_para.Controls.Add(this.checkBox2, 1, 2);
            this.tableLayoutPanel_para.Controls.Add(this.checkBox3, 1, 3);
            this.tableLayoutPanel_para.Controls.Add(this.comboBox2, 0, 2);
            this.tableLayoutPanel_para.Controls.Add(this.comboBox1, 0, 1);
            this.tableLayoutPanel_para.Controls.Add(this.textBox2_1, 2, 2);
            this.tableLayoutPanel_para.Controls.Add(this.textBox3_1, 2, 3);
            this.tableLayoutPanel_para.Controls.Add(this.textBox1_2, 3, 1);
            this.tableLayoutPanel_para.Controls.Add(this.textBox2_2, 3, 2);
            this.tableLayoutPanel_para.Controls.Add(this.textBox3_2, 3, 3);
            this.tableLayoutPanel_para.Controls.Add(this.textBox1_3, 4, 1);
            this.tableLayoutPanel_para.Controls.Add(this.textBox2_3, 4, 2);
            this.tableLayoutPanel_para.Controls.Add(this.textBox3_3, 4, 3);
            this.tableLayoutPanel_para.Controls.Add(this.textBox1_4, 5, 1);
            this.tableLayoutPanel_para.Controls.Add(this.textBox2_4, 5, 2);
            this.tableLayoutPanel_para.Controls.Add(this.textBox3_4, 5, 3);
            this.tableLayoutPanel_para.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel_para.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel_para.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_para.Name = "tableLayoutPanel_para";
            this.tableLayoutPanel_para.RowCount = 4;
            this.tableLayoutPanel_para.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_para.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_para.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_para.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_para.Size = new System.Drawing.Size(680, 123);
            this.tableLayoutPanel_para.TabIndex = 8;
            this.tableLayoutPanel_para.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel_para_CellPaint);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(601, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "运动距离";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(478, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "运行速度";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "JERK";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "加速度";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "Enable";
            // 
            // textBox1_1
            // 
            this.textBox1_1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1_1.Location = new System.Drawing.Point(213, 36);
            this.textBox1_1.Name = "textBox1_1";
            this.textBox1_1.Size = new System.Drawing.Size(100, 21);
            this.textBox1_1.TabIndex = 9;
            this.textBox1_1.Text = "120";
            // 
            // textBox2_1
            // 
            this.textBox2_1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2_1.Location = new System.Drawing.Point(213, 67);
            this.textBox2_1.Name = "textBox2_1";
            this.textBox2_1.Size = new System.Drawing.Size(100, 21);
            this.textBox2_1.TabIndex = 10;
            this.textBox2_1.Text = "40";
            // 
            // textBox3_1
            // 
            this.textBox3_1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox3_1.Location = new System.Drawing.Point(213, 98);
            this.textBox3_1.Name = "textBox3_1";
            this.textBox3_1.Size = new System.Drawing.Size(100, 21);
            this.textBox3_1.TabIndex = 11;
            this.textBox3_1.Text = "20";
            // 
            // textBox1_2
            // 
            this.textBox1_2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1_2.Location = new System.Drawing.Point(334, 36);
            this.textBox1_2.Name = "textBox1_2";
            this.textBox1_2.Size = new System.Drawing.Size(100, 21);
            this.textBox1_2.TabIndex = 12;
            this.textBox1_2.Text = "10";
            // 
            // textBox2_2
            // 
            this.textBox2_2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2_2.Location = new System.Drawing.Point(334, 67);
            this.textBox2_2.Name = "textBox2_2";
            this.textBox2_2.Size = new System.Drawing.Size(100, 21);
            this.textBox2_2.TabIndex = 13;
            this.textBox2_2.Text = "10";
            // 
            // textBox3_2
            // 
            this.textBox3_2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox3_2.Location = new System.Drawing.Point(334, 98);
            this.textBox3_2.Name = "textBox3_2";
            this.textBox3_2.Size = new System.Drawing.Size(100, 21);
            this.textBox3_2.TabIndex = 14;
            this.textBox3_2.Text = "6";
            // 
            // textBox1_3
            // 
            this.textBox1_3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1_3.Location = new System.Drawing.Point(455, 36);
            this.textBox1_3.Name = "textBox1_3";
            this.textBox1_3.Size = new System.Drawing.Size(100, 21);
            this.textBox1_3.TabIndex = 15;
            this.textBox1_3.Text = "2500";
            // 
            // textBox2_3
            // 
            this.textBox2_3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2_3.Location = new System.Drawing.Point(455, 67);
            this.textBox2_3.Name = "textBox2_3";
            this.textBox2_3.Size = new System.Drawing.Size(100, 21);
            this.textBox2_3.TabIndex = 16;
            this.textBox2_3.Text = "400";
            // 
            // textBox3_3
            // 
            this.textBox3_3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox3_3.Location = new System.Drawing.Point(455, 98);
            this.textBox3_3.Name = "textBox3_3";
            this.textBox3_3.Size = new System.Drawing.Size(100, 21);
            this.textBox3_3.TabIndex = 17;
            this.textBox3_3.Text = "120";
            // 
            // textBox1_4
            // 
            this.textBox1_4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1_4.Location = new System.Drawing.Point(577, 36);
            this.textBox1_4.Name = "textBox1_4";
            this.textBox1_4.Size = new System.Drawing.Size(100, 21);
            this.textBox1_4.TabIndex = 18;
            this.textBox1_4.Text = "0";
            // 
            // textBox2_4
            // 
            this.textBox2_4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2_4.Location = new System.Drawing.Point(577, 67);
            this.textBox2_4.Name = "textBox2_4";
            this.textBox2_4.Size = new System.Drawing.Size(100, 21);
            this.textBox2_4.TabIndex = 19;
            this.textBox2_4.Text = "1000";
            // 
            // textBox3_4
            // 
            this.textBox3_4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox3_4.Location = new System.Drawing.Point(577, 98);
            this.textBox3_4.Name = "textBox3_4";
            this.textBox3_4.Size = new System.Drawing.Size(100, 21);
            this.textBox3_4.TabIndex = 20;
            this.textBox3_4.Text = "1200";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "Axis";
            // 
            // groupBox_slg
            // 
            this.groupBox_slg.Controls.Add(this.label9);
            this.groupBox_slg.Controls.Add(this.label8);
            this.groupBox_slg.Controls.Add(this.label7);
            this.groupBox_slg.Controls.Add(this.button_ChangeSpd);
            this.groupBox_slg.Controls.Add(this.button_ChangePos);
            this.groupBox_slg.Controls.Add(this.button_Act);
            this.groupBox_slg.Controls.Add(this.textBox_spd);
            this.groupBox_slg.Controls.Add(this.textBox_pos);
            this.groupBox_slg.Controls.Add(this.textBox13);
            this.groupBox_slg.Location = new System.Drawing.Point(16, 153);
            this.groupBox_slg.Name = "groupBox_slg";
            this.groupBox_slg.Size = new System.Drawing.Size(551, 100);
            this.groupBox_slg.TabIndex = 9;
            this.groupBox_slg.TabStop = false;
            this.groupBox_slg.Text = "SingleAxis";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(385, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "改变速度";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "改变终点";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "定距移动";
            // 
            // button_ChangeSpd
            // 
            this.button_ChangeSpd.Location = new System.Drawing.Point(398, 58);
            this.button_ChangeSpd.Name = "button_ChangeSpd";
            this.button_ChangeSpd.Size = new System.Drawing.Size(75, 23);
            this.button_ChangeSpd.TabIndex = 5;
            this.button_ChangeSpd.Text = "修改速度";
            this.button_ChangeSpd.UseVisualStyleBackColor = true;
            this.button_ChangeSpd.Click += new System.EventHandler(this.button_ChangeSpd_Click);
            // 
            // button_ChangePos
            // 
            this.button_ChangePos.Location = new System.Drawing.Point(220, 58);
            this.button_ChangePos.Name = "button_ChangePos";
            this.button_ChangePos.Size = new System.Drawing.Size(75, 23);
            this.button_ChangePos.TabIndex = 4;
            this.button_ChangePos.Text = "修改终点";
            this.button_ChangePos.UseVisualStyleBackColor = true;
            this.button_ChangePos.Click += new System.EventHandler(this.button_ChangePos_Click);
            // 
            // button_Act
            // 
            this.button_Act.Location = new System.Drawing.Point(58, 58);
            this.button_Act.Name = "button_Act";
            this.button_Act.Size = new System.Drawing.Size(75, 23);
            this.button_Act.TabIndex = 3;
            this.button_Act.Text = "开始运动";
            this.button_Act.UseVisualStyleBackColor = true;
            this.button_Act.Click += new System.EventHandler(this.button_Act_Click);
            // 
            // textBox_spd
            // 
            this.textBox_spd.Location = new System.Drawing.Point(385, 35);
            this.textBox_spd.Name = "textBox_spd";
            this.textBox_spd.Size = new System.Drawing.Size(100, 21);
            this.textBox_spd.TabIndex = 2;
            this.textBox_spd.Text = "200";
            // 
            // textBox_pos
            // 
            this.textBox_pos.Location = new System.Drawing.Point(207, 35);
            this.textBox_pos.Name = "textBox_pos";
            this.textBox_pos.Size = new System.Drawing.Size(100, 21);
            this.textBox_pos.TabIndex = 1;
            this.textBox_pos.Text = "200";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(45, 35);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(100, 21);
            this.textBox13.TabIndex = 0;
            this.textBox13.Text = "100";
            // 
            // groupBox_itp
            // 
            this.groupBox_itp.Controls.Add(this.button_itpAct);
            this.groupBox_itp.Controls.Add(this.label12);
            this.groupBox_itp.Controls.Add(this.label11);
            this.groupBox_itp.Controls.Add(this.label10);
            this.groupBox_itp.Controls.Add(this.textBox16);
            this.groupBox_itp.Controls.Add(this.textBox17);
            this.groupBox_itp.Controls.Add(this.textBox18);
            this.groupBox_itp.Location = new System.Drawing.Point(16, 272);
            this.groupBox_itp.Name = "groupBox_itp";
            this.groupBox_itp.Size = new System.Drawing.Size(551, 100);
            this.groupBox_itp.TabIndex = 10;
            this.groupBox_itp.TabStop = false;
            this.groupBox_itp.Text = "Interpolation";
            // 
            // button_itpAct
            // 
            this.button_itpAct.Location = new System.Drawing.Point(45, 65);
            this.button_itpAct.Name = "button_itpAct";
            this.button_itpAct.Size = new System.Drawing.Size(440, 23);
            this.button_itpAct.TabIndex = 10;
            this.button_itpAct.Text = "插补运动测试";
            this.button_itpAct.UseVisualStyleBackColor = true;
            this.button_itpAct.Click += new System.EventHandler(this.button_itpAct_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(385, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "EJP位移";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(207, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "BAZ位移";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "BAT位移";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(385, 38);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(100, 21);
            this.textBox16.TabIndex = 5;
            this.textBox16.Text = "100";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(207, 38);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(100, 21);
            this.textBox17.TabIndex = 4;
            this.textBox17.Text = "2000";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(45, 38);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(100, 21);
            this.textBox18.TabIndex = 3;
            this.textBox18.Text = "2000";
            // 
            // groupBox_cmd
            // 
            this.groupBox_cmd.Controls.Add(this.button_rpt);
            this.groupBox_cmd.Controls.Add(this.button_HomeAct);
            this.groupBox_cmd.Controls.Add(this.button_EmgStop);
            this.groupBox_cmd.Controls.Add(this.button_stoprpt);
            this.groupBox_cmd.Location = new System.Drawing.Point(588, 153);
            this.groupBox_cmd.Name = "groupBox_cmd";
            this.groupBox_cmd.Size = new System.Drawing.Size(100, 219);
            this.groupBox_cmd.TabIndex = 11;
            this.groupBox_cmd.TabStop = false;
            this.groupBox_cmd.Text = "Command";
            // 
            // button_rpt
            // 
            this.button_rpt.Location = new System.Drawing.Point(13, 79);
            this.button_rpt.Name = "button_rpt";
            this.button_rpt.Size = new System.Drawing.Size(75, 23);
            this.button_rpt.TabIndex = 3;
            this.button_rpt.Text = "连续测试";
            this.button_rpt.UseVisualStyleBackColor = true;
            this.button_rpt.Click += new System.EventHandler(this.button_rpt_Click);
            // 
            // button_HomeAct
            // 
            this.button_HomeAct.Location = new System.Drawing.Point(13, 32);
            this.button_HomeAct.Name = "button_HomeAct";
            this.button_HomeAct.Size = new System.Drawing.Size(75, 23);
            this.button_HomeAct.TabIndex = 2;
            this.button_HomeAct.Text = "回原点";
            this.button_HomeAct.UseVisualStyleBackColor = true;
            this.button_HomeAct.Click += new System.EventHandler(this.button_HomeAct_Click);
            // 
            // button_EmgStop
            // 
            this.button_EmgStop.Location = new System.Drawing.Point(13, 173);
            this.button_EmgStop.Name = "button_EmgStop";
            this.button_EmgStop.Size = new System.Drawing.Size(75, 23);
            this.button_EmgStop.TabIndex = 1;
            this.button_EmgStop.Text = "急停";
            this.button_EmgStop.UseVisualStyleBackColor = true;
            this.button_EmgStop.Click += new System.EventHandler(this.button_EmgStop_Click);
            // 
            // button_stoprpt
            // 
            this.button_stoprpt.Location = new System.Drawing.Point(13, 126);
            this.button_stoprpt.Name = "button_stoprpt";
            this.button_stoprpt.Size = new System.Drawing.Size(75, 23);
            this.button_stoprpt.TabIndex = 0;
            this.button_stoprpt.Text = "停止测试";
            this.button_stoprpt.UseVisualStyleBackColor = true;
            this.button_stoprpt.Click += new System.EventHandler(this.button_stoprpt_Click);
            // 
            // timer_guard
            // 
            this.timer_guard.Tick += new System.EventHandler(this.timer_guard_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 385);
            this.Controls.Add(this.groupBox_cmd);
            this.Controls.Add(this.groupBox_itp);
            this.Controls.Add(this.groupBox_slg);
            this.Controls.Add(this.tableLayoutPanel_para);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tableLayoutPanel_para.ResumeLayout(false);
            this.tableLayoutPanel_para.PerformLayout();
            this.groupBox_slg.ResumeLayout(false);
            this.groupBox_slg.PerformLayout();
            this.groupBox_itp.ResumeLayout(false);
            this.groupBox_itp.PerformLayout();
            this.groupBox_cmd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_para;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1_1;
        private System.Windows.Forms.TextBox textBox2_1;
        private System.Windows.Forms.TextBox textBox3_1;
        private System.Windows.Forms.TextBox textBox1_2;
        private System.Windows.Forms.TextBox textBox2_2;
        private System.Windows.Forms.TextBox textBox3_2;
        private System.Windows.Forms.TextBox textBox1_3;
        private System.Windows.Forms.TextBox textBox2_3;
        private System.Windows.Forms.TextBox textBox3_3;
        private System.Windows.Forms.TextBox textBox1_4;
        private System.Windows.Forms.TextBox textBox2_4;
        private System.Windows.Forms.TextBox textBox3_4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_slg;
        private System.Windows.Forms.GroupBox groupBox_itp;
        private System.Windows.Forms.GroupBox groupBox_cmd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_ChangeSpd;
        private System.Windows.Forms.Button button_ChangePos;
        private System.Windows.Forms.Button button_Act;
        private System.Windows.Forms.TextBox textBox_spd;
        private System.Windows.Forms.TextBox textBox_pos;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Button button_itpAct;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Button button_rpt;
        private System.Windows.Forms.Button button_HomeAct;
        private System.Windows.Forms.Button button_EmgStop;
        private System.Windows.Forms.Button button_stoprpt;
        private System.Windows.Forms.Timer timer_guard;
    }
}

