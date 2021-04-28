using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Version1
{
    public partial class Form1 : Form
    {
        /*nonpreemptive priority global variables*/

        public struct PProcess

        {
            public int ProcessID;
            public int ProcessPriority;
            public double ProcessBurstTime;
            public double ProcessArrivalTime;
            public double ProcessStartingTime;
            public double ProcessTotalWaitingTime;

        }

        int enter2_count = 0; /* global variable to count no. of times insert button is pressed*/
        public int noOfProcesses = 0;/* global variable to set no. of processes after ok button is pressed*/
        PProcess[] processarray = new PProcess[20]; /*global array to hold all the processes being inserted by the user */
        int processarray2_count = 0;/*global variable to hold actual length of processarray2 (no. of processes+ idle processes)*/
        double TotalWaitingTime = 0; /*global variable to hold total waiting time for all the processes*/
        PProcess[] processarray2 = new PProcess[30]; /*global array to hold all the processes(including idle processes)*/
        DataTable DT_priorityNonPreemptive = new DataTable();

        /*end of  nonpreemptive pirority global variables*/
        DataTable dt = new DataTable();
        Dictionary<string, KeyValuePair<float, float>> processes = new Dictionary<string, KeyValuePair<float, float>>();
        float totalTime = 0;

        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(" Process ");
            dt.Columns.Add(" Arrival Time ");
            dt.Columns.Add(" Burst Time ");
            processGrid.DataSource = dt;
            premptiveRB.Visible = false;
            nonPremptiveRB.Visible = false;
            firstArrivalLabel.Visible = false;
            foreach (DataGridViewColumn column in processGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //roundrobin  datagrid
            RR_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // RR_dataGridView.RowHeadersVisible = false;
            dt_RR.Columns.Add("Process");
            dt_RR.Columns.Add("Arival Time");
            dt_RR.Columns.Add("Burst Time");
            RR_dataGridView.DataSource = dt_RR;

            //SJF NP  datagrid
            dataGridView_SJF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // RR_dataGridView.RowHeadersVisible = false;
            DT_RR_SJF.Columns.Add("Process");
            DT_RR_SJF.Columns.Add("Arival Time");
            DT_RR_SJF.Columns.Add("Burst Time");
            dataGridView_SJF.DataSource = DT_RR_SJF;

            //priority(P)  datagrid
            dataGridView_pp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            DT_p.Columns.Add("Process");
            DT_p.Columns.Add("Burst");
            DT_p.Columns.Add("Arrive");
            DT_p.Columns.Add("Priority");
            dataGridView_pp.DataSource = DT_p;
            /*priority(nonpreemptive) datagrid*/
            dataGridView_nppriority.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            DT_priorityNonPreemptive.Columns.Add("Process ID");
            DT_priorityNonPreemptive.Columns.Add("Arrival Time");
            DT_priorityNonPreemptive.Columns.Add("Burst Time");
            DT_priorityNonPreemptive.Columns.Add("Priority");
            dataGridView_nppriority.DataSource = DT_priorityNonPreemptive;
            /*end of priority(nonpreemptive) datagrid*/
            /* nonpreemptive priority initilization**/
            gantChartLabel_nppriority.Hide();
            avgLabel_nppriority.Hide();
            avgTxt_nppriority.Hide();
            insertButton_nppriority.Enabled = false;
            drawGantChartButton_nppriority.Enabled = false;
            resetButton_nppriority.Enabled = false;
            dataGridView_nppriority.AllowUserToAddRows = false;
            /*end of nonpreemptive priority initilization*/

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {

                SJFTabPage.BackColor = System.Drawing.ColorTranslator.FromHtml("#84a9ac");
                ganttChart.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#84a9ac");
                insert.BackColor = System.Drawing.ColorTranslator.FromHtml("#3b6978");
                drawButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#3b6978");

                processGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                processGrid.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#84a9ac");
                processTF.BackColor = System.Drawing.ColorTranslator.FromHtml("#e4e3e3");
                arrivalTimeTF.BackColor = System.Drawing.ColorTranslator.FromHtml("#e4e3e3");
                burstTimeTF.BackColor = System.Drawing.ColorTranslator.FromHtml("#e4e3e3");
                title.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1E1F26");
                subtitle1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1E1F26");
                subtitle2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1E1F26");
                subtitle3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1E1F26");

            }
        }

        private void insert_Click_1(object sender, EventArgs e)
        {
            string processName, arrivalTime, burstTime;
            processName = processTF.Text;
            arrivalTime = arrivalTimeTF.Text;
            burstTime = burstTimeTF.Text;
            if (processName != "" && arrivalTime != "" && burstTime != "")
            {
                var process = new KeyValuePair<float, float>(float.Parse(arrivalTime), float.Parse(burstTime));
                processes[processName] = process;
                totalTime += float.Parse(burstTime);
            }


            if (processName != "" && arrivalTime != "" && burstTime != "")
            {
                dt.Rows.Add(processName, arrivalTime, burstTime);
                processTF.Text = "";
                arrivalTimeTF.Text = "";
                burstTimeTF.Text = "";
            }
        }

        private void drawButton_Click_1(object sender, EventArgs e)
        {
            //consol.Text = "";
            var ganttChartData = new List<KeyValuePair<string, float>>();
            float firstArrival = 1000.0f;
            foreach (KeyValuePair<string, KeyValuePair<float, float>> process in processes)
            {
                if (process.Value.Key < firstArrival)
                    firstArrival = process.Value.Key;
            }
            float totalTimeWithIdelTime = totalTime;
            for (float i = firstArrival; i < totalTimeWithIdelTime + firstArrival; i = (float)Math.Round(i + 0.1f, 2))
            {
                var arrivedProcesses = new Dictionary<string, KeyValuePair<float, float>>();
                foreach (KeyValuePair<string, KeyValuePair<float, float>> process in processes)
                {
                    if (process.Value.Key <= i && process.Value.Value > 0)
                    {
                        // Process arrived and not completed
                        arrivedProcesses[process.Key] = process.Value;
                    }
                }// Arrived Processes

                if (arrivedProcesses.Count > 0)
                {
                    string minimumRemainingTimeProcess = arrivedProcesses.First().Key;
                    foreach (KeyValuePair<string, KeyValuePair<float, float>> process in arrivedProcesses)
                    {
                        if (process.Value.Value < arrivedProcesses[minimumRemainingTimeProcess].Value)
                        {
                            minimumRemainingTimeProcess = process.Key;
                        }
                    } // Minimum time process
                    processes[minimumRemainingTimeProcess] = new KeyValuePair<float, float>(processes[minimumRemainingTimeProcess].Key, (float)Math.Round(processes[minimumRemainingTimeProcess].Value - 0.1f, 2));
                    if (ganttChartData.Count() == 0)
                    {
                        var v = new KeyValuePair<string, float>(minimumRemainingTimeProcess, 0.1f);
                        ganttChartData.Add(v);
                    }
                    else
                    {
                        var lastElement = ganttChartData.Last();
                        if (lastElement.Key == minimumRemainingTimeProcess)
                        {
                            lastElement = new KeyValuePair<string, float>(lastElement.Key, (float)Math.Round(lastElement.Value + 0.1f, 2));
                            ganttChartData.RemoveAt(ganttChartData.Count - 1);
                            ganttChartData.Add(lastElement);
                        }
                        else
                        {
                            var v = new KeyValuePair<string, float>(minimumRemainingTimeProcess, 0.1f);
                            ganttChartData.Add(v);
                        }
                    }
                    //           consol.Text += minimumRemainingTimeProcess + " ";
                }
                else
                {
                    var lastElement = ganttChartData.Last();
                    if (lastElement.Key == "Idle")
                    {
                        lastElement = new KeyValuePair<string, float>(lastElement.Key, (float)Math.Round(lastElement.Value + 0.1f, 2));
                        ganttChartData.RemoveAt(ganttChartData.Count - 1);
                        ganttChartData.Add(lastElement);
                    }
                    else
                    {
                        var v = new KeyValuePair<string, float>("Idle", 0.1f);
                        ganttChartData.Add(v);
                    }
                    totalTimeWithIdelTime = (float)Math.Round(totalTimeWithIdelTime + 0.1f, 2);
                }


            }
            //consol.Text += '\n';
            foreach (KeyValuePair<string, float> cell in ganttChartData)
            {
                //     consol.Text += cell.Key + " " + cell.Value + " ";
            }
            if (ganttChartData.Count == 0)
                return;
            ganttChart.Visible = true;
            averageTurnAroundTime.Visible = true;
            averageWaitingTime.Visible = true;
            firstArrivalLabel.Visible = true;
            firstArrivalLabel.Text = firstArrival.ToString();
            DataTable gc = new DataTable();
            ganttChart.DataSource = gc;
            float totalWidth = ganttChart.Width;
            float unitWidth = (float)Math.Round(totalWidth / totalTimeWithIdelTime, 2);
            gc.Rows.Add();

            float accumulator = firstArrival;
            for (int i = 0; i < ganttChartData.Count; i++)
            {
                accumulator += ganttChartData[i].Value;
                gc.Columns.Add((accumulator).ToString());
                ganttChart.Columns[i].Width = (int)(unitWidth * (float)Math.Round((ganttChartData[i].Value), 2));
                gc.Rows[0].SetField((accumulator).ToString(), ganttChartData[i].Key);
            }
            foreach (DataGridViewColumn column in ganttChart.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Calculating average turn around time
            float acc = 0;
            float averageTAT = 0, averageWT = 0;
            foreach (KeyValuePair<string, KeyValuePair<float, float>> process in processes)
            {
                string processName = process.Key;
                foreach (KeyValuePair<string, float> cell in ganttChartData)
                {

                    acc += cell.Value;
                    if (cell.Key == processName)
                    {
                        averageTAT += acc;
                        acc = 0;
                    }
                }
                acc = 0;
            }
            float totalArrivalTime = 0;
            foreach (KeyValuePair<string, KeyValuePair<float, float>> process in processes)
            {
                totalArrivalTime += process.Value.Key;
            }
            averageTAT = (float)Math.Round(averageTAT - totalArrivalTime + firstArrival * (processes.Count), 2);
            averageWT = (float)Math.Round(averageTAT - totalTime, 2);
            averageTAT = averageTAT / processes.Count;
            averageWT = (averageWT / processes.Count);
            averageTurnAroundTime.Text += averageTAT.ToString();
            averageWaitingTime.Text += averageWT.ToString();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }



        #region FCFS Code mode
        int flag = 0;
        List<float> finish_list = new List<float>();
        float item = 0;
        int n_fcfs;                           //number of processe
        List<float> service_list = new List<float>();
        List<Process> process_fcfs = new List<Process>();
        int counter_fcfs = 0;
        float time_fcfs = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nofprocesses.Text))
                MessageBox.Show("Please! Insert data first.", "Error");

            else
            {
                n_fcfs = int.Parse(nofprocesses.Text);
                MessageBox.Show("ok!number of processes inserted");
                flowLayoutPanel2_fcfs.Controls.Clear();
                flowLayoutPanel3_fcfs_nums.Controls.Clear();
                button2.Enabled = true;
                counter_fcfs = 0;
                time_fcfs = 0;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Process p_fcfs = new Process();
            p_fcfs.Pid = counter_fcfs + 1;
            p_fcfs.burst_time = float.Parse(burstText_fcfs.Text);          //convert text string to integar
            p_fcfs.arrival_time = float.Parse(arrivalText_fcfs.Text);     //convert text string to integar
            process_fcfs.Add(p_fcfs);                                  // store process in queue
            counter_fcfs++;
            string ss_fcfs = "Inserted " + (counter_fcfs.ToString()) + " from " + (n_fcfs.ToString());
            MessageBox.Show(ss_fcfs);
            if (n_fcfs == counter_fcfs)
            {
                button2.Enabled = false;
                process_fcfs = process_fcfs.OrderBy(i => i.arrival_time).ToList();
                calculateWaitingTime_fcfs();
            }
        }
        // cal.average waiting time
        private void calculateWaitingTime_fcfs()
        {

            process_fcfs[0].waiting_time = 0;
            float start = process_fcfs[0].arrival_time;
            float finish = start + process_fcfs[0].burst_time;
            service_list.Add(start);
            service_list.Add(finish);
            finish_list.Add(finish);
            for (int i = 1; i < n_fcfs; i++)
            {
                if (process_fcfs[i].arrival_time > finish)
                {
                    start = process_fcfs[i].arrival_time;
                    finish = process_fcfs[i].arrival_time + process_fcfs[i].burst_time;
                    service_list.Add(start);
                    service_list.Add(finish);
                    finish_list.Add(finish);
                    process_fcfs[i].waiting_time = start - process_fcfs[i].arrival_time;
                    flag += 1;

                }
                else
                {
                    process_fcfs[i].waiting_time = finish - process_fcfs[i].arrival_time;

                    finish = finish + process_fcfs[i].burst_time;
                    service_list.Add(finish);
                    finish_list.Add(finish);
                }
                time_fcfs += process_fcfs[i].waiting_time;
            }

            waitingText_fcfs.Text = (time_fcfs / n_fcfs).ToString();
            gantt_chart_fcfs();
        }
        // function to draw gantt chart of fcfs
        private void gantt_chart_fcfs()
        {

            if (process_fcfs[0].arrival_time > 0)
            {
                Label idle_time = new Label();
                idle_time.Size = new System.Drawing.Size(30, 26);  // if arrival time is larger than 0
                TextBox idle_processing = new TextBox();
                idle_processing.Size = new System.Drawing.Size(37, 29);
                idle_processing.Enabled = true;
                //idle_processing.Font = new Font("Arial", 12, FontStyle.Regular);
                idle_time.Font = new Font("Arial", 8, FontStyle.Regular);
                idle_processing.Text = "idle";
                idle_time.Text = "0";
                flowLayoutPanel3_fcfs_nums.Controls.Add(idle_time);
                flowLayoutPanel2_fcfs.Controls.Add(idle_processing);
            }

            float first_time = 0;
            first_time = service_list[0];
            Label firstpro = new Label();
            firstpro.Text = first_time.ToString();
            firstpro.Size = new System.Drawing.Size(35, 26);
            firstpro.Font = new Font("Arial", 8, FontStyle.Regular);
            flowLayoutPanel3_fcfs_nums.Controls.Add(firstpro);

            TextBox mm = new TextBox();
            mm.Enabled = true;
            mm.Size = new System.Drawing.Size(35, 29);
            // mm.Font = new Font("Arial", 10, FontStyle.Bold);
            string ss = "P" + process_fcfs[0].Pid.ToString();
            mm.Text = ss;
            mm.ReadOnly = true;
            flowLayoutPanel2_fcfs.Controls.Add(mm);
            for (int i = 1; i < n_fcfs; i++)
            {

                if (flag > 0 && ((process_fcfs[i].arrival_time) - (finish_list[i - 1])) > 0)
                {
                    float idlee_time;
                    idlee_time = finish_list[i - 1];
                    Label idle_time = new Label();
                    idle_time.Text = idlee_time.ToString();
                    idle_time.Size = new System.Drawing.Size(35, 26);
                    TextBox idle_processing = new TextBox();
                    idle_processing.Size = new System.Drawing.Size(37, 29);
                    idle_processing.Enabled = true;
                    // idle_processing.Font = new Font("Arial", 12, FontStyle.Regular);
                    idle_time.Font = new Font("Arial", 8, FontStyle.Regular);
                    idle_processing.Text = "idle";

                    flowLayoutPanel3_fcfs_nums.Controls.Add(idle_time);
                    flowLayoutPanel2_fcfs.Controls.Add(idle_processing);
                    flag--;


                    float next_time;
                    next_time = process_fcfs[i].arrival_time;
                    Label next_time1 = new Label();
                    next_time1.Text = next_time.ToString();
                    next_time1.Size = new System.Drawing.Size(35, 26);
                    next_time1.Font = new Font("Arial", 8, FontStyle.Regular);
                    flowLayoutPanel3_fcfs_nums.Controls.Add(next_time1);

                    TextBox zz = new TextBox();
                    zz.Enabled = true;
                    zz.Size = new System.Drawing.Size(35, 29);
                    //zz.Font = new Font("Arial", 10, FontStyle.Regular);
                    string zzz = "P" + process_fcfs[i].Pid.ToString();
                    zz.Text = zzz;
                    zz.ReadOnly = true;
                    flowLayoutPanel2_fcfs.Controls.Add(zz);

                }
                else
                {
                    float next_time;
                    next_time = finish_list[i - 1];
                    Label next_time1 = new Label();
                    next_time1.Text = next_time.ToString();
                    next_time1.Size = new System.Drawing.Size(35, 26);
                    next_time1.Font = new Font("Arial", 8, FontStyle.Regular);
                    flowLayoutPanel3_fcfs_nums.Controls.Add(next_time1);

                    TextBox zz = new TextBox();
                    zz.Enabled = true;
                    zz.Size = new System.Drawing.Size(35, 29);
                    //zz.Font = new Font("Arial", 10, FontStyle.Bold);
                    string zzz = "P" + process_fcfs[i].Pid.ToString();
                    zz.Text = zzz;
                    zz.ReadOnly = true;
                    flowLayoutPanel2_fcfs.Controls.Add(zz);

                }

            }

            if (finish_list.Count > 0)
            {
                item = finish_list[finish_list.Count - 1];
            }
            //last time label
            Label last_time21 = new Label();
            last_time21.Size = new System.Drawing.Size(35, 29);
            last_time21.Font = new Font("Arial", 8, FontStyle.Regular);
            last_time21.Text = item.ToString();
            flowLayoutPanel3_fcfs_nums.Controls.Add(last_time21);
        }
        //remove all processes
        private void Remove_all_fcfs_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to Remove all Process?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                flowLayoutPanel2_fcfs.Controls.Clear();
                flowLayoutPanel3_fcfs_nums.Controls.Clear();
                process_fcfs.Clear();
                service_list.Clear();
                finish_list.Clear();                                                                                                                             // dh el satr el wa7eed eli gded f function deh
                waitingText_fcfs.Text = nofprocesses.Text = burstText_fcfs.Text = arrivalText_fcfs.Text = " ";
            }
        }
        class Process
        {
            public int Pid;  //process id
            public float burst_time;
            public float waiting_time = 0;
            public float last_active = 0;
            public float arrival_time;
        }




        #endregion
        /************************** Roundrobin *************************/
        DataTable dt_RR = new DataTable(); //roundrobin table 
        int burstTime;
        string processName;
        /********   global variables *********/


        /************************** SJF NON Premptive *************************/
        DataTable DT_RR_SJF = new DataTable(); //roundrobin table 
        double Burst_time_SJF;
        double Arrival_Time_SJF;
        string Process_Name_SJF;
        /********   global variables *********/


        int quantum = 0;
        double total_waiting = 0;
        bool first = true;
        int arrivalTime = 0;
        int running_time = 0;


        List<process> list_process = new List<process>();



        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void setquantum_Click(object sender, EventArgs e)
        { //set quantum
            try
            {
                quantum = Convert.ToInt32(Convert.ToDouble(quantum_TextBox.Text) * 10);
                if (quantum < 1 || quantum > 100)
                {
                    Error_label.Text = "Quantum time generally form 10 to 100 ms";
                    quantum = 0;
                }
            }
            catch (Exception)
            {
                Error_label.Text = "Invalid Quantum number";
            }

        }

        Label Add_label_process(int i)
        {
            Label l = new Label();
            l.Name = "label" + i.ToString();
            l.Text = list_process[i].Process_name;

            l.ForeColor = Color.Black;
            l.BackColor = Color.WhiteSmoke;
            l.Width = 76;
            l.Height = 48;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Margin = new Padding(5);
            return l;
        }

        Label Add_label_process_SJF(string processName)
        {
            Label l = new Label();

            l.Text = processName;

            l.ForeColor = Color.Black;
            l.BackColor = Color.WhiteSmoke;
            l.Width = 76;
            l.Height = 48;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Margin = new Padding(5);
            return l;
        }



        Label Add_label_time(int i)
        {
            Label l = new Label();

            l.Name = "label" + i.ToString();
            int x = i;
            l.Text = "" + i.ToString();
            l.ForeColor = Color.Black;
            l.BackColor = Color.White;
            l.Width = 40;
            l.Height = 28;
            l.TextAlign = ContentAlignment.MiddleLeft;

            if (first)
            {


                l.Margin = new Padding(50, 2, 0, 5);
                first = false;
            }
            else
            {

                l.Margin = new Padding(45, 2, 0, 5);
            }
            return l;
        }
        Label Add_label_time_rr(double i)
        {
            Label l = new Label();

            l.Name = "label" + i.ToString();
            double x = i;
            l.Text = "" + i.ToString();
            l.ForeColor = Color.Black;
            l.BackColor = Color.White;
            l.Width = 40;
            l.Height = 28;
            l.TextAlign = ContentAlignment.MiddleLeft;

            if (first)
            {


                l.Margin = new Padding(50, 2, 0, 5);
                first = false;
            }
            else
            {

                l.Margin = new Padding(45, 2, 0, 5);
            }
            return l;
        }


        Label Add_label_time_in_double(double i)
        {
            Label l = new Label();

            double x = i;
            l.Name = "label" + i.ToString();
            l.Text = "" + x.ToString();
            l.ForeColor = Color.Black;
            l.BackColor = Color.White;
            l.Width = 50;
            l.Height = 28;
            l.TextAlign = ContentAlignment.MiddleLeft;
            l.Margin = new Padding(35, 2, 0, 5);


            return l;
        }
        double waitingTime = 0;
        public void set_waiting()
        {
            double totalBurst = 0;
            double totalArrival = 0;
            for (int i = 0; i < list_process.Count; i++)
            {
                totalBurst += list_process[i].get_burst();
                totalArrival += list_process[i].arrival_time;
            }
            waitingTime -= (totalBurst + totalArrival);
            waitingTime /= list_process.Count;
            Average_label.Text = "Average waiting time :" + total_waiting.ToString();
        }


        private void RR_simulate_Click(object sender, EventArgs e)
        {
            List<process> SortedList = list_process.OrderBy(o => o.arrival_time).ToList();
            bool[] served = new bool[10];
            for (int i = 0; i < 10; ++i) served[i] = false;
            bool remain = false;
            label9.Text = "0";
            if (quantum < 1 || quantum > 100)
            {
                Error_label.Text = "Quantum time generally form 1 to 100 ms";
                quantum = 0;
                return;
            }
            Error_label.Text = "";
            //simulate 

            bool k = true;
            while (k)
            {
                for (int i = 0; i < SortedList.Count; i++)
                {  
                    if (SortedList[i].arrival_time > running_time)
                    {
                        //idle process
                        //adjust running time 
                        running_time = SortedList[i].arrival_time;

                        //print idle
                        Label l = Add_label_process_SJF("Idle");
                        flowLayoutPanel2.Controls.Add(l);

                        Label l1 = Add_label_time_rr(running_time/10.0);
                        flowLayoutPanel3.Controls.Add(l1);
                        i--;
                        continue;
                    }
                    else
                    {
                        while ((SortedList[i].get_burst() != 0))
                        {
                            if ((i == SortedList.Count - 1) && ((SortedList[i].get_burst() == 0)||(remain))&&(served[i]==true))
                            {
                                served[i] = false;
                                break;
                            }
                            if ((i != SortedList.Count - 1) && (SortedList[i + 1].arrival_time <= running_time) && (SortedList[i + 1].get_burst() > 0) && (served[i] == true))
                            {
                                served[i] = false;
                                break;
                            }
                            if (SortedList[i].get_burst() > quantum)
                            {
                                //first time
                                running_time += quantum;
                                int x = SortedList[i].get_burst();
                                x -= quantum;
                                SortedList[i].set_burst(x);

                                Label l = Add_label_process_SJF(SortedList[i].Process_name);
                                flowLayoutPanel2.Controls.Add(l);

                                Label l1 = Add_label_time_rr(running_time/10.0);
                                flowLayoutPanel3.Controls.Add(l1);
                                served[i] = true;
                            }
                            else
                            {
                                if (SortedList[i].get_burst() > 0)
                                {
                                    Label l = Add_label_process_SJF(SortedList[i].Process_name);
                                    flowLayoutPanel2.Controls.Add(l);
                                    running_time += SortedList[i].get_burst();

                                    Label l1 = Add_label_time_rr(running_time/10.0);
                                    flowLayoutPanel3.Controls.Add(l1);
                                }
                                SortedList[i].set_burst(0);
                                served[i] = true;
                            }
                            if (i == SortedList.Count - 1){ 
                            for (int rem = 0; rem < SortedList.Count; rem++)
                            {
                                if ((SortedList[rem].get_burst() != 0))
                                {
                                    remain = true;
                                }
                            }
                            }
                        }
                    }

                }
                // check finish or not
                k = false;
                for (int i = 0; i < SortedList.Count; i++)
                {
                    if ((SortedList[i].get_burst() != 0))
                    {
                        k = true;
                    }
                }
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // insert button 

                burstTime = Convert.ToInt32(Convert.ToDouble(bursttime_textBox.Text)*10);
                arrivalTime = Convert.ToInt32(Convert.ToDouble(arrivaltime_textbox.Text) * 10);

                process p = new process(Process_textBox.Text, burstTime, arrivalTime);
                list_process.Add(p);



                if (processName != "" && burstTime != 0)
                {
                    dt_RR.Rows.Add(Process_textBox.Text, arrivalTime/10.0, burstTime/10.0);
                }
                else
                {
                    Error_label.Text = "Invalid P0 or Burst time ";
                }

            }
            catch (Exception)
            {
                Error_label.Text = "Invalid P0 or Burst time ";
            }


        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }




        List<KeyValuePair<double, KeyValuePair<string, double>>> my_process = new List<KeyValuePair<double, KeyValuePair<string, double>>>();

        double Full_Time = 0;
        private void button8_Click(object sender, EventArgs e)
        {

            try
            {

                Process_Name_SJF = Process_SJF_textbox.Text;
                Burst_time_SJF = Convert.ToDouble(bursttime_SJF_textbox.Text);
                Arrival_Time_SJF = Convert.ToDouble(arrIval_SJF_textbox.Text);
                KeyValuePair<string, double> Pairrr = new KeyValuePair<string, double>(Process_Name_SJF, Arrival_Time_SJF);
                KeyValuePair<double, KeyValuePair<string, double>> Process_Info_SJF = new KeyValuePair<double, KeyValuePair<string, double>>(Burst_time_SJF, Pairrr);
                my_process.Add(Process_Info_SJF);





                if (Process_Name_SJF != "" && Burst_time_SJF != 0)
                {
                    DT_RR_SJF.Rows.Add(Process_Name_SJF, Arrival_Time_SJF, Burst_time_SJF);

                    Full_Time += Burst_time_SJF;
                }
                else
                {
                    Error_label.Text = "Invalid P0 or Burst time ";
                }

            }
            catch (Exception)
            {
                Error_label.Text = "Invalid P0 or Burst time ";
            }






        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }
        //MM
        private void button6_Click(object sender, EventArgs e)//simulate_SJF_NP
        {
            var RemovedProcess = new List<string>();

            my_process = my_process.OrderBy(x => x.Key).ToList();

            label20.Text = "0";
            double waiting_time_SJF = 0;

            bool Idle_Flag = true;
            bool Idle_Flag_One_Time = true;
            bool Idle_is_done = true;
            double Idle_Process_start_time = 0;

            for (double i = 0; (RemovedProcess.Count != my_process.Count); i += 0.1)
            {

                Idle_Flag = true;

                foreach (KeyValuePair<double, KeyValuePair<string, double>> Process in my_process)
                {
                    double Burst_time = Process.Key;
                    string Process_Name = Process.Value.Key;
                    double Arrival_time = Process.Value.Value;
                    bool is_removed = RemovedProcess.Contains(Process_Name);

                    if ((Math.Round(Arrival_time, 1) <= Math.Round(i, 1)) && !(is_removed))
                    {
                        waiting_time_SJF += i - Arrival_time;

                        if (Idle_Flag == true && Idle_is_done == false)
                        {

                            Label LA = Add_label_time_in_double(Math.Round(i, 1)); //End time of Idle process
                            flowLayoutPanel4.Controls.Add(LA);
                            Idle_is_done = true;

                        }
                        i += Burst_time - 0.1;
                        Label L = Add_label_process_SJF(Process_Name);
                        flowLayoutPanel5.Controls.Add(L);

                        Label L2 = Add_label_time_in_double(Math.Round((i + 0.1), 1)); //End time of Active process
                        flowLayoutPanel4.Controls.Add(L2);
                        RemovedProcess.Add(Process_Name);
                        Idle_Flag = false;
                        Idle_Flag_One_Time = true;
                        break;
                    }

                }
                if (Idle_Flag == true && Idle_Flag_One_Time == true)
                {
                    Label L3 = Add_label_process_SJF("Idle");
                    flowLayoutPanel5.Controls.Add(L3);

                    Idle_Flag_One_Time = false;
                    Idle_is_done = false;

                    Idle_Process_start_time = i;


                }


            }
            waiting_time_SJF = Math.Abs(waiting_time_SJF / (my_process.Count));
            label10.Text = "Waiting Time:  " + Math.Round(waiting_time_SJF, 2).ToString();

        }

        private void Process_SJF_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void RR_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void averageTurnAroundTime_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }






        /********************************* Priority preemptive ****************************************/

        #region Priority Preemptive
        /************************** proirity Premptive *************************/
        DataTable DT_p = new DataTable(); //roundrobin table 
        double Burst_time_pp;
        double Arrival_Time_pp;
        double proirity_pp;
        string Process_Name_pp;
        Label Add_label_process_pp(string processName)
        {
            Label l = new Label();

            l.Text = processName;

            l.ForeColor = Color.Black;
            l.BackColor = Color.WhiteSmoke;
            l.Width = 76;
            l.Height = 48;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Margin = new Padding(5);
            return l;
        }
        Label Add_label_time_pp(double i)
        {
            Label l = new Label();

            l.Name = "label" + i.ToString();
            double x = i;
            l.Text = "" + i.ToString();
            l.ForeColor = Color.Black;
            l.BackColor = Color.White;
            l.Width = 40;
            l.Height = 28;
            l.TextAlign = ContentAlignment.MiddleLeft;

            if (first)
            {


                l.Margin = new Padding(0, 2, 0, 5);
                first = false;
            }
            else
            {

                l.Margin = new Padding(35, 2, 0, 5);
            }
            return l;
        }

        List<KeyValuePair<KeyValuePair<string, double>, KeyValuePair<double, double>>> priority_p_process = new List<KeyValuePair<KeyValuePair<string, double>, KeyValuePair<double, double>>>();
        double total_time_pp = 0;

        private void priority_pp_Click(object sender, EventArgs e)
        {

            try
            {
                // <name, burst, arrival, priority> 
                Process_Name_pp = process_pp.Text;
                Burst_time_pp = Convert.ToDouble(burst_pp.Text);
                Arrival_Time_pp = Convert.ToDouble(arrival_pp.Text);
                proirity_pp = Convert.ToDouble(priority_p.Text);

                KeyValuePair<string, double> P1 = new KeyValuePair<string, double>(Process_Name_pp, Burst_time_pp);
                KeyValuePair<double, double> P2 = new KeyValuePair<double, double>(Arrival_Time_pp, proirity_pp);
                KeyValuePair<KeyValuePair<string, double>, KeyValuePair<double, double>> Process_Info_pp = new KeyValuePair<KeyValuePair<string, double>, KeyValuePair<double, double>>(P1, P2);
                priority_p_process.Add(Process_Info_pp);

                if (Process_Name_pp != "" && Burst_time_pp != 0)
                {
                    DT_p.Rows.Add(Process_Name_pp, Burst_time_pp, Arrival_Time_pp, proirity_pp);

                    total_time_pp += Burst_time_pp;
                }
                else
                {
                    Error_label.Text = "Invalid P0 or Burst time ";
                }

            }
            catch (Exception)
            {
                Error_label.Text = "Invalid P0 or Burst time ";
            }

        }

        // <name, burst, arrival, priority> 
        private void simulate_pp(object sender, EventArgs e)
        {
            string lastprocess = "0";
            int size = priority_p_process.Count();
            double waiting = 0;
            bool idle = false;
            priority_p_process = priority_p_process.OrderBy(x => x.Value.Value).ToList();
            for (double i = 0; i < total_time_pp; i += 0.1)
            {

                for (int j = 0; j < size; j++)
                {
                    string name = priority_p_process[j].Key.Key;
                    double burst = priority_p_process[j].Key.Value;

                    double arrival = priority_p_process[j].Value.Key;
                    double priority = priority_p_process[j].Value.Value;

                    if ((Math.Round(arrival, 1) <= Math.Round(i, 1)) && (burst > 0.05))
                    {
                        idle = false;
                        //to not repeate the proces name each time
                        if (name != lastprocess)
                        {
                            Label L = Add_label_process_pp(name);
                            flowLayoutPanel7.Controls.Add(L);
                            Label L2 = Add_label_time_pp(Math.Round(i, 1));
                            flowLayoutPanel6.Controls.Add(L2);
                        }
                        lastprocess = name;
                        burst = burst - 0.1;
                        // calculate waiting time
                        for (int l = 0; l < size; l++)
                        {
                            double burst2 = priority_p_process[l].Key.Value;
                            double arrival2 = priority_p_process[l].Value.Key;
                            string name2 = priority_p_process[l].Key.Key;
                            if ((burst2 > 0.05) && (Math.Round(arrival2, 1) <= Math.Round(i, 1)) && (name2 != name))
                            {
                                waiting += 0.1;
                            }
                        }
                        //re assgin burst to new one
                        KeyValuePair<string, double> k = new KeyValuePair<string, double>(name, burst);
                        KeyValuePair<double, double> v = new KeyValuePair<double, double>(arrival, priority);
                        priority_p_process[j] = new KeyValuePair<KeyValuePair<string, double>, KeyValuePair<double, double>>(k, v);


                        if ((i > total_time_pp - 0.15) && (burst < 0.01))
                        {
                            Label L2 = Add_label_time_pp(Math.Round((i + 0.1), 1));
                            flowLayoutPanel6.Controls.Add(L2);
                        }
                        break;
                    }

                    // if there is no available process yet
                    if (j == (size - 1) && (arrival > i) && (idle == false))
                    {
                        idle = true;
                        Label L = Add_label_process_pp("Idle");
                        flowLayoutPanel7.Controls.Add(L);
                        Label L2 = Add_label_time_pp(Math.Round(i, 1));
                        flowLayoutPanel6.Controls.Add(L2);

                    }
                }
                if (idle)
                {
                    total_time_pp += 0.1;

                }
            }
            waiting /= (size);
            label22.Text = "Average Waiting Time:  " + waiting.ToString();
        }

        #endregion

        /********************************* Priority Nonpreemptive ****************************************/
        #region Priority Nonpreemptive

        private void insertButton_nppriority_Click(object sender, EventArgs e)
        {
            add_process_nppriority();

            if (enter2_count == noOfProcesses)
            {
                Init();

            }
        }
        private void add_process_nppriority()
        {
            processarray[enter2_count].ProcessID = Convert.ToInt32(processIDTxt_nppriority.Text);
            processarray[enter2_count].ProcessBurstTime = Convert.ToDouble(burstTxt_nppriority.Text);
            processarray[enter2_count].ProcessPriority = Convert.ToInt32(PriorityTxt_nppriority.Text);
            processarray[enter2_count].ProcessArrivalTime = Convert.ToDouble(arrivalTxt_nppriority.Text);

            enter2_count++;
            if (enter2_count == 1)
            {
                resetButton_nppriority.Enabled = true;
            }


            DT_priorityNonPreemptive.Rows.Add(Convert.ToInt32(processIDTxt_nppriority.Text),
                     Convert.ToDouble(arrivalTxt_nppriority.Text),
                       Convert.ToDouble(burstTxt_nppriority.Text),
                      Convert.ToInt32(PriorityTxt_nppriority.Text));

            processIDTxt_nppriority.Text = "";
            burstTxt_nppriority.Text = "";
            PriorityTxt_nppriority.Text = "";
            arrivalTxt_nppriority.Text = "";

        }
        private void Init()
        {
            insertButton_nppriority.Enabled = false;
            /* sorting all processes with bubble sort algorthim based on their priority*/
            Bubble_sort_nppriority();
            /*calculate starting time for each process & handling any idle process if exist*/
            int p;
            int count = 0;
            List<int> finished_processes_index = new List<int>();

            int idle_flag_nppriority = 1;
            int firstTime_flag = 1;
            int finished_process_flag = 0;
            int priority_flag = 0;

            /*outer for loop is time loop*/
            for (double l = 0; l < 90; l += 0.1)
            {

                if (finished_processes_index.Count == noOfProcesses)
                {
                    break;
                }

                /*check if any process has arrived before or at this time "l"*/
                for (p = 0; p < noOfProcesses; p++)
                {

                    /*check if processarray[p] has already set on processarray2 or not to handle if a process with higher 
                    arrival time is bigger than a lower priority process */
                    for (int w = 0; w < finished_processes_index.Count; w++)
                    {
                        finished_process_flag = 0;
                        if (p == finished_processes_index[w])
                        {
                            finished_process_flag = 1;
                            break;
                        }
                    }
                    if (finished_process_flag == 0)
                    {
                        if (processarray[p].ProcessArrivalTime <= l)
                        {
                            idle_flag_nppriority = 0;

                            if (firstTime_flag == 0)
                            {
                                firstTime_flag = 1;
                                processarray2[processarray2_count].ProcessBurstTime = l -
                                    processarray2[processarray2_count].ProcessStartingTime;
                                processarray2_count++;

                            }

                            for (int h = 0; h < noOfProcesses; h++)
                            {
                                if (h != p)
                                {
                                    if ((processarray[p].ProcessPriority == processarray[h].ProcessPriority) &&
                                        (processarray[p].ProcessArrivalTime == processarray[h].ProcessArrivalTime))
                                    {
                                        priority_flag = 1;
                                        break;

                                    }
                                }
                            }
                            break;
                        }

                    }


                }
                if (idle_flag_nppriority == 1 && firstTime_flag == 1)
                {
                    firstTime_flag = 0;
                    processarray2[processarray2_count].ProcessStartingTime = l;
                    processarray2[processarray2_count].ProcessID = 90;

                }
                else if (idle_flag_nppriority == 0)
                {
                    idle_flag_nppriority = 1;

                    if (priority_flag == 1)
                    {
                        priority_flag = 0;
                        List<int> same_priority_processes_index = new List<int>();
                        double temp_l = l;
                        same_priority_processes_index.Add(p);
                        processarray[p].ProcessStartingTime = temp_l;
                        temp_l += 2;
                        for (int n = 0; n < noOfProcesses; n++)
                        {
                            if (n != p)
                            {
                                if ((processarray[p].ProcessPriority == processarray[n].ProcessPriority) &&
                                    (processarray[p].ProcessArrivalTime == processarray[n].ProcessArrivalTime))
                                {
                                    same_priority_processes_index.Add(n);
                                    processarray[n].ProcessStartingTime = temp_l;
                                    temp_l += 2;
                                }
                            }
                        }
                        PProcess temp2;

                        while (same_priority_processes_index.Count != 0)
                        {
                            for (int d = 0; d < same_priority_processes_index.Count; d++)
                            {
                                temp2 = processarray[same_priority_processes_index[d]];
                                temp2.ProcessStartingTime = l;
                                if (processarray[same_priority_processes_index[d]].ProcessBurstTime <= 2)
                                {
                                    temp2.ProcessBurstTime = processarray[same_priority_processes_index[d]].ProcessBurstTime;
                                    finished_processes_index.Add(same_priority_processes_index[d]);
                                    same_priority_processes_index.RemoveAt(d);
                                    count++;

                                }
                                else
                                {
                                    temp2.ProcessBurstTime = 2;
                                    processarray[same_priority_processes_index[d]].ProcessBurstTime -= 2;
                                }
                                processarray2[processarray2_count] = temp2;
                                l += processarray2[processarray2_count].ProcessBurstTime;
                                processarray2_count++;

                            }
                        }

                        l -= 0.1;


                    }
                    else
                    {

                        processarray[p].ProcessStartingTime = l;
                        processarray2[processarray2_count] = processarray[p];
                        l = l + processarray[p].ProcessBurstTime - 0.1;
                        count++;
                        processarray2_count++;
                        finished_processes_index.Add(p);


                    }



                }


            }
            drawGantChartButton_nppriority.Enabled = true;

        }

        private void Bubble_sort_nppriority()
        {
            int i;
            int j;
            PProcess temp;
            for (i = 0; i < noOfProcesses; i++)
            {

                for (j = 0; j < (noOfProcesses - 1); j++)
                {
                    /* swap adjacent elements if they are out of order */
                    if (processarray[j].ProcessPriority > processarray[j + 1].ProcessPriority)
                    {
                        temp = processarray[j];
                        processarray[j] = processarray[j + 1];
                        processarray[j + 1] = temp;
                    }

                }
            }
        }
        private void TotalWaitingTime_nppriority()
        {
            /* calculate waiting time for each process & totatl waiting time for all processes*/
            for (int y = 0; y < noOfProcesses; y++)
            {
                processarray[y].ProcessTotalWaitingTime = processarray[y].ProcessStartingTime - processarray[y].ProcessArrivalTime;
                TotalWaitingTime += processarray[y].ProcessTotalWaitingTime;
            }
        }

        /* function to draw gantt chart of priority non preemptive*/
        private void gantt_chart_priority()
        {
            double next_time = 0;
            /*int x_txt = 47;*/
            int q = 0;

            for (int i = 0; i < processarray2_count; i++)
            {
                TextBox zz = new TextBox();
                zz.Enabled = true;
                q = 30 * Convert.ToInt32(processarray2[i].ProcessBurstTime);
                zz.Size = new Size(q, 40);
                zz.Font = new Font("Arial", 16, FontStyle.Regular);
                string zzz;
                if (processarray2[i].ProcessID == 90)
                {
                    zzz = "Idle";
                }
                else
                {
                    zzz = "P" + processarray2[i].ProcessID.ToString();
                }
                zz.Text = zzz;
                zz.ReadOnly = true;

                flowLayoutPanel2_nppriority.Controls.Add(zz);

                next_time = processarray2[i].ProcessStartingTime;
                Label next_time1 = new Label();
                next_time1.Text = Math.Round(next_time, 1).ToString();
                next_time1.Font = new Font("Arial", 12, FontStyle.Regular);
                next_time1.Size = new Size(q, 34);

                flowLayoutPanel3_nppriority.Controls.Add(next_time1);


            }
            /* last time label */
            Label last_time21 = new Label();
            last_time21.Font = new Font("Arial", 12, FontStyle.Regular);
            last_time21.Text = Math.Round((processarray2[processarray2_count - 1].ProcessBurstTime +
                processarray2[processarray2_count - 1].ProcessStartingTime), 1).ToString();
            flowLayoutPanel3_nppriority.Controls.Add(last_time21);



        }




        private void resetButton_nppriority_Click(object sender, EventArgs e)
        {
            /*intiallize all global variables and arrays*/

            for (int i = 0; i < noOfProcesses; i++)
            {
                processarray = processarray.Where((source, index) => index != i).ToArray();

            }
            dataGridView_nppriority.AllowUserToAddRows = false;
            for (int i = 0; i < dataGridView_nppriority.RowCount; i++)
            {

                dataGridView_nppriority.Rows.RemoveAt(dataGridView_nppriority.Rows[i].Index);
                i--;


            }
            for (int k = 0; k < processarray2_count; k++)
            {
                processarray2 = processarray2.Where((source, index) => index != k).ToArray();


            }
            enter2_count = 0;
            noOfProcesses = 0;
            processarray2_count = 0;
            TotalWaitingTime = 0;
            flowLayoutPanel2_nppriority.Controls.Clear();
            flowLayoutPanel3_nppriority.Controls.Clear();
            gantChartLabel_nppriority.Hide();
            avgLabel_nppriority.Hide();
            avgTxt_nppriority.Hide();
            okButton_nppriority.Enabled = true;
            numericUpDown1_nppriority.Enabled = true;
            insertButton_nppriority.Enabled = false;

        }

        private void drawGantChartButton_nppriority_Click(object sender, EventArgs e)
        {
            avgLabel_nppriority.Show();
            avgTxt_nppriority.Show();
            TotalWaitingTime_nppriority();
            avgTxt_nppriority.Text = Math.Round((TotalWaitingTime / Convert.ToDouble(noOfProcesses)), 1).ToString("N");
            gantChartLabel_nppriority.Show();
            gantt_chart_priority();
            drawGantChartButton_nppriority.Enabled = false;
        }

        private void okButton_nppriority_Click(object sender, EventArgs e)
        {
            numericUpDown1_nppriority.Enabled = false;
            okButton_nppriority.Enabled = false;
            insertButton_nppriority.Enabled = true;
            noOfProcesses = Convert.ToInt32(numericUpDown1_nppriority.Value);
        }
        #endregion

        private void label31_Click(object sender, EventArgs e)
        {

        }
    }


    /********************************  Roundrobin classes  ***********************/
    class process
    {
        public string Process_name;
        int burst_Time;
        public double waiting_time;
        public int arrival_time;
        public bool printed;


        public process(string s, int burst, int arrival)
        {
            Process_name = s;
            burst_Time = burst;
            arrival_time = arrival;
            waiting_time = 0;
            printed = false;
        }
        public void set_burst(int i)
        {
            burst_Time = i;
        }
        public int get_burst()
        {
            return burst_Time;
        }
        public string get_name()
        {
            return Process_name;
        }

        public double get_waiting()
        {
            return waiting_time;
        }

        public void set_waiting(int i)
        {
            waiting_time = i;
        }
    };





    /*******************************************************************************/
}