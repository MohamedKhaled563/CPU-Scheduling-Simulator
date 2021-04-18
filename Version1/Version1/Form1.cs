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
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
      
                SJFTabPage.BackColor = System.Drawing.ColorTranslator.FromHtml("#bac7a7");
                ganttChart.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#698474");
                insert.BackColor = System.Drawing.ColorTranslator.FromHtml("#698474");
                drawButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#698474");
                
                processGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                processGrid.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#bac7a7");
                processTF.BackColor = System.Drawing.ColorTranslator.FromHtml("#e5e4cc");
                arrivalTimeTF.BackColor = System.Drawing.ColorTranslator.FromHtml("#e5e4cc");
                burstTimeTF.BackColor = System.Drawing.ColorTranslator.FromHtml("#e5e4cc");
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
                dt.Rows.Add(processName, arrivalTime, burstTime);
                processTF.Text = "";
                arrivalTimeTF.Text = "";
                burstTimeTF.Text = "";
            }
        }

        private void drawButton_Click_1(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                int totalTime = 0;
                var mp = new SortedDictionary<int, KeyValuePair<string, int>>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int time = Convert.ToInt32(dt.Rows[i].Field<string>(2));
                    string processName = dt.Rows[0].Field<string>(0);
                    int arrivalTime = Convert.ToInt32(dt.Rows[i].Field<string>(1));
                    var p = new KeyValuePair<string, int>(processName, arrivalTime);
                    mp[time] = p;
                    totalTime += time;
                }
                consol.Text = "";
                
                foreach (KeyValuePair<int, KeyValuePair<string, int>> element in mp)
                {
                    consol.Text += element.Value.Key + "   " + element.Value.Value + "   " + element.Key +'\n';
                }

                int numberOfProcess = mp.Count();
                var map = new SortedDictionary<string, KeyValuePair<int, int>>();

                for (int i = 0; i < totalTime; i++)
                {
                    // Check for arrical time
                        int burst = mp.First().Key;
                        foreach (KeyValuePair<int, KeyValuePair<string, int>> element in mp)
                        {
                            burst = element.Key;
                            int arrTime = element.Value.Value;
                            string processName = element.Value.Key;
                            if(arrTime <= i)
                            {
                                var p = new KeyValuePair<int, int>(arrTime, burst);
                                map[processName] = p;
                                break;
                            }
                        }
                        mp.Remove(burst);
                    
                }
                label12.Text = "";
                foreach (KeyValuePair<string, KeyValuePair<int, int>> element in map)
                {
                    label12.Text += element.Value.Key + "   " + element.Value.Value + "   " + element.Key + '\n';
                }

                ganttChart.Visible = true;
                DataTable gc = new DataTable();
                ganttChart.DataSource = gc;

                int totalWidth = ganttChart.Width;
                int unitWidth = totalWidth / dt.Rows.Count;


                int minArrTime = Convert.ToInt32(dt.Rows[0].Field<string>(1));
                int remainingTime = Convert.ToInt32(dt.Rows[0].Field<string>(2));

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                }


                /*int totalWidth = ganttChart.Width;
                int unitWidth = totalWidth / dt.Rows.Count;


                int totalTime = 0;
                int minArrTime = Convert.ToInt32(dt.Rows[0].Field<string>(1));
                string processName = dt.Rows[0].Field<string>(0);
                int remainingTime = Convert.ToInt32(dt.Rows[0].Field<string>(2));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i].Field<string>(1)) < minArrTime)
                    {
                        minArrTime = Convert.ToInt32(dt.Rows[i].Field<string>(1));
                        processName = dt.Rows[i].Field<string>(0);
                        remainingTime = Convert.ToInt32(dt.Rows[i].Field<string>(1));
                    }
                    string title = "";
                    gc.Columns.Add(title);
                    ganttChart.Columns[i].Width = unitWidth;
                    string burstTime = dt.Rows[i].Field<string>(2);
                    totalTime += Convert.ToInt32(burstTime);
                }
                bool shouldCheck = false;
                ganttChart.Columns[0].HeaderText = processName;
                int currentTime = minArrTime;
                for (int i = 0; i < totalTime; i++)
                {
                    if (remainingTime == 0)
                    {
                        int j;
                        for (j = 0; j < dt.Rows.Count; j++)
                        {
                            int arrTime = Convert.ToInt32(dt.Rows[j].Field<string>(1));
                            if (arrTime >= currentTime)
                            {
                                shouldCheck = true;
                                break;
                            }
                        }
                    }

                    int j;

                    for (j = 0; j < dt.Rows.Count; j++)
                    {
                        if (dt.Rows[j].Field<string>(1) == i.ToString())
                        {
                            shouldCheck = true;
                            break;
                        }
                    }
                    if (!shouldCheck)
                        continue;
                    else
                    {
                        ganttChart.Columns[j].HeaderText = dt.Rows[j].Field<string>(0);
                    }
                    remainingTime--;
                    currentTime++;
                }

                //   string processName = dt.Rows[i].Field<string>(0)
                //ganttChart.Columns[0].Width = 2 * unitWidth;
             //   ganttChart.Columns[1].Width = 3 * unitWidth;
            //    ganttChart.Columns[2].Width = 1 * unitWidth;
            //    ganttChart.Columns[3].Width = 4 * unitWidth;
             //   ganttChart.Columns[4].Width = 1 * unitWidth;   */
            }

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
        private void button5_Click(object sender, EventArgs e)
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
        /* -------------------------- END FCFS ------------------------------ */
        #endregion







        
    }
}
