using System;

namespace Version1
{
    partial class Form1
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

        #region  Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.arrivalText_fcfs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.waitingText_fcfs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.burstText_fcfs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nofprocesses = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2_fcfs = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3_fcfs_nums = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SJFTabPage = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.consol = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ganttChart = new System.Windows.Forms.DataGridView();
            this.drawButton = new System.Windows.Forms.Button();
            this.nonPremptiveRB = new System.Windows.Forms.RadioButton();
            this.premptiveRB = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.lable3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.burstTimeTF = new System.Windows.Forms.TextBox();
            this.arrivalTimeTF = new System.Windows.Forms.TextBox();
            this.processTF = new System.Windows.Forms.TextBox();
            this.insert = new System.Windows.Forms.Button();
            this.processGrid = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SJFTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ganttChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.SJFTabPage);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(10, 5);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(872, 595);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.arrivalText_fcfs);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.waitingText_fcfs);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.burstText_fcfs);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.nofprocesses);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.tabPage1.Size = new System.Drawing.Size(864, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "FCFS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(199, 202);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Enter burst time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(38, 302);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(499, 42);
            this.label6.TabIndex = 15;
            this.label6.Text = "NOTE: first process arrival time must be 0 and other processes must be\r\n greater " +
    "than 0.Or all arrival times equal 0.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(199, 249);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Enter arrival time:";
            // 
            // arrivalText_fcfs
            // 
            this.arrivalText_fcfs.Location = new System.Drawing.Point(388, 249);
            this.arrivalText_fcfs.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.arrivalText_fcfs.Name = "arrivalText_fcfs";
            this.arrivalText_fcfs.Size = new System.Drawing.Size(148, 29);
            this.arrivalText_fcfs.TabIndex = 13;
            this.arrivalText_fcfs.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(62, 362);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "average waiting time=";
            // 
            // waitingText_fcfs
            // 
            this.waitingText_fcfs.Location = new System.Drawing.Point(388, 358);
            this.waitingText_fcfs.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.waitingText_fcfs.Name = "waitingText_fcfs";
            this.waitingText_fcfs.Size = new System.Drawing.Size(140, 29);
            this.waitingText_fcfs.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(34, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(407, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Enter burst time and arrival time of the process and click insert button:";
            // 
            // burstText_fcfs
            // 
            this.burstText_fcfs.Location = new System.Drawing.Point(388, 200);
            this.burstText_fcfs.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.burstText_fcfs.Name = "burstText_fcfs";
            this.burstText_fcfs.Size = new System.Drawing.Size(148, 29);
            this.burstText_fcfs.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(34, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter number of processes ,then click ok:";
            // 
            // nofprocesses
            // 
            this.nofprocesses.Location = new System.Drawing.Point(410, 51);
            this.nofprocesses.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.nofprocesses.Name = "nofprocesses";
            this.nofprocesses.Size = new System.Drawing.Size(148, 29);
            this.nofprocesses.TabIndex = 0;
            this.nofprocesses.TextChanged += new System.EventHandler(this.nofprocesses_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(628, 207);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 62);
            this.button2.TabIndex = 9;
            this.button2.Text = "insert";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(603, 49);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2_fcfs);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3_fcfs_nums);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(44, 407);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(778, 111);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2_fcfs
            // 
            this.flowLayoutPanel2_fcfs.AutoSize = true;
            this.flowLayoutPanel2_fcfs.BackColor = System.Drawing.Color.DarkRed;
            this.flowLayoutPanel2_fcfs.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel2_fcfs.Location = new System.Drawing.Point(4, 2);
            this.flowLayoutPanel2_fcfs.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.flowLayoutPanel2_fcfs.Name = "flowLayoutPanel2_fcfs";
            this.flowLayoutPanel2_fcfs.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel2_fcfs.TabIndex = 0;
            // 
            // flowLayoutPanel3_fcfs_nums
            // 
            this.flowLayoutPanel3_fcfs_nums.AutoSize = true;
            this.flowLayoutPanel3_fcfs_nums.Location = new System.Drawing.Point(4, 6);
            this.flowLayoutPanel3_fcfs_nums.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.flowLayoutPanel3_fcfs_nums.Name = "flowLayoutPanel3_fcfs_nums";
            this.flowLayoutPanel3_fcfs_nums.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel3_fcfs_nums.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(864, 557);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Roundrobin";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(169, 213);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(140, 29);
            this.textBox4.TabIndex = 44;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(25, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 21);
            this.label14.TabIndex = 42;
            this.label14.Text = "Process";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label15.Location = new System.Drawing.Point(266, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(220, 51);
            this.label15.TabIndex = 41;
            this.label15.Text = "Roundrobin";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button3.Location = new System.Drawing.Point(439, 278);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(273, 52);
            this.button3.TabIndex = 40;
            this.button3.Text = "Simulation";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(25, 215);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 21);
            this.label16.TabIndex = 37;
            this.label16.Text = "Quantum time";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(25, 171);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 21);
            this.label17.TabIndex = 36;
            this.label17.Text = "Burst time";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(25, 129);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(91, 21);
            this.label18.TabIndex = 35;
            this.label18.Text = "Arrival time";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(169, 171);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 29);
            this.textBox1.TabIndex = 34;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(169, 129);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(140, 29);
            this.textBox2.TabIndex = 33;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(169, 86);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(140, 29);
            this.textBox3.TabIndex = 32;
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button4.Location = new System.Drawing.Point(25, 278);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(284, 49);
            this.button4.TabIndex = 31;
            this.button4.Text = "Insert";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(356, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(454, 157);
            this.dataGridView1.TabIndex = 30;
            // 
            // SJFTabPage
            // 
            this.SJFTabPage.Controls.Add(this.label13);
            this.SJFTabPage.Controls.Add(this.label12);
            this.SJFTabPage.Controls.Add(this.consol);
            this.SJFTabPage.Controls.Add(this.label11);
            this.SJFTabPage.Controls.Add(this.ganttChart);
            this.SJFTabPage.Controls.Add(this.drawButton);
            this.SJFTabPage.Controls.Add(this.nonPremptiveRB);
            this.SJFTabPage.Controls.Add(this.premptiveRB);
            this.SJFTabPage.Controls.Add(this.label8);
            this.SJFTabPage.Controls.Add(this.lable3);
            this.SJFTabPage.Controls.Add(this.label9);
            this.SJFTabPage.Controls.Add(this.label10);
            this.SJFTabPage.Controls.Add(this.burstTimeTF);
            this.SJFTabPage.Controls.Add(this.arrivalTimeTF);
            this.SJFTabPage.Controls.Add(this.processTF);
            this.SJFTabPage.Controls.Add(this.insert);
            this.SJFTabPage.Controls.Add(this.processGrid);
            this.SJFTabPage.Location = new System.Drawing.Point(4, 34);
            this.SJFTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SJFTabPage.Name = "SJFTabPage";
            this.SJFTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SJFTabPage.Size = new System.Drawing.Size(864, 557);
            this.SJFTabPage.TabIndex = 2;
            this.SJFTabPage.Text = "tabPage3";
            this.SJFTabPage.UseVisualStyleBackColor = true;
            this.SJFTabPage.Click += new System.EventHandler(this.SJFTabPage_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 21);
            this.label12.TabIndex = 29;
            this.label12.Text = "label12";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // consol
            // 
            this.consol.AutoSize = true;
            this.consol.Location = new System.Drawing.Point(28, 32);
            this.consol.Name = "consol";
            this.consol.Size = new System.Drawing.Size(61, 21);
            this.consol.TabIndex = 28;
            this.consol.Text = "label12";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(290, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(299, 47);
            this.label11.TabIndex = 27;
            this.label11.Text = "Shortest Job First";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // ganttChart
            // 
            this.ganttChart.AllowUserToAddRows = false;
            this.ganttChart.AllowUserToDeleteRows = false;
            this.ganttChart.AllowUserToResizeColumns = false;
            this.ganttChart.AllowUserToResizeRows = false;
            this.ganttChart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ganttChart.Location = new System.Drawing.Point(1, 382);
            this.ganttChart.Name = "ganttChart";
            this.ganttChart.RowHeadersWidth = 51;
            this.ganttChart.RowTemplate.Height = 25;
            this.ganttChart.Size = new System.Drawing.Size(860, 106);
            this.ganttChart.TabIndex = 25;
            this.ganttChart.Visible = false;
            // 
            // drawButton
            // 
            this.drawButton.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.drawButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.drawButton.Location = new System.Drawing.Point(351, 321);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(170, 33);
            this.drawButton.TabIndex = 24;
            this.drawButton.Text = "Draw Gantt Chart";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click_1);
            // 
            // nonPremptiveRB
            // 
            this.nonPremptiveRB.AutoSize = true;
            this.nonPremptiveRB.Location = new System.Drawing.Point(732, 84);
            this.nonPremptiveRB.Name = "nonPremptiveRB";
            this.nonPremptiveRB.Size = new System.Drawing.Size(135, 25);
            this.nonPremptiveRB.TabIndex = 23;
            this.nonPremptiveRB.TabStop = true;
            this.nonPremptiveRB.Text = "Non-Premptive";
            this.nonPremptiveRB.UseVisualStyleBackColor = true;
            // 
            // premptiveRB
            // 
            this.premptiveRB.AutoSize = true;
            this.premptiveRB.Location = new System.Drawing.Point(617, 84);
            this.premptiveRB.Name = "premptiveRB";
            this.premptiveRB.Size = new System.Drawing.Size(100, 25);
            this.premptiveRB.TabIndex = 22;
            this.premptiveRB.TabStop = true;
            this.premptiveRB.Text = "Premprive";
            this.premptiveRB.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 26;
            // 
            // lable3
            // 
            this.lable3.AutoSize = true;
            this.lable3.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lable3.Location = new System.Drawing.Point(560, 136);
            this.lable3.Name = "lable3";
            this.lable3.Size = new System.Drawing.Size(77, 20);
            this.lable3.TabIndex = 20;
            this.lable3.Text = "Burst time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(399, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Arrival time";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(251, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Process";
            // 
            // burstTimeTF
            // 
            this.burstTimeTF.Location = new System.Drawing.Point(527, 159);
            this.burstTimeTF.Name = "burstTimeTF";
            this.burstTimeTF.Size = new System.Drawing.Size(140, 29);
            this.burstTimeTF.TabIndex = 17;
            // 
            // arrivalTimeTF
            // 
            this.arrivalTimeTF.Location = new System.Drawing.Point(371, 159);
            this.arrivalTimeTF.Name = "arrivalTimeTF";
            this.arrivalTimeTF.Size = new System.Drawing.Size(140, 29);
            this.arrivalTimeTF.TabIndex = 16;
            // 
            // processTF
            // 
            this.processTF.Location = new System.Drawing.Point(214, 159);
            this.processTF.Name = "processTF";
            this.processTF.Size = new System.Drawing.Size(140, 29);
            this.processTF.TabIndex = 15;
            // 
            // insert
            // 
            this.insert.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.insert.Location = new System.Drawing.Point(732, 210);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(70, 70);
            this.insert.TabIndex = 14;
            this.insert.Text = "+";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click_1);
            // 
            // processGrid
            // 
            this.processGrid.AllowUserToAddRows = false;
            this.processGrid.AllowUserToDeleteRows = false;
            this.processGrid.AllowUserToResizeColumns = false;
            this.processGrid.AllowUserToResizeRows = false;
            this.processGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.processGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.processGrid.Location = new System.Drawing.Point(214, 189);
            this.processGrid.Name = "processGrid";
            this.processGrid.RowHeadersWidth = 51;
            this.processGrid.RowTemplate.Height = 25;
            this.processGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.processGrid.Size = new System.Drawing.Size(454, 126);
            this.processGrid.TabIndex = 13;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(864, 557);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 226);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 21);
            this.label13.TabIndex = 30;
            this.label13.Text = "label13";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 593);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "CPU_Scheduler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.SJFTabPage.ResumeLayout(false);
            this.SJFTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ganttChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processGrid)).EndInit();
            this.ResumeLayout(false);

        }

        private void nofprocesses_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SJFTabPage_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage SJFTabPage;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2_fcfs;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3_fcfs_nums;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nofprocesses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox burstText_fcfs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox waitingText_fcfs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox arrivalText_fcfs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView ganttChart;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.RadioButton nonPremptiveRB;
        private System.Windows.Forms.RadioButton premptiveRB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lable3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox burstTimeTF;
        private System.Windows.Forms.TextBox arrivalTimeTF;
        private System.Windows.Forms.TextBox processTF;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.DataGridView processGrid;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label consol;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label13;
    }
}
