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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Remove_all_fcfs = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
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
            this.Average_label = new System.Windows.Forms.Label();
            this.arrivaltime_textbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RR_simulate = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.setquantum = new System.Windows.Forms.Button();
            this.Error_label = new System.Windows.Forms.Label();
            this.RR_dataGridView = new System.Windows.Forms.DataGridView();
            this.quantum_TextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.bursttime_textBox = new System.Windows.Forms.TextBox();
            this.Process_textBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SJFTabPage = new System.Windows.Forms.TabPage();
            this.averageWaitingTime = new System.Windows.Forms.Label();
            this.averageTurnAroundTime = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.ganttChart = new System.Windows.Forms.DataGridView();
            this.drawButton = new System.Windows.Forms.Button();
            this.nonPremptiveRB = new System.Windows.Forms.RadioButton();
            this.premptiveRB = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.subtitle3 = new System.Windows.Forms.Label();
            this.subtitle2 = new System.Windows.Forms.Label();
            this.subtitle1 = new System.Windows.Forms.Label();
            this.burstTimeTF = new System.Windows.Forms.TextBox();
            this.arrivalTimeTF = new System.Windows.Forms.TextBox();
            this.processTF = new System.Windows.Forms.TextBox();
            this.insert = new System.Windows.Forms.Button();
            this.processGrid = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.arrIval_SJF_textbox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridView_SJF = new System.Windows.Forms.DataGridView();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.bursttime_SJF_textbox = new System.Windows.Forms.TextBox();
            this.Process_SJF_textbox = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RR_dataGridView)).BeginInit();
            this.SJFTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ganttChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processGrid)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SJF)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.SJFTabPage);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.Off;
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
            this.tabPage1.Controls.Add(this.Remove_all_fcfs);
            this.tabPage1.Controls.Add(this.label7);
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
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage1.Size = new System.Drawing.Size(864, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "FCFS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Remove_all_fcfs
            // 
            this.Remove_all_fcfs.ForeColor = System.Drawing.Color.Red;
            this.Remove_all_fcfs.Location = new System.Drawing.Point(34, 84);
            this.Remove_all_fcfs.Name = "Remove_all_fcfs";
            this.Remove_all_fcfs.Size = new System.Drawing.Size(298, 41);
            this.Remove_all_fcfs.TabIndex = 18;
            this.Remove_all_fcfs.Text = "Remove all processes";
            this.Remove_all_fcfs.UseVisualStyleBackColor = true;
            this.Remove_all_fcfs.Click += new System.EventHandler(this.Remove_all_fcfs_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(199, 202);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Enter burst time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(199, 249);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Enter arrival time:";
            // 
            // arrivalText_fcfs
            // 
            this.arrivalText_fcfs.Location = new System.Drawing.Point(410, 238);
            this.arrivalText_fcfs.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.arrivalText_fcfs.Name = "arrivalText_fcfs";
            this.arrivalText_fcfs.Size = new System.Drawing.Size(148, 29);
            this.arrivalText_fcfs.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(199, 342);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "average waiting time =";
            // 
            // waitingText_fcfs
            // 
            this.waitingText_fcfs.Location = new System.Drawing.Point(410, 331);
            this.waitingText_fcfs.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.waitingText_fcfs.Name = "waitingText_fcfs";
            this.waitingText_fcfs.Size = new System.Drawing.Size(140, 29);
            this.waitingText_fcfs.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(34, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(456, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Enter burst time and arrival time of the process and click insert button:";
            // 
            // burstText_fcfs
            // 
            this.burstText_fcfs.Location = new System.Drawing.Point(410, 191);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(34, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 15);
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
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(628, 207);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 62);
            this.button2.TabIndex = 9;
            this.button2.Text = "insert";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(628, 49);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2_fcfs);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3_fcfs_nums);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(44, 410);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(778, 111);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2_fcfs
            // 
            this.flowLayoutPanel2_fcfs.AutoSize = true;
            this.flowLayoutPanel2_fcfs.BackColor = System.Drawing.Color.Blue;
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
            this.tabPage2.Controls.Add(this.Average_label);
            this.tabPage2.Controls.Add(this.arrivaltime_textbox);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.RR_simulate);
            this.tabPage2.Controls.Add(this.flowLayoutPanel3);
            this.tabPage2.Controls.Add(this.flowLayoutPanel2);
            this.tabPage2.Controls.Add(this.setquantum);
            this.tabPage2.Controls.Add(this.Error_label);
            this.tabPage2.Controls.Add(this.RR_dataGridView);
            this.tabPage2.Controls.Add(this.quantum_TextBox);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.bursttime_textBox);
            this.tabPage2.Controls.Add(this.Process_textBox);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(864, 557);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Roundrobin";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // Average_label
            // 
            this.Average_label.AutoSize = true;
            this.Average_label.Location = new System.Drawing.Point(32, 361);
            this.Average_label.Name = "Average_label";
            this.Average_label.Size = new System.Drawing.Size(139, 21);
            this.Average_label.TabIndex = 58;
            this.Average_label.Text = "Total waiting time: ";
            // 
            // arrivaltime_textbox
            // 
            this.arrivaltime_textbox.Location = new System.Drawing.Point(169, 171);
            this.arrivaltime_textbox.Name = "arrivaltime_textbox";
            this.arrivaltime_textbox.Size = new System.Drawing.Size(100, 29);
            this.arrivaltime_textbox.TabIndex = 57;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 21);
            this.label6.TabIndex = 56;
            this.label6.Text = "Arrival time";
            // 
            // RR_simulate
            // 
            this.RR_simulate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.RR_simulate.Location = new System.Drawing.Point(462, 287);
            this.RR_simulate.Name = "RR_simulate";
            this.RR_simulate.Size = new System.Drawing.Size(273, 43);
            this.RR_simulate.TabIndex = 55;
            this.RR_simulate.Text = "Simulate";
            this.RR_simulate.UseVisualStyleBackColor = true;
            this.RR_simulate.Click += new System.EventHandler(this.RR_simulate_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label9);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(25, 472);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(777, 43);
            this.flowLayoutPanel3.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 21);
            this.label9.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(25, 409);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(777, 57);
            this.flowLayoutPanel2.TabIndex = 51;
            // 
            // setquantum
            // 
            this.setquantum.ForeColor = System.Drawing.SystemColors.Highlight;
            this.setquantum.Location = new System.Drawing.Point(326, 287);
            this.setquantum.Name = "setquantum";
            this.setquantum.Size = new System.Drawing.Size(94, 38);
            this.setquantum.TabIndex = 50;
            this.setquantum.Text = "Set";
            this.setquantum.UseVisualStyleBackColor = true;
            this.setquantum.Click += new System.EventHandler(this.setquantum_Click);
            // 
            // Error_label
            // 
            this.Error_label.AutoSize = true;
            this.Error_label.ForeColor = System.Drawing.Color.Red;
            this.Error_label.Location = new System.Drawing.Point(25, 359);
            this.Error_label.Name = "Error_label";
            this.Error_label.Size = new System.Drawing.Size(0, 21);
            this.Error_label.TabIndex = 49;
            // 
            // RR_dataGridView
            // 
            this.RR_dataGridView.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.RR_dataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.RR_dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.RR_dataGridView.ColumnHeadersHeight = 40;
            this.RR_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.RR_dataGridView.GridColor = System.Drawing.SystemColors.Desktop;
            this.RR_dataGridView.Location = new System.Drawing.Point(368, 76);
            this.RR_dataGridView.Name = "RR_dataGridView";
            this.RR_dataGridView.RowHeadersWidth = 51;
            this.RR_dataGridView.RowTemplate.Height = 29;
            this.RR_dataGridView.Size = new System.Drawing.Size(434, 188);
            this.RR_dataGridView.TabIndex = 48;
            this.RR_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RR_dataGridView_CellContentClick);
            // 
            // quantum_TextBox
            // 
            this.quantum_TextBox.Location = new System.Drawing.Point(169, 287);
            this.quantum_TextBox.Name = "quantum_TextBox";
            this.quantum_TextBox.Size = new System.Drawing.Size(140, 29);
            this.quantum_TextBox.TabIndex = 44;
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
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(25, 287);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 21);
            this.label16.TabIndex = 37;
            this.label16.Text = "Quantum time";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(25, 126);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 21);
            this.label17.TabIndex = 36;
            this.label17.Text = "Burst time";
            // 
            // bursttime_textBox
            // 
            this.bursttime_textBox.Location = new System.Drawing.Point(169, 123);
            this.bursttime_textBox.Name = "bursttime_textBox";
            this.bursttime_textBox.Size = new System.Drawing.Size(100, 29);
            this.bursttime_textBox.TabIndex = 53;
            // 
            // Process_textBox
            // 
            this.Process_textBox.Location = new System.Drawing.Point(169, 83);
            this.Process_textBox.Name = "Process_textBox";
            this.Process_textBox.Size = new System.Drawing.Size(100, 29);
            this.Process_textBox.TabIndex = 54;
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button4.Location = new System.Drawing.Point(25, 215);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(284, 49);
            this.button4.TabIndex = 31;
            this.button4.Text = "Insert";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // SJFTabPage
            // 
            this.SJFTabPage.Controls.Add(this.averageWaitingTime);
            this.SJFTabPage.Controls.Add(this.averageTurnAroundTime);
            this.SJFTabPage.Controls.Add(this.title);
            this.SJFTabPage.Controls.Add(this.ganttChart);
            this.SJFTabPage.Controls.Add(this.drawButton);
            this.SJFTabPage.Controls.Add(this.nonPremptiveRB);
            this.SJFTabPage.Controls.Add(this.premptiveRB);
            this.SJFTabPage.Controls.Add(this.label8);
            this.SJFTabPage.Controls.Add(this.subtitle3);
            this.SJFTabPage.Controls.Add(this.subtitle2);
            this.SJFTabPage.Controls.Add(this.subtitle1);
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
            this.SJFTabPage.Text = "SJF";
            this.SJFTabPage.UseVisualStyleBackColor = true;
            // 
            // averageWaitingTime
            // 
            this.averageWaitingTime.AutoSize = true;
            this.averageWaitingTime.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.averageWaitingTime.Location = new System.Drawing.Point(8, 479);
            this.averageWaitingTime.Name = "averageWaitingTime";
            this.averageWaitingTime.Size = new System.Drawing.Size(162, 20);
            this.averageWaitingTime.TabIndex = 29;
            this.averageWaitingTime.Text = "Average Waiting time = ";
            this.averageWaitingTime.Visible = false;
            this.averageWaitingTime.Click += new System.EventHandler(this.label22_Click);
            // 
            // averageTurnAroundTime
            // 
            this.averageTurnAroundTime.AutoSize = true;
            this.averageTurnAroundTime.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.averageTurnAroundTime.Location = new System.Drawing.Point(8, 516);
            this.averageTurnAroundTime.Name = "averageTurnAroundTime";
            this.averageTurnAroundTime.Size = new System.Drawing.Size(190, 20);
            this.averageTurnAroundTime.TabIndex = 28;
            this.averageTurnAroundTime.Text = "Average Turn around time = ";
            this.averageTurnAroundTime.Visible = false;
            this.averageTurnAroundTime.Click += new System.EventHandler(this.averageTurnAroundTime_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.title.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.title.Location = new System.Drawing.Point(290, 32);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(299, 47);
            this.title.TabIndex = 27;
            this.title.Text = "Shortest Job First";
            // 
            // ganttChart
            // 
            this.ganttChart.AllowUserToAddRows = false;
            this.ganttChart.AllowUserToDeleteRows = false;
            this.ganttChart.AllowUserToResizeColumns = false;
            this.ganttChart.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle1.NullValue = null;
            this.ganttChart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ganttChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ganttChart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ganttChart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ganttChart.DefaultCellStyle = dataGridViewCellStyle3;
            this.ganttChart.Location = new System.Drawing.Point(1, 389);
            this.ganttChart.Name = "ganttChart";
            this.ganttChart.RowHeadersVisible = false;
            this.ganttChart.RowHeadersWidth = 51;
            this.ganttChart.RowTemplate.Height = 25;
            this.ganttChart.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ganttChart.Size = new System.Drawing.Size(860, 76);
            this.ganttChart.TabIndex = 25;
            this.ganttChart.Visible = false;
            // 
            // drawButton
            // 
            this.drawButton.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.drawButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.drawButton.Location = new System.Drawing.Point(351, 337);
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
            // subtitle3
            // 
            this.subtitle3.AutoSize = true;
            this.subtitle3.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.subtitle3.Location = new System.Drawing.Point(560, 136);
            this.subtitle3.Name = "subtitle3";
            this.subtitle3.Size = new System.Drawing.Size(77, 20);
            this.subtitle3.TabIndex = 20;
            this.subtitle3.Text = "Burst time";
            // 
            // subtitle2
            // 
            this.subtitle2.AutoSize = true;
            this.subtitle2.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.subtitle2.Location = new System.Drawing.Point(399, 136);
            this.subtitle2.Name = "subtitle2";
            this.subtitle2.Size = new System.Drawing.Size(84, 20);
            this.subtitle2.TabIndex = 19;
            this.subtitle2.Text = "Arrival time";
            // 
            // subtitle1
            // 
            this.subtitle1.AutoSize = true;
            this.subtitle1.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.subtitle1.Location = new System.Drawing.Point(251, 136);
            this.subtitle1.Name = "subtitle1";
            this.subtitle1.Size = new System.Drawing.Size(63, 20);
            this.subtitle1.TabIndex = 18;
            this.subtitle1.Text = "Process";
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
            this.processGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.processGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.processGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.processGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.processGrid.Location = new System.Drawing.Point(214, 189);
            this.processGrid.MultiSelect = false;
            this.processGrid.Name = "processGrid";
            this.processGrid.ReadOnly = true;
            this.processGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.processGrid.RowHeadersWidth = 51;
            this.processGrid.RowTemplate.Height = 25;
            this.processGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.processGrid.ShowCellErrors = false;
            this.processGrid.ShowCellToolTips = false;
            this.processGrid.ShowEditingIcon = false;
            this.processGrid.ShowRowErrors = false;
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.arrIval_SJF_textbox);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Controls.Add(this.flowLayoutPanel4);
            this.tabPage3.Controls.Add(this.flowLayoutPanel5);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.dataGridView_SJF);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.bursttime_SJF_textbox);
            this.tabPage3.Controls.Add(this.Process_SJF_textbox);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(864, 557);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "SJF (NP)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(51, 373);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 21);
            this.label10.TabIndex = 75;
            this.label10.Text = "Total waiting time: ";
            // 
            // arrIval_SJF_textbox
            // 
            this.arrIval_SJF_textbox.Location = new System.Drawing.Point(188, 183);
            this.arrIval_SJF_textbox.Name = "arrIval_SJF_textbox";
            this.arrIval_SJF_textbox.Size = new System.Drawing.Size(100, 29);
            this.arrIval_SJF_textbox.TabIndex = 74;
            this.arrIval_SJF_textbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 183);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 21);
            this.label11.TabIndex = 73;
            this.label11.Text = "Arrival time";
            // 
            // button6
            // 
            this.button6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button6.Location = new System.Drawing.Point(481, 299);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(273, 43);
            this.button6.TabIndex = 72;
            this.button6.Text = "Simulate";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label12);
            this.flowLayoutPanel4.Controls.Add(this.label20);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(44, 484);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(777, 43);
            this.flowLayoutPanel4.TabIndex = 69;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 21);
            this.label12.TabIndex = 0;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 21);
            this.label20.TabIndex = 1;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Location = new System.Drawing.Point(44, 421);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(777, 57);
            this.flowLayoutPanel5.TabIndex = 68;
            this.flowLayoutPanel5.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel5_Paint);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(44, 371);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 21);
            this.label13.TabIndex = 66;
            // 
            // dataGridView_SJF
            // 
            this.dataGridView_SJF.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_SJF.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView_SJF.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_SJF.ColumnHeadersHeight = 40;
            this.dataGridView_SJF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_SJF.GridColor = System.Drawing.SystemColors.Desktop;
            this.dataGridView_SJF.Location = new System.Drawing.Point(387, 88);
            this.dataGridView_SJF.Name = "dataGridView_SJF";
            this.dataGridView_SJF.RowHeadersWidth = 51;
            this.dataGridView_SJF.RowTemplate.Height = 29;
            this.dataGridView_SJF.Size = new System.Drawing.Size(434, 188);
            this.dataGridView_SJF.TabIndex = 65;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(44, 98);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 21);
            this.label18.TabIndex = 63;
            this.label18.Text = "Process";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label19.Location = new System.Drawing.Point(188, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(361, 51);
            this.label19.TabIndex = 62;
            this.label19.Text = "SJF Non-Preemptive";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label21.Location = new System.Drawing.Point(44, 138);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(81, 21);
            this.label21.TabIndex = 60;
            this.label21.Text = "Burst time";
            // 
            // bursttime_SJF_textbox
            // 
            this.bursttime_SJF_textbox.Location = new System.Drawing.Point(188, 135);
            this.bursttime_SJF_textbox.Name = "bursttime_SJF_textbox";
            this.bursttime_SJF_textbox.Size = new System.Drawing.Size(100, 29);
            this.bursttime_SJF_textbox.TabIndex = 70;
            // 
            // Process_SJF_textbox
            // 
            this.Process_SJF_textbox.Location = new System.Drawing.Point(188, 95);
            this.Process_SJF_textbox.Name = "Process_SJF_textbox";
            this.Process_SJF_textbox.Size = new System.Drawing.Size(100, 29);
            this.Process_SJF_textbox.TabIndex = 71;
            this.Process_SJF_textbox.TextChanged += new System.EventHandler(this.Process_SJF_textbox_TextChanged);
            // 
            // button8
            // 
            this.button8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button8.Location = new System.Drawing.Point(44, 227);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(284, 49);
            this.button8.TabIndex = 59;
            this.button8.Text = "Insert";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 609);
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
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RR_dataGridView)).EndInit();
            this.SJFTabPage.ResumeLayout(false);
            this.SJFTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ganttChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processGrid)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SJF)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView ganttChart;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.RadioButton nonPremptiveRB;
        private System.Windows.Forms.RadioButton premptiveRB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label subtitle3;
        private System.Windows.Forms.Label subtitle2;
        private System.Windows.Forms.Label subtitle1;
        private System.Windows.Forms.TextBox burstTimeTF;
        private System.Windows.Forms.TextBox arrivalTimeTF;
        private System.Windows.Forms.TextBox processTF;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.DataGridView processGrid;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox bursttime_textBox1;
        private System.Windows.Forms.TextBox Process_textBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox quantum_TextBox;
        private System.Windows.Forms.TextBox bursttime_textBox;
        private System.Windows.Forms.DataGridView RR_dataGridView;
        private System.Windows.Forms.Label Error_label;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button setquantum;
        private System.Windows.Forms.Button Remove_all_fcfs;
        private System.Windows.Forms.Button RR_simulate;
        private System.Windows.Forms.TextBox arrivaltime_textbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Average_label;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox arrIval_SJF_textbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dataGridView_SJF;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox bursttime_SJF_textbox;
        private System.Windows.Forms.TextBox Process_SJF_textbox;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label averageTurnAroundTime;
        private System.Windows.Forms.Label averageWaitingTime;
    }
}
