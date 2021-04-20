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
        DataTable dt = new DataTable();
        Dictionary<string, KeyValuePair<int, int>> processes = new Dictionary<string, KeyValuePair<int, int>>();
        int totalTime = 0;

        public Form1()
        {
            InitializeComponent();
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
            var process = new KeyValuePair<int, int>(Int32.Parse(arrivalTime), Int32.Parse(burstTime));
            processes[processName] = process;
            totalTime += Int32.Parse(burstTime);

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
            var ganttChartData = new List<KeyValuePair<string, int>>();
            int firstArrival = 1000;
            foreach (KeyValuePair<string, KeyValuePair<int, int>> process in processes)
            {
                if (process.Value.Key < firstArrival)
                    firstArrival = process.Value.Key;
            }

            for (int i = firstArrival; i < totalTime + firstArrival; i++){
                var arrivedProcesses = new Dictionary<string, KeyValuePair<int, int>>() ;
                foreach (KeyValuePair<string, KeyValuePair<int, int>> process in processes)
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
                    foreach (KeyValuePair<string, KeyValuePair<int, int>> process in arrivedProcesses)
                    {
                        if (process.Value.Value < arrivedProcesses[minimumRemainingTimeProcess].Value)
                        {
                            minimumRemainingTimeProcess = process.Key;
                        }
                    } // Minimum time process
                    processes[minimumRemainingTimeProcess] = new KeyValuePair<int, int>(processes[minimumRemainingTimeProcess].Key, processes[minimumRemainingTimeProcess].Value - 1);
                    if (ganttChartData.Count() == 0)
                    {
                        var v = new KeyValuePair<string, int>(minimumRemainingTimeProcess, 1);
                        ganttChartData.Add(v);
                    }
                    else
                    {
                        var lastElement = ganttChartData.Last();
                        if (lastElement.Key == minimumRemainingTimeProcess)
                        {
                            lastElement = new KeyValuePair<string, int>(lastElement.Key, lastElement.Value + 1);
                            ganttChartData.RemoveAt(ganttChartData.Count - 1);
                            ganttChartData.Add(lastElement);
                        }
                        else
                        {
                            var v = new KeyValuePair<string, int>(minimumRemainingTimeProcess, 1);
                            ganttChartData.Add(v);
                        }
                    }
         //           consol.Text += minimumRemainingTimeProcess + " ";
                }

               
            }
            //consol.Text += '\n';
            foreach (KeyValuePair<string, int> cell in ganttChartData)
            {
           //     consol.Text += cell.Key + " " + cell.Value + " ";
            }
            ganttChart.Visible = true;
            DataTable gc = new DataTable();
            ganttChart.DataSource = gc;
            int totalWidth = ganttChart.Width;
            int unitWidth = totalWidth / totalTime;
            gc.Rows.Add();

            int accumulator = firstArrival;
            for (int i = 0; i < ganttChartData.Count; i++)
            {
                accumulator += ganttChartData[i].Value;
                gc.Columns.Add((accumulator).ToString());
                ganttChart.Columns[i].Width = unitWidth * ganttChartData[i].Value;
                gc.Rows[0].SetField((accumulator).ToString(), ganttChartData[i].Key);
            }

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

            process_fcfs[0].waiting_time = 0;     // waiting time of first proceeses is zero by default
            for (int i = 0; i <= n_fcfs; i++)
            {
                service_list.Add(i);
            }
            for (int i = 1; i < n_fcfs; i++)
            {

                service_list[i] = service_list[i - 1] + process_fcfs[i - 1].burst_time;
                process_fcfs[i].waiting_time = service_list[i] - process_fcfs[i].arrival_time;


                if (process_fcfs[i].waiting_time < 0)
                {
                    process_fcfs[i].waiting_time = 0;
                }
                time_fcfs += process_fcfs[i].waiting_time;
            }

            waitingText_fcfs.Text = (time_fcfs / n_fcfs).ToString();
            gantt_chart_fcfs();
        }
        // function to draw gantt chart of fcfs
        private void gantt_chart_fcfs()
        {

            int X = 16;
            int time3 = 0;
            for (int i = 0; i < n_fcfs; i++)
            {
                // time labels
                Label num_fcfs = new Label();
                num_fcfs.Text = time3.ToString();
                num_fcfs.Size = new System.Drawing.Size(27, 25);
                num_fcfs.Font = new Font("Arial", 8, FontStyle.Bold);
                //if (process_fcfs[i].burst_time < 3) num_fcfs.Width = 27;
                //else num_fcfs.Width = process_fcfs[i].burst_time * 10;
                flowLayoutPanel3_fcfs_nums.Controls.Add(num_fcfs);
                time3 += process_fcfs[i].burst_time;

                // labels of processes
                TextBox nn = new TextBox();
                nn.Enabled = true;
                nn.Size = new System.Drawing.Size(32, 25);
                // nn.BorderStyle = BorderStyle.FixedSingle;
                nn.Font = new Font("Arial", 10, FontStyle.Bold);
                string s = "P" + process_fcfs[i].Pid.ToString();
                nn.Location = new System.Drawing.Point(X, 34);
                nn.Text = s;
                nn.ReadOnly = true;
                //if (process_fcfs[i].burst_time < 3) tempLabel_fcfs.Width = 27;
                //else tempLabel_fcfs.Width = process_fcfs[i].burst_time * 10;
                flowLayoutPanel2_fcfs.Controls.Add(nn);
                X += nn.Width;
            }

            //last time label
            Label num_fcfsLast = new Label();
            num_fcfsLast.Size = new System.Drawing.Size(25, 25);
            num_fcfsLast.Font = new Font("Arial", 8, FontStyle.Bold);
            num_fcfsLast.Text = time3.ToString();
            flowLayoutPanel3_fcfs_nums.Controls.Add(num_fcfsLast);
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



        private void arrivaltime_textBox_TextChanged(object sender, EventArgs e)
        {

        }

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
            catch(Exception)
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
            l.Text ="" + i.ToString();
            l.ForeColor = Color.Black;
            l.BackColor = Color.White;
            l.Width = 40;
            l.Height = 28;
            l.TextAlign = ContentAlignment.MiddleLeft;

            if (first)
            {
              

                l.Margin = new Padding(50 ,2, 0, 5);
                first = false;
            }
            else
            {
               
                l.Margin = new Padding(45, 2, 0, 5);
            }
            return l;
        }
        public void set_waiting(int q,int  k)
        {

            for (int i = 0; i < list_process.Count; i++)
            {
                if (list_process[i].get_burst() > 0 && i != k )
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
            while(SortedList.Count != 0  )
            {
                for(int i = 0; i < SortedList.Count; i++)
                {
                    if(SortedList[i].get_burst() > quantum)
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
                        if(SortedList[i].get_burst() > 0)
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

                if(!k)
                {
                    break;
                }
                k = false;
            }

            for(int i = 0; i < SortedList.Count; i++ )
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
            catch(Exception)
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



        List<KeyValuePair<int, KeyValuePair<string, int>>>  my_process = new List<KeyValuePair<int, KeyValuePair<string, int>>>();
       
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
                        i += (Burst_time -1);
                        Label L = Add_label_process_SJF(Process_Name);
                        flowLayoutPanel5.Controls.Add(L);
                        Label L2 = Add_label_time(i+1);
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
                    Label L4 = Add_label_time(i+1);
                    flowLayoutPanel4.Controls.Add(L4);
                    Full_Time++;
                }




            }
            waiting_time_SJF /= (my_process.Count );
            label10.Text = "Waiting Time:  " + waiting_time_SJF.ToString();
            
        }

        private void Process_SJF_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void RR_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
