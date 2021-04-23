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
        //priority non-preemptive
        int enter2_count = 0;
        public struct PProcess

        {
            public int ProcessNumber;
            public int ProcessBurstTime;
            public int ProcessPriority;
            public int ProcessArrivalTime;
            public int ProcessStartingTime;
            public int ProcessAverageWaitingTime;

        }
        public nonPreemptivePriorityProcess nonPreemptiveProcess = new nonPreemptivePriorityProcess();
        public List<nonPreemptivePriorityProcess> myListOfProcesses = new List<nonPreemptivePriorityProcess>();
        bool comparison(PProcess a, PProcess b)
        {
            return (a.ProcessPriority > b.ProcessPriority);
        }
        PProcess[] processarray = new PProcess[20];
        int TotalAverageWaiting = 0;
        DataTable DT_priorityNonPreemptive = new DataTable();

        /*end of pirority non-preemptive*/
        DataTable dt = new DataTable();
        Dictionary<string, KeyValuePair<float, float>> processes = new Dictionary<string, KeyValuePair<float, float>>();
        int totalTime = 0;

        public Form1()
        {
            InitializeComponent();
            //priority non-preemptive
            PGanttLabel.Hide();
            PavgLabel.Hide();
            PriorityAvgTxt.Hide();
            //end
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Process");
            dt.Columns.Add("Arrival Time");
            dt.Columns.Add("Burst Time");
            processGrid.DataSource = dt;

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
            dataGridView_pp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            DT_priorityNonPreemptive.Columns.Add("Process ID");
            DT_priorityNonPreemptive.Columns.Add("Arrival Time");
            DT_priorityNonPreemptive.Columns.Add("Burst Time");
            DT_priorityNonPreemptive.Columns.Add("Priority");
            dataGridView1.DataSource = DT_priorityNonPreemptive;
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
                totalTime += Int32.Parse(burstTime);
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

            for (float i = firstArrival; i < totalTime + firstArrival; i = (float)Math.Round(i + 0.1f, 2))
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
                    //idel
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
            DataTable gc = new DataTable();
            ganttChart.DataSource = gc;
            float totalWidth = ganttChart.Width;
            float unitWidth = (float)Math.Round(totalWidth / totalTime, 2);
            gc.Rows.Add();

            float accumulator = firstArrival;
            for (int i = 0; i < ganttChartData.Count; i++)
            {
                accumulator += ganttChartData[i].Value;
                gc.Columns.Add((accumulator).ToString());
                ganttChart.Columns[i].Width = (int)(unitWidth * (float)Math.Round((ganttChartData[i].Value), 2));
                gc.Rows[0].SetField((accumulator).ToString(), ganttChartData[i].Key);
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
            averageTAT -= totalArrivalTime;
            averageWT = averageTAT - totalTime;
            averageTAT /= processes.Count;
            averageWT /= processes.Count;
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
        List<int> finish_list = new List<int>();
        int item = 0;
        int n_fcfs;                           //number of processe
        List<int> service_list = new List<int>();
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
            p_fcfs.burst_time = int.Parse(burstText_fcfs.Text);          //convert text string to integar
            p_fcfs.arrival_time = int.Parse(arrivalText_fcfs.Text);     //convert text string to integar
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
            int start = process_fcfs[0].arrival_time;
            int finish = start + process_fcfs[0].burst_time;
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
                idle_time.Size = new System.Drawing.Size(25, 25);
                TextBox idle_processing = new TextBox();
                idle_processing.Size = new System.Drawing.Size(31, 25);
                idle_processing.Enabled = true;
                idle_processing.Font = new Font("Arial", 10, FontStyle.Bold);
                idle_time.Font = new Font("Arial", 8, FontStyle.Bold);
                idle_processing.Text = "idle";
                idle_time.Text = "0";
                flowLayoutPanel3_fcfs_nums.Controls.Add(idle_time);
                flowLayoutPanel2_fcfs.Controls.Add(idle_processing);
            }

            int first_time = 0;
            first_time = service_list[0];
            Label firstpro = new Label();
            firstpro.Text = first_time.ToString();
            firstpro.Size = new System.Drawing.Size(25, 25);
            firstpro.Font = new Font("Arial", 8, FontStyle.Bold);
            flowLayoutPanel3_fcfs_nums.Controls.Add(firstpro);

            TextBox mm = new TextBox();
            mm.Enabled = true;
            mm.Size = new System.Drawing.Size(25, 25);
            mm.Font = new Font("Arial", 10, FontStyle.Bold);
            string ss = "P" + process_fcfs[0].Pid.ToString();
            mm.Text = ss;
            mm.ReadOnly = true;
            flowLayoutPanel2_fcfs.Controls.Add(mm);
            for (int i = 1; i < n_fcfs; i++)
            {

                if (flag > 0 && ((process_fcfs[i].arrival_time) - (finish_list[i - 1])) > 0)
                {
                    int idlee_time;
                    idlee_time = finish_list[i - 1];
                    Label idle_time = new Label();
                    idle_time.Text = idlee_time.ToString();
                    idle_time.Size = new System.Drawing.Size(25, 25);
                    TextBox idle_processing = new TextBox();
                    idle_processing.Size = new System.Drawing.Size(31, 25);
                    idle_processing.Enabled = true;
                    idle_processing.Font = new Font("Arial", 10, FontStyle.Bold);
                    idle_time.Font = new Font("Arial", 8, FontStyle.Bold);
                    idle_processing.Text = "idle";

                    flowLayoutPanel3_fcfs_nums.Controls.Add(idle_time);
                    flowLayoutPanel2_fcfs.Controls.Add(idle_processing);
                    flag--;


                    int next_time;
                    next_time = process_fcfs[i].arrival_time;
                    Label next_time1 = new Label();
                    next_time1.Text = next_time.ToString();
                    next_time1.Size = new System.Drawing.Size(25, 25);
                    next_time1.Font = new Font("Arial", 8, FontStyle.Bold);
                    flowLayoutPanel3_fcfs_nums.Controls.Add(next_time1);

                    TextBox zz = new TextBox();
                    zz.Enabled = true;
                    zz.Size = new System.Drawing.Size(25, 25);
                    string zzz = "P" + process_fcfs[i].Pid.ToString();
                    zz.Text = zzz;
                    zz.ReadOnly = true;
                    flowLayoutPanel2_fcfs.Controls.Add(zz);

                }
                else
                {
                    int next_time;
                    next_time = finish_list[i - 1];
                    Label next_time1 = new Label();
                    next_time1.Text = next_time.ToString();
                    next_time1.Size = new System.Drawing.Size(25, 25);
                    next_time1.Font = new Font("Arial", 8, FontStyle.Bold);
                    flowLayoutPanel3_fcfs_nums.Controls.Add(next_time1);

                    TextBox zz = new TextBox();
                    zz.Enabled = true;
                    zz.Size = new System.Drawing.Size(25, 25);
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
            last_time21.Size = new System.Drawing.Size(25, 25);
            last_time21.Font = new Font("Arial", 8, FontStyle.Bold);
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
            public int burst_time;
            public int waiting_time = 0;
            public int last_active = 0;
            public int arrival_time;
        }




        #endregion
        /************************** Roundrobin *************************/
        DataTable dt_RR = new DataTable(); //roundrobin table 
        int burstTime;
        string processName;
        /********   global variables *********/


        /************************** SJF NON Premptive *************************/
        DataTable DT_RR_SJF = new DataTable(); //roundrobin table 
        int Burst_time_SJF;
        int Arrival_Time_SJF;
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
                quantum = Int32.Parse(quantum_TextBox.Text);
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
        public void set_waiting(int q, int k)
        {

            for (int i = 0; i < list_process.Count; i++)
            {
                if (list_process[i].get_burst() > 0 && i != k)
                {
                    int x = list_process[i].get_waiting();
                    x += q;
                    list_process[i].set_waiting(x);
                }
            }

        }


        private void RR_simulate_Click(object sender, EventArgs e)
        {
            List<process> SortedList = list_process.OrderBy(o => o.arrival_time).ToList();
            label9.Text = "0";
            if (quantum < 1 || quantum > 100)
            {
                Error_label.Text = "Quantum time generally form 1 to 100 ms";
                quantum = 0;
                return;
            }
            Error_label.Text = "";
            //simulate 
            while (SortedList.Count != 0)
            {
                for (int i = 0; i < SortedList.Count; i++)
                {
                    if (SortedList[i].get_burst() > quantum)
                    {
                        //first time
                        running_time += quantum;
                        int x = SortedList[i].get_burst();
                        x -= quantum;
                        set_waiting(quantum, i);
                        SortedList[i].set_burst(x);

                        Label l = Add_label_process(i);
                        flowLayoutPanel2.Controls.Add(l);

                        Label l1 = Add_label_time(running_time);
                        flowLayoutPanel3.Controls.Add(l1);
                    }
                    else
                    {
                        if (SortedList[i].get_burst() > 0)
                        {
                            Label l = Add_label_process(i);
                            flowLayoutPanel2.Controls.Add(l);

                            set_waiting(SortedList[i].get_burst(), i);

                            running_time += SortedList[i].get_burst();

                            Label l1 = Add_label_time(running_time);
                            flowLayoutPanel3.Controls.Add(l1);
                        }
                        SortedList[i].set_burst(0);
                    }
                }

                bool k = false;

                for (int i = 0; i < SortedList.Count; i++)
                {
                    k = (k || !(SortedList[i].get_burst() == 0));
                }

                if (!k)
                {
                    break;
                }
                k = false;
            }

            for (int i = 0; i < SortedList.Count; i++)
            {
                total_waiting += SortedList[i].waiting_time;
            }
            total_waiting = total_waiting / SortedList.Count;
            Average_label.Text = "Average waiting time :" + total_waiting.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // insert button 
                burstTime = Int32.Parse(bursttime_textBox.Text);
                arrivalTime = Int32.Parse(arrivaltime_textbox.Text);

                process p = new process(Process_textBox.Text, burstTime, arrivalTime);
                list_process.Add(p);



                if (processName != "" && burstTime != 0)
                {
                    dt_RR.Rows.Add(Process_textBox.Text, arrivalTime, burstTime);
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



        List<KeyValuePair<int, KeyValuePair<string, int>>> my_process = new List<KeyValuePair<int, KeyValuePair<string, int>>>();

        int Full_Time = 0;
        private void button8_Click(object sender, EventArgs e)
        {

            try
            {

                Process_Name_SJF = Process_SJF_textbox.Text;
                Burst_time_SJF = Int32.Parse(bursttime_SJF_textbox.Text);
                Arrival_Time_SJF = Int32.Parse(arrIval_SJF_textbox.Text);
                KeyValuePair<string, int> Pairrr = new KeyValuePair<string, int>(Process_Name_SJF, Arrival_Time_SJF);
                KeyValuePair<int, KeyValuePair<string, int>> Process_Info_SJF = new KeyValuePair<int, KeyValuePair<string, int>>(Burst_time_SJF, Pairrr);
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
            for (int i = 0; i < Full_Time; ++i)
            {


                bool Idle_Flag = true;

                foreach (KeyValuePair<int, KeyValuePair<string, int>> Process in my_process)
                {
                    int Burst_time = Process.Key;
                    string Process_Name = Process.Value.Key;
                    int Arrival_time = Process.Value.Value;
                    bool is_removed = RemovedProcess.Contains(Process_Name);

                    if ((Arrival_time <= i) && !(is_removed))
                    {
                        waiting_time_SJF += (i - Arrival_time);
                        i += (Burst_time - 1);
                        Label L = Add_label_process_SJF(Process_Name);
                        flowLayoutPanel5.Controls.Add(L);
                        Label L2 = Add_label_time(i + 1);
                        flowLayoutPanel4.Controls.Add(L2);
                        RemovedProcess.Add(Process_Name);
                        Idle_Flag = false;
                        break;
                    }

                }
                if (Idle_Flag == true)
                {
                    Label L3 = Add_label_process_SJF("Idle");
                    flowLayoutPanel5.Controls.Add(L3);
                    Label L4 = Add_label_time(i + 1);
                    flowLayoutPanel4.Controls.Add(L4);
                    Full_Time++;
                }




            }
            waiting_time_SJF /= (my_process.Count);
            label10.Text = "Waiting Time:  " + waiting_time_SJF.ToString();

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
        int Burst_time_pp;
        int Arrival_Time_pp;
        int proirity_pp;
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
        Label Add_label_time_pp(int i)
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


                l.Margin = new Padding(0, 2, 0, 5);
                first = false;
            }
            else
            {

                l.Margin = new Padding(35, 2, 0, 5);
            }
            return l;
        }

        List<KeyValuePair<KeyValuePair<string, int>, KeyValuePair<int, int>>> priority_p_process = new List<KeyValuePair<KeyValuePair<string, int>, KeyValuePair<int, int>>>();
        int total_time_pp = 0;

        private void priority_pp_Click(object sender, EventArgs e)
        {

            try
            {
                // <name, burst, arrival, priority> 
                Process_Name_pp = process_pp.Text;
                Burst_time_pp = Int32.Parse(burst_pp.Text);
                Arrival_Time_pp = Int32.Parse(arrival_pp.Text);
                proirity_pp = Int32.Parse(priority_p.Text);

                KeyValuePair<string, int> P1 = new KeyValuePair<string, int>(Process_Name_pp, Burst_time_pp);
                KeyValuePair<int, int> P2 = new KeyValuePair<int, int>(Arrival_Time_pp, proirity_pp);
                KeyValuePair<KeyValuePair<string, int>, KeyValuePair<int, int>> Process_Info_pp = new KeyValuePair<KeyValuePair<string, int>, KeyValuePair<int, int>>(P1, P2);
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
            for (int i = 0; i < total_time_pp; ++i)
            {

                for (int j = 0; j < size; j++)
                {
                    string name = priority_p_process[j].Key.Key;
                    int burst = priority_p_process[j].Key.Value;

                    int arrival = priority_p_process[j].Value.Key;
                    int priority = priority_p_process[j].Value.Value;

                    if ((arrival <= i) && (burst > 0))
                    {
                        idle = false;
                        if (name != lastprocess)
                        {
                            Label L = Add_label_process_pp(name);
                            flowLayoutPanel7.Controls.Add(L);
                            Label L2 = Add_label_time_pp(i);
                            flowLayoutPanel6.Controls.Add(L2);
                        }
                        lastprocess = name;
                        burst--;
                        // calculate waiting time
                        for (int l = 0; l < size; l++)
                        {
                            int burst2 = priority_p_process[l].Key.Value;
                            int arrival2 = priority_p_process[l].Value.Key;
                            string name2 = priority_p_process[l].Key.Key;
                            if ((burst2 > 0) && (arrival2 <= i) && (name2 != name))
                            {
                                waiting++;
                            }
                        }
                        KeyValuePair<string, int> k = new KeyValuePair<string, int>(name, burst);
                        KeyValuePair<int, int> v = new KeyValuePair<int, int>(arrival, priority);
                        priority_p_process[j] = new KeyValuePair<KeyValuePair<string, int>, KeyValuePair<int, int>>(k, v);

                        if ((j == priority_p_process.Count - 1) && (burst == 0))
                        {
                            Label L2 = Add_label_time_pp(i + 1);
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
                        Label L2 = Add_label_time_pp(i);
                        flowLayoutPanel6.Controls.Add(L2);

                    }
                    if (idle) total_time_pp++;
                }
            }
            waiting /= (size);
            label22.Text = "Average Waiting Time:  " + waiting.ToString();
        }

        #endregion

        private void dataGridView_pp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PriorityNP_Click(object sender, EventArgs e)
        {

        }

        private void PPriorityLabel_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_SJF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void PInsert_Click(object sender, EventArgs e)
        {

            if (enter2_count == numericUpDown1.Value - 1)
            {
                PInsert.Text = "Draw Gantt Chart";
            }
            processarray[enter2_count].ProcessNumber = Convert.ToInt32(PProcessTxt.Text);
            processarray[enter2_count].ProcessBurstTime = Convert.ToInt32(PBurstTxt.Text);
            processarray[enter2_count].ProcessPriority = Convert.ToInt32(PPriorityTxt.Text);
            processarray[enter2_count].ProcessArrivalTime = Convert.ToInt32(PArrivalTxt.Text);

            myListOfProcesses.Add( new nonPreemptivePriorityProcess()
            { ProcessId= Convert.ToInt32(PProcessTxt.Text),
            ArrivalTime = Convert.ToInt32(PArrivalTxt.Text),
            BurstTime = Convert.ToInt32(PBurstTxt.Text),
            Priority = Convert.ToInt32(PPriorityTxt.Text),
        });
            DT_priorityNonPreemptive.Rows.Add(Convert.ToInt32(PProcessTxt.Text),
             Convert.ToInt32(PArrivalTxt.Text),
            Convert.ToInt32(PBurstTxt.Text),
            Convert.ToInt32(PPriorityTxt.Text));

            enter2_count++;

            PProcessTxt.Text = "";

            PBurstTxt.Text = "";
            PPriorityTxt.Text = "";


            PArrivalTxt.Text = "";


            if (enter2_count == numericUpDown1.Value)
            {


                int i; /* pass counter */
                int j; /* comparison counter */
                PProcess temp;
                /* loop to control passes */

                for (i = 0; i < numericUpDown1.Value - 1; i++)
                {
                    /* loop to control comparisons during each pass */
                    for (j = 0; j < numericUpDown1.Value - 1; j++)
                    {
                        /* swap adjacent elements if they are out of order */
                        if (processarray[j].ProcessPriority > processarray[j + 1].ProcessPriority)
                        {
                            temp = processarray[j];
                            processarray[j] = processarray[j + 1];
                            processarray[j + 1] = temp;
                        } /* end if */
                    } /* end inner for */
                } /* end outer for */
                for (int k = 1; k < numericUpDown1.Value; k++)
                {
                    processarray[k].ProcessStartingTime = processarray[k - 1].ProcessBurstTime + processarray[k - 1].ProcessStartingTime;
                    processarray[k].ProcessAverageWaitingTime = processarray[k].ProcessStartingTime - processarray[k].ProcessArrivalTime;
                }
                for (int y = 0; y < numericUpDown1.Value; y++)
                {
                    TotalAverageWaiting += processarray[y].ProcessAverageWaitingTime;
                }

                PavgLabel.Show();
                PriorityAvgTxt.Show();
                PriorityAvgTxt.Text = (TotalAverageWaiting / numericUpDown1.Value).ToString("N");
                PGanttLabel.Show();
                gantt_chart_priority();



            }

        }
        // function to draw gantt chart of priority
        int next_time;
        int first_time;
        private void gantt_chart_priority()
        {
            // function to draw gantt chart of priority non preemptive


            if (processarray[0].ProcessArrivalTime > 0)
            {
                Label idle_time = new Label();
                idle_time.Size = new System.Drawing.Size(25, 25);
                TextBox idle_processing = new TextBox();
                idle_processing.Size = new System.Drawing.Size(31, 25);
                idle_processing.Enabled = true;
                idle_processing.Font = new Font("Arial", 10, FontStyle.Bold);
                idle_time.Font = new Font("Arial", 8, FontStyle.Bold);
                idle_processing.Text = "idle";
                idle_time.Text = "0";
                flowLayoutPanel3_nonpreemptivepriority.Controls.Add(idle_time);
                flowLayoutPanel2_nonpreemptivepriority.Controls.Add(idle_processing);
            }

           
            first_time = processarray[0].ProcessStartingTime;
            Label firstpro = new Label();
            firstpro.Text = first_time.ToString();
            firstpro.Size = new System.Drawing.Size(25, 25);
            firstpro.Font = new Font("Arial", 8, FontStyle.Bold);
            flowLayoutPanel3_nonpreemptivepriority.Controls.Add(firstpro);

            TextBox mm = new TextBox();
            mm.Enabled = true;
            mm.Size = new System.Drawing.Size(25, 25);
            mm.Font = new Font("Arial", 8, FontStyle.Bold);
            string ss = "P" + processarray[0].ProcessNumber.ToString();
            mm.Text = ss;
            mm.ReadOnly = true;
            flowLayoutPanel2_nonpreemptivepriority.Controls.Add(mm);
            for (int i = 1; i < numericUpDown1.Value; i++)
            {


                next_time = processarray[i].ProcessStartingTime;
                Label next_time1 = new Label();
                next_time1.Text = next_time.ToString();
                next_time1.Size = new System.Drawing.Size(25, 25);
                next_time1.Font = new Font("Arial", 8, FontStyle.Bold);
                flowLayoutPanel3_nonpreemptivepriority.Controls.Add(next_time1);

                TextBox zz = new TextBox();
                zz.Enabled = true;
                zz.Size = new System.Drawing.Size(25, 25);
                string zzz = "P" + processarray[i].ProcessNumber.ToString();
                zz.Text = zzz;
                zz.ReadOnly = true;
                flowLayoutPanel2_nonpreemptivepriority.Controls.Add(zz);


            }
            //last time label
            Label last_time21 = new Label();
            last_time21.Size = new System.Drawing.Size(25, 25);
            last_time21.Font = new Font("Arial", 8, FontStyle.Bold);
            last_time21.Text =( processarray[Convert.ToInt32(numericUpDown1.Value) - 1].ProcessBurstTime+ processarray[Convert.ToInt32(numericUpDown1.Value) - 1].ProcessStartingTime).ToString();
            flowLayoutPanel3_nonpreemptivepriority.Controls.Add(last_time21);

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flowLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PriorityNP_Click_1(object sender, EventArgs e)
        {

        }
    }


    /********************************  Roundrobin classes  ***********************/
    class process
    {
        public string Process_name;
        int burst_Time;
        public int waiting_time;
        public int arrival_time;



       public process(string s, int burst, int arrival)
        {
            Process_name = s;
            burst_Time = burst;
            arrival_time = arrival;
            waiting_time = 0;
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

        public int get_waiting()
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
